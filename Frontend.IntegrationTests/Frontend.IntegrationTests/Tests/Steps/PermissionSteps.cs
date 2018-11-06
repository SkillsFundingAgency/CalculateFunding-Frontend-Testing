using CalculateFunding.Permissions.Clients.UsersClient.Models;
using CalculateFunding.Permissions.Models;
using Frontend.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class PermissionSteps
    {
        [Given(@"the user '(.*)' has the following permissions for Funding Stream '(.*)'")]
        public void GivenTheUserHasTheFollowingPermissionsForFundingStream(string userId, string fundingStreamId, Table table)
        {
            FundingStreamPermissionUpdateModel fundingStreamPermission = table.CreateInstance<FundingStreamPermissionUpdateModel>();
            PermissionsHelper helper = new PermissionsHelper();

            UserPermission userPermission = new UserPermission()
            {
                FundingStreamId = fundingStreamId,
                Permissions = fundingStreamPermission,
                UserId = userId,
            };

            helper.ApplyPermissions(userPermission).Wait();
        }

    }
}
