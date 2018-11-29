using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Frontend.IntegrationTests.Pages.Quality_Assurance;
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
    [Binding]
    public static class ValidateQATestMissingFields
    {
        public static void ValidateANewQATestMissingFields()

        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
            CreateQATestPage createqatestpage = new CreateQATestPage();

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            var datasetName = ScenarioContext.Current["DatasetSchemaName"];
            string datasetCreated = datasetName.ToString();

            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();

            homepage.Header.Click();
            Thread.Sleep(2000);

            NavigateTo.CreateQATestPage();
            Thread.Sleep(2000);
            createqatestpage.createQATestName.Should().NotBeNull();

            Actions.SelectSpecifiedSpecificationCreateQATestPage();
            createqatestpage.createQATestDescription.Click();
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("Given the result for '" + specCalcCreated + "' is greater than '10'");
            //createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Enter);
            //createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("Then the result for '" + specCalcCreated + "' is equal to '10'");
            Thread.Sleep(2000);
            createqatestpage.createQATestValidateQATestButton.Click();
            Thread.Sleep(6000);
        }
    }
}
