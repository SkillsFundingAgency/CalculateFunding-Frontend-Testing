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

namespace Frontend.IntegrationTests.Create
{
    [Binding]
    public static class EditNewAggregateSum2ndTierCalculaton
    {
        public static void EditANewAggregateSum2ndTierCalculaton()

        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();
            EditCalculationsPage editcalculationspage = new EditCalculationsPage();

            var aggCalcNumName = ScenarioContext.Current["AggCalcName"];
            string aggCalcCreated = aggCalcNumName.ToString();
            var addAggCalcNumName = ScenarioContext.Current["AddAggCalcName"];
            string addAggCalcCreated = addAggCalcNumName.ToString();


            Thread.Sleep(2000);
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();
            editcalculationspage.CalculationVBEditor.Should().NotBeNull();
            editcalculationspage.CalculationVBTextEditor.SendKeys(Keys.Delete);
            editcalculationspage.CalculationVBTextEditor.SendKeys(Keys.Shift + Keys.End);
            Thread.Sleep(2000);
            editcalculationspage.CalculationVBTextEditor.SendKeys("Return Sum(" + aggCalcCreated + ")");
            Thread.Sleep(2000);
            editcalculationspage.BuildCalculationButton.Click();
            Thread.Sleep(10000);

            IWebElement EditCalculationCompiled = Driver._driver.FindElement(By.Id("compiler-response"));
            string CalculationCompiled = EditCalculationCompiled.Text;
            CalculationCompiled.Should().Be("Code compiled successfully: true\r\nError: " + addAggCalcCreated + " cannot reference another calc that is being aggregated");
            Console.WriteLine(CalculationCompiled);



        }


    }
}
