using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using System.Threading;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Create
{
    public static class ManageSpecificationCreateNewProviderDataset
    {
        public static void CreateANewProviderDataset()

        {
            ManageSpecificationPage managespecficationpage = new ManageSpecificationPage();
            CreateSpecificationPage createspecificationpage = new CreateSpecificationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();

            string newname = "Test Dataset Name ";
            string descriptiontext = "This is a Datset Description";

            managepoliciespage.Createdatatyperelationship.Should().NotBeNull();
            managepoliciespage.Createdatatyperelationship.Click();
            Thread.Sleep(2000);
            Actions.SelectDatasetDataSchemaDropDown();
            var randomDatasetName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["DatasetSchemaName"] = randomDatasetName;
            choosedatasetrelationshippage.datasetSchemaRelationshipName.SendKeys(randomDatasetName);
            choosedatasetrelationshippage.datasetSchemaRelationshipDescription.SendKeys(descriptiontext);
            choosedatasetrelationshippage.createDatasetSetAsDataProvider.Click();
            choosedatasetrelationshippage.datasetSchemaRelationshipSaveButton.Click();
            Thread.Sleep(2000);
            managepoliciespage.datasetsTab.Should().NotBeNull();

        }



    }
}
