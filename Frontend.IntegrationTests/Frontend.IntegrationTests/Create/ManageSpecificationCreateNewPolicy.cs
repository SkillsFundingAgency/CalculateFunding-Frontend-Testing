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
    public static class ManageSpecificationCreateNewPolicy
    {

        public static void CreateANewSpecificationPolicy()

        {
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            CreatePolicyPage createpolicypage = new CreatePolicyPage();

            string newname = "Test Policy Name ";
            string descriptiontext = "This is a Description for: ";

            var randomSpecPolicyName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecPolicyName"] = randomSpecPolicyName;
            managepoliciespage.CreatePolicyButton.Click();
            Thread.Sleep(2000);
            createpolicypage.PolicyName.SendKeys(randomSpecPolicyName);
            createpolicypage.PolicyDescription.SendKeys(descriptiontext + randomSpecPolicyName);
            createpolicypage.SavePolicy.Click();
            Thread.Sleep(2000);
            var specPolicyName = ScenarioContext.Current["SpecPolicyName"];
            string specPolicyCreated = specPolicyName.ToString();
            Console.WriteLine(specPolicyCreated + " has been created successfully");
            Thread.Sleep(1000);

        }

    }
}
