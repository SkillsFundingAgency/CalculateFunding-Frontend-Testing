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
        public static class ManageSpecificationCreateNewSubPolicy
        {

            public static void CreateANewSpecificationSubPolicy()

            {
                ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
                CreateSubPolicyPage createsubpolicypage = new CreateSubPolicyPage();

                string newname = "Test Sub Policy Name ";
                string descriptiontext = "This is a Description for: ";

                var randomSpecSubPolicyName = newname + TestDataUtils.RandomString(6);
                ScenarioContext.Current["SpecSubPolicyName"] = randomSpecSubPolicyName;
                managepoliciespage.CreateSubPolicy.Click();
                Thread.Sleep(2000);
                createsubpolicypage.SubPolicyName.SendKeys(randomSpecSubPolicyName);
                Actions.SelectPolicyForSubPolicyCreationDropdownOption();
                createsubpolicypage.SubPolicyDescription.Click();
                Thread.Sleep(2000);
                createsubpolicypage.SubPolicyDescription.SendKeys(descriptiontext + randomSpecSubPolicyName);
                createsubpolicypage.SaveSubPolicy.Click();
                Thread.Sleep(2000);
                var specPolicyName = ScenarioContext.Current["SpecSubPolicyName"];
                string specSubPolicyCreated = specPolicyName.ToString();
                Console.WriteLine(specSubPolicyCreated + " has been created successfully");
                Thread.Sleep(1000);

            }

        }
    }

