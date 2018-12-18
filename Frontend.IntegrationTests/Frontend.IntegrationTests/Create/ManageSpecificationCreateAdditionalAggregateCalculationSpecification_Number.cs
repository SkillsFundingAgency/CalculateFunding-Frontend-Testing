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
    public static class ManageSpecificationCreateAdditionalAggregateCalculationSpecification_Number
    {
        public static void CreateAnAdditionalAggregateCalculation_Number()

        {
            CreateCalculationPage createcalculationpage = new CreateCalculationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            

            string newname = "TestAggCalculationName";
            string descriptiontext = "This is a Description for: ";

            var randomSpecCalcName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["AddAggCalcName"] = randomSpecCalcName;
            managepoliciespage.CreateCalculation.Click();
            Thread.Sleep(2000);
            createcalculationpage.CalculationName.SendKeys(randomSpecCalcName);
            createcalculationpage.CalculationDescription.SendKeys(descriptiontext + randomSpecCalcName);
            Actions.CreateCalculationSpecificationpageSelectPolicyOrSubpolicyDropDown();

            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selectElement = new SelectElement(calctype);
            selectElement.SelectByValue("Number");

            createcalculationpage.SaveCalculation.Click();
            Thread.Sleep(2000);
            var aggCalcNumName = ScenarioContext.Current["AddAggCalcName"];
            string aggCalcCreated = aggCalcNumName.ToString();
            Console.WriteLine(aggCalcCreated + " has been created successfully");
            Thread.Sleep(5000);

        }


    }
}
