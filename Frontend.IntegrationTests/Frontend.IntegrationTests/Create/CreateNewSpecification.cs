namespace Frontend.IntegrationTests.Create
{
    using AutoFramework;
    using FluentAssertions;
    using Frontend.IntegrationTests.Helpers;
    using Frontend.IntegrationTests.Pages;
    using Frontend.IntegrationTests.Pages.Manage_Calculation;
    using Frontend.IntegrationTests.Pages.Manage_Specification;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Drawing.Imaging;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public static class CreateNewSpecification

    {

        public static void CreateANewSpecification()

        {
            ManageSpecificationPage managespecficationpage = new ManageSpecificationPage();
            CreateSpecificationPage createspecificationpage = new CreateSpecificationPage();
            CreateCalculationPage createcalculationpage = new CreateCalculationPage();
            HomePage homepage = new HomePage();

            string newname = "Test Spec Name ";
            string descriptiontext = "This is a Description for: ";

            NavigateTo.CreatetheSpecfication();
            Assert.IsNotNull(createcalculationpage.CalculationName);
            Thread.Sleep(2000);
            var randomSpecName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecificationName"] = randomSpecName;

            createspecificationpage.SpecName.SendKeys(randomSpecName);
            createspecificationpage.SpecDescription.SendKeys(descriptiontext + randomSpecName);
            var selectYear = createspecificationpage.SpecFundingPeriod;

            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1819");
            createspecificationpage.FundingStream.Click();
            createspecificationpage.FundingStream.SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000);
            createspecificationpage.SaveSpecification.Click();
            Thread.Sleep(2000);

            homepage.Header.Click();
            Thread.Sleep(2000);
            homepage.ManagetheSpecification.Click();
            Thread.Sleep(2000);

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            Console.WriteLine(specCreated + " has been created successfully");
            Driver._driver.FindElement(By.LinkText(specCreated)).Click();
            Thread.Sleep(1000);

        }

    }
}
