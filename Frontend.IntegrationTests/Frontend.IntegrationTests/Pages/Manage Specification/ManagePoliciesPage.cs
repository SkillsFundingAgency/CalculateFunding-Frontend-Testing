using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    public class ManagePoliciesPage
    {
        public ManagePoliciesPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create policy")]
        public IWebElement CreatePolicyButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "No policies exists, create a policy")]
        public IWebElement NoPoliciesCreatePolicyLink { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Open All")]
        public IWebElement OpenAllPolicies { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "What is")]
        public IWebElement SaveSpecification { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create sub policy")]
        public IWebElement CreateSubPolicy { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create calculation specification")]
        public IWebElement CreateCalculation { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create dataset")]
        public IWebElement Createdatatyperelationship { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".policy-list")]
        public IWebElement PolicyList { get; set; }

        [FindsBy(How = How.CssSelector, Using = " .calculation-table > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1)")]
        public IWebElement CalculationList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".subpolicy-list-header")]
        public IWebElement SubPolicyList { get; set; }

        [FindsBy(How = How.Id, Using = "nav-dataset-tab")]
        public IWebElement datasetsTab { get; set; }

        [FindsBy(How = How.LinkText, Using = "No datasets exist, create a dataset")]
        public IWebElement datasetsTabNoDatasetsExistLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".provider-datasets-warning-container")]
        public IWebElement providerdatasetswarningcontainer { get; set; }



    }
}



