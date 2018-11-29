using AutoFramework;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Frontend.IntegrationTests.Models;
using CalculateFunding.Common.ApiClient.Users.Models;

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


        [Then(@"I can successfully create a new Specification")]
        public void ThenICanSuccessfullyCreateANewSpecification()
        {
            CreateNewSpecification.CreateANewSpecification();
        }

        [Given(@"I have Navigated to the Edit Specifiction Page")]
        public void GivenIHaveNavigatedToTheEditSpecifictionPage()
        {
            NavigateTo.EditSpecificationPage();
            Thread.Sleep(2000);
        }


        [Then(@"I can successfully navigate to the Create Dataset page")]
        public void ThenICanSuccessfullyNavigateToTheCreateDatasetPage()
        {
            NavigateTo.CreateDatasetPage();
            Thread.Sleep(2000);
        }

        [Then(@"I can successfully navigate to the Create Policy page")]
        public void ThenICanSuccessfullyNavigateToTheCreatePolicyPage()
        {
            NavigateTo.CreatePolicy();
            Thread.Sleep(2000);
        }

        [Then(@"I can successfully navigate to the Create Calculation Specificaton page")]
        public void ThenICanSuccessfullyNavigateToTheCreateCalculationSpecificatonPage()
        {
            NavigateTo.CreateCalculation();
            Thread.Sleep(2000);
        }

        [Then(@"I can successfully navigate to the Create Sub Policy page")]
        public void ThenICanSuccessfullyNavigateToTheCreateSubPolicyPage()
        {
            NavigateTo.CreateSubPolicy();
            Thread.Sleep(2000);
        }

        [Then(@"I have navigated to the Approve and publish funding Page")]
        public void ThenIHaveNavigatedToTheApproveAndPublishFundingPage()
        {
            NavigateTo.ApprovePublishFundingage();
            Thread.Sleep(2000);
        }



        [AfterScenario()]
        public void FixtureTearDown()
        {
            if (Driver._driver != null)
            {
                Driver._driver.Quit();
                Driver._driver.Dispose();
            }

        }

    }
}
