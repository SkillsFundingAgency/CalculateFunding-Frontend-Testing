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
    public static class CreateNewQATest
    {
        public static void CreateANewQATest()

        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
            CreateQATestPage createqatestpage = new CreateQATestPage();

            string newname = "QA Test Name ";
            string descriptiontext = "This is a Description for: ";

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

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
            Thread.Sleep(2000);






        }


    }
}
