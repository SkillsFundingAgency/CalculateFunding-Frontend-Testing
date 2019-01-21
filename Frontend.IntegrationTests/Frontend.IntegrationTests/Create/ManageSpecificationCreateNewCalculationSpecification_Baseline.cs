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
    public static class ManageSpecificationCreateNewCalculationSpecification_Baseline
    {
        public static void CreateANewSpecificationPolicy_Baseline()

        {
            CreateCalculationPage createcalculationpage = new CreateCalculationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            

            string newname = "TestBaselineCalculationName";
            string descriptiontext = "This is a Description for: ";

            var randomSpecCalcName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecCalcName"] = randomSpecCalcName;
            managepoliciespage.CreateCalculation.Click();
            Thread.Sleep(2000);
            createcalculationpage.CalculationName.SendKeys(randomSpecCalcName);
            createcalculationpage.CalculationDescription.SendKeys(descriptiontext + randomSpecCalcName);
            Actions.CreateCalculationSpecificationpageSelectPolicyOrSubpolicyDropDown();

            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selectElement = new SelectElement(calctype);
            selectElement.SelectByValue("Baseline");

            var allocation = createcalculationpage.CalculationAllocationLine;
            var selectElement01 = new SelectElement(allocation);
            selectElement01.SelectByValue("YPM07");

            createcalculationpage.SaveCalculation.Click();
            Thread.Sleep(2000);
            var specCalcNumName = ScenarioContext.Current["SpecCalcName"];
            string numSpecCalcCreated = specCalcNumName.ToString();
            Console.WriteLine(numSpecCalcCreated + " has been created successfully");
            Thread.Sleep(5000);

        }


    }
}
