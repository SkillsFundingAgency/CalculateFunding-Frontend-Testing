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

        [FindsBy(How = How.LinkText, Using = "Create Policy")]
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

        [FindsBy(How = How.LinkText, Using = "Choose data type relationship")]
        public IWebElement Createdatatyperelationship { get; set; }

        [FindsBy(How = How.LinkText, Using = ".policy-list-header")]
        public IWebElement PolicyList { get; set; }

        [FindsBy(How = How.LinkText, Using = " .calculation-table > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1)")]
        public IWebElement CalculationList { get; set; }

        [FindsBy(How = How.LinkText, Using = " .subpolicy-list-header")]
        public IWebElement SubPolicyList { get; set; }
    }
}



