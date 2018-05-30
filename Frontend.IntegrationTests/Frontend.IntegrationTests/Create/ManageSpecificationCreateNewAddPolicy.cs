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
    public static class ManageSpecificationCreateNewAddPolicy
    {
        public static void CreateAddNewSpecificationPolicy()

        {
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            CreatePolicyPage createpolicypage = new CreatePolicyPage();

            string newname = "Additional Test Policy Name ";
            string descriptiontext = "This is a Description for: ";

            var randomSpecPolicyName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["AddSpecPolicyName"] = randomSpecPolicyName;
            managepoliciespage.CreatePolicyButton.Click();
            Thread.Sleep(2000);
            createpolicypage.PolicyName.SendKeys(randomSpecPolicyName);
            createpolicypage.PolicyDescription.SendKeys(descriptiontext + randomSpecPolicyName);
            createpolicypage.SavePolicy.Click();
            Thread.Sleep(2000);
            var addSpecPolicyName = ScenarioContext.Current["AddSpecPolicyName"];
            string addSpecPolicyCreated = addSpecPolicyName.ToString();
            Console.WriteLine(addSpecPolicyCreated + " has been created successfully");
            Thread.Sleep(1000);

        }


    }


}
