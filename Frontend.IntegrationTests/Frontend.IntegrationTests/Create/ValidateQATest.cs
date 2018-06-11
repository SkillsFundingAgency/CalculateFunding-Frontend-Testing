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
    public static class ValidateNewQATest
    {
        public static void ValidateANewQATest()

        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
            CreateQATestPage createqatestpage = new CreateQATestPage();

            string newname = "QA Test Name ";
            string descriptiontext = "This is a Description for: ";

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            var datasetName = ScenarioContext.Current["DatasetSchemaName"];
            string datasetCreated = datasetName.ToString();

            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();

            var randomQATestName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["QATestName"] = randomQATestName;

            homepage.Header.Click();
            Thread.Sleep(2000);

            NavigateTo.CreateQATestPage();
            Thread.Sleep(2000);
            createqatestpage.createQATestName.Should().NotBeNull();

            createqatestpage.createQATestName.SendKeys(randomQATestName);
            createqatestpage.createQATestDescription.SendKeys(descriptiontext + randomQATestName);

            Actions.SelectSpecifiedSpecificationCreateQATestPage();
            createqatestpage.createQATestDescription.Click();
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("Given the dataset '" + datasetCreated + "' field 'R14 High Needs Students 19-24' is equal to 'Test'");
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Enter);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("Then the result for '" + specCalcCreated + "' is equal to '10'");
            Thread.Sleep(2000);
            createqatestpage.createQATestValidateQATestButton.Click();
            Thread.Sleep(6000);
            
        }
    }
}
