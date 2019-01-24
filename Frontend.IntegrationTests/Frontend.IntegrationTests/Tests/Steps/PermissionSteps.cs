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
using OpenQA.Selenium;
using FluentAssertions;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class PermissionSteps
    {
        ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
        ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();

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

        [Then(@"A Notification is diplayed to inform the user they do not have permission for this action")]
        public void ThenANotificationIsDiplayedToInformTheUserTheyDoNotHavePermissionForThisAction()
        {
            IWebElement permissionNotification = Driver._driver.FindElement(By.CssSelector(".permission-warning-banner"));
            permissionNotification.Should().NotBeNull();

            IWebElement permissionsWarning = Driver._driver.FindElement(By.CssSelector(".permission-warning-text"));
            string permissionMesaage = permissionsWarning.Text;
            Console.WriteLine("Permission Warning Message Displayed is: " + permissionMesaage);
        }

        [Given(@"I have navigated to the Create Dataset Page")]
        public void GivenIHaveNavigatedToTheCreateDatasetPage()
        {
            NavigateTo.CreateDatasetPage();
        }

        [When(@"I click on the Create Dataset Button")]
        public void WhenIClickOnTheCreateDatasetButton()
        {
            managepoliciespage.Createdatatyperelationship.Click();
        }

        [Then(@"I am redirected to the Create Dataset Page")]
        public void ThenIAmRedirectedToTheCreateDatasetPage()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipName.Should().NotBeNull();
        }

        [Given(@"I have navigated to the specification data relationships page")]
        public void GivenIHaveNavigatedToTheSpecificationDataRelationshipsPage()
        {
            NavigateTo.SpecificationRelationshipsPage();
        }

        [Given(@"I have navigated to the Approve and publish funding Page for PE and Sport Specification")]
        public void GivenIHaveNavigatedToTheApproveAndPublishFundingPageForPEAndSportSpecification()
        {
            NavigateTo.ApprovePublishFundingage();
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
