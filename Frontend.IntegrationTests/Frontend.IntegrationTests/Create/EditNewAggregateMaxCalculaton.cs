﻿using AutoFramework;
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
    public static class EditNewAggregateMaxCalculaton
    {
        public static void EditANewAggregateMaxCalculaton()

        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();
            EditCalculationsPage editcalculationspage = new EditCalculationsPage();

            var aggCalcNumName = ScenarioContext.Current["AggCalcName"];
            string aggCalcCreated = aggCalcNumName.ToString();
            /*Driver._driver.FindElement(By.LinkText(aggCalcCreated)).Click();
            Thread.Sleep(2000);
            editcalculationspage.SaveCalculationButton.Should().NotBeNull();*/

            Thread.Sleep(2000);
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();
            editcalculationspage.CalculationVBEditor.Should().NotBeNull();
            editcalculationspage.CalculationVBTextEditor.SendKeys(Keys.Delete);
            editcalculationspage.CalculationVBTextEditor.SendKeys(Keys.Shift + Keys.End);
            Thread.Sleep(2000);
            editcalculationspage.CalculationVBTextEditor.SendKeys("Return Sum(" + specCalcCreated + ") + Max(" + specCalcCreated + ")");
            Thread.Sleep(2000);
            editcalculationspage.BuildCalculationButton.Click();
            Thread.Sleep(10000);

            IWebElement EditCalculationCompiled = Driver._driver.FindElement(By.Id("compiler-response"));
            string CalculationCompiled = EditCalculationCompiled.Text;
            CalculationCompiled.Should().Be("Code compiled successfully: true");
            Console.WriteLine(CalculationCompiled);
            
            editcalculationspage.SaveCalculationButton.Click();
            Thread.Sleep(2000);

            Assert.IsNotNull(managecalculationpage.CalculationSearchField);
            Thread.Sleep(3000);
            Console.WriteLine(specCalcCreated + " has been edited successfully");
            Thread.Sleep(1000);

        }


    }
}
