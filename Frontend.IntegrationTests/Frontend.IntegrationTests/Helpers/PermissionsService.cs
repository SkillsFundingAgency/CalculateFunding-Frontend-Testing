using CalculateFunding.Common.ApiClient.Interfaces;
using CalculateFunding.Common.ApiClient.Models;
using CalculateFunding.Common.ApiClient.Users.Models;
using CalculateFunding.Common.Utility;
using Frontend.IntegrationTests.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Helpers
{
    public class PermissionService
    {
        private readonly IUsersApiClient _usersClient;
        private readonly ILogger _logger;

        public PermissionService(IUsersApiClient usersApiClient, ILogger logger)
        {
            Guard.ArgumentNotNull(usersApiClient, nameof(usersApiClient));
            Guard.ArgumentNotNull(logger, nameof(logger));

            _usersClient = usersApiClient;
            _logger = logger;
        }

        public async Task<IDictionary<UserPermission, ValidatedApiResponse<FundingStreamPermission>>> ApplyPermissions(IEnumerable<UserPermission> permissions)
        {
            Dictionary<UserPermission, ValidatedApiResponse<FundingStreamPermission>> results = new Dictionary<UserPermission, ValidatedApiResponse<FundingStreamPermission>>();
            if (permissions != null)
            {
                foreach (UserPermission userPermission in permissions)
                {
                    if (string.IsNullOrWhiteSpace(userPermission.UserId))
                    {
                        _logger.Error("Found UserPermission with empty or null userId");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(userPermission.FundingStreamId))
                    {
                        _logger.Error("Found UserPermission with empty or null userId");
                        continue;
                    }

                    if (userPermission.Permissions == null)
                    {
                        _logger.Error("Found UserPermission with null permissions");
                        continue;
                    }

                    try
                    {
                        ValidatedApiResponse<FundingStreamPermission> result = await _usersClient.UpdateFundingStreamPermission(userPermission.UserId, userPermission.FundingStreamId, userPermission.Permissions);
                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            _logger.Information("Updated '{FundingStream}' funding stream permissions for user {UserId}.", userPermission.FundingStreamId, userPermission.UserId);
                        }
                        else if (result.StatusCode == HttpStatusCode.PreconditionFailed)
                        {
                            _logger.Error("User ID {userId} does not exist in this environment, please create user first", userPermission.UserId);
                        }
                        else
                        {
                            _logger.Error("Unknown result for user ID '{userId}' and funding stream ID '{fundingStreamId}'", userPermission.UserId, userPermission.FundingStreamId);
                        }

                        results.Add(userPermission, result);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "Exception while applying permissions for user {userId} for funding stream {fundingStreamId}", userPermission.UserId, userPermission.FundingStreamId);

                        ValidatedApiResponse<FundingStreamPermission> validationResult = new ValidatedApiResponse<FundingStreamPermission>(HttpStatusCode.InternalServerError, null);

                        List<string> error = new List<string>()
                        {
                            ex.Message,
                        };

                        Dictionary<string, IEnumerable<string>> modelState = new Dictionary<string, IEnumerable<string>>();
                        modelState.Add("exception", error);

                        validationResult.ModelState = modelState;
                        results.Add(userPermission, validationResult);
                    }
                }
            }

            return results;
        }
    }
}
