﻿using CalculateFunding.Common.Utility;
using CalculateFunding.Frontend.Clients;
using CalculateFunding.Frontend.Clients.CommonModels;
using CalculateFunding.Frontend.Clients.UsersClient;
using CalculateFunding.Frontend.Interfaces.ApiClient;
using CalculateFunding.Permissions;
using CalculateFunding.Permissions.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Helpers
{
   public class PermissionsHelper
    {
        private const string OcpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";
        private const string SfaCorellationId = "sfa-correlationId";
        private const string SfaUsernameProperty = "sfa-username";
        private const string SfaUserIdProperty = "sfa-userid";

        private EnvironmentConfiguration environmentConfiguration;

        private ILogger logger;
        public PermissionsHelper()
        {
            logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();

            string apiEndPoint = Environment.GetEnvironmentVariable("usersApiEndPoint");
            string apiKey = Environment.GetEnvironmentVariable("usersApiKey");

            environmentConfiguration = new EnvironmentConfiguration()
            {
                ApiKey = apiKey,
                UsersBaseUrl = apiEndPoint,
            };
        }
        

        public async Task ApplyPermissions(UserPermission userPermission)
        {
            List<UserPermission> userPermissions = new List<UserPermission>()
            { userPermission };
    
            StaticHttpClientFactory httpClientFactory = new StaticHttpClientFactory();
            IUsersApiClient usersClient = GenerateUsersApiClient(logger, httpClientFactory, environmentConfiguration);

            PermissionService permissionService = new PermissionService(usersClient, logger);
            await permissionService.ApplyPermissions(userPermissions);
        }

        private static IUsersApiClient GenerateUsersApiClient(ILogger logger, StaticHttpClientFactory httpClientFactory, EnvironmentConfiguration environmentConfiguration)
        {
            Func<HttpClient> httpClientFunc = new Func<HttpClient>(() =>
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 10, 0);

                SetDefaultApiOptions(httpClient, new ApiOptions()
                {
                    ApiEndpoint = environmentConfiguration.UsersBaseUrl,
                    ApiKey = environmentConfiguration.ApiKey,
                });

                return httpClient;
            });

            httpClientFactory.AddClient(HttpClientKeys.Users, httpClientFunc);

            return new UsersApiClient(httpClientFactory, logger, null);
        }

        private static void SetDefaultApiOptions(HttpClient httpClient, ApiOptions options)
        {
            Guard.ArgumentNotNull(httpClient, nameof(httpClient));
            Guard.ArgumentNotNull(options, nameof(options));

            if (string.IsNullOrWhiteSpace(options.ApiEndpoint))
            {
                throw new InvalidOperationException("options EndPoint is null or empty string");
            }

            string baseAddress = options.ApiEndpoint;
            if (!baseAddress.EndsWith("/", StringComparison.CurrentCulture))
            {
                baseAddress = $"{baseAddress}/";
            }

            UserProfile userProfile = new UserProfile()
            {
                Id = "setuserpermissions",
                Firstname = "Set",
                Lastname = "User Permissions",
                UPN = "setuserpermissions@education.gov.uk",
            };

            httpClient.BaseAddress = new Uri(baseAddress, UriKind.Absolute);
            httpClient.DefaultRequestHeaders?.Add(OcpApimSubscriptionKey, options.ApiKey);
            httpClient.DefaultRequestHeaders?.Add(SfaUsernameProperty, userProfile.Fullname);
            httpClient.DefaultRequestHeaders?.Add(SfaUserIdProperty, userProfile.Id);

            httpClient.DefaultRequestHeaders?.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders?.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            httpClient.DefaultRequestHeaders?.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        }
    }

}
