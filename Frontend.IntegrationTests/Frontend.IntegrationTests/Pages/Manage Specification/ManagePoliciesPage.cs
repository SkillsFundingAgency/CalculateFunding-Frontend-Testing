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

        [FindsBy(How = How.LinkText, Using = "Create subpolicy")]
        public IWebElement CreateSubPolicy { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create calculation specification")]
        public IWebElement CreateCalculation { get; set; }

        [FindsBy(How = How.LinkText, Using = "No datasets exist, create a dataset")]
        public IWebElement Createdatatyperelationship { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf")]
        public IWebElement PolicyList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.data-policy-container:nth-child(1)")]
        public IWebElement PolicyRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = " .calculation-table > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1)")]
        public IWebElement CalculationList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "cf.tr.cr-table-primary-highlight:nth-child(3)")]
        public IWebElement SubPolicyList { get; set; }

        [FindsBy(How = How.Id, Using = "nav-dataset-tab")]
        public IWebElement datasetsTab { get; set; }

        [FindsBy(How = How.LinkText, Using = "No datasets exist, create a dataset")]
        public IWebElement datasetsTabNoDatasetsExistLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".provider-datasets-warning-container")]
        public IWebElement providerdatasetswarningcontainer { get; set; }

        [FindsBy(How = How.LinkText, Using = "Edit specification")]
        public IWebElement editSpecification { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-title")]
        public IWebElement specificationName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-description")]
        public IWebElement specificationFundingPeriod { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".notification-panel-text")]
        public IWebElement editNotificationPanel { get; set; }

        [FindsBy(How = How.Id, Using = "policy-jump")]
        public IWebElement policyjump { get; set; }

        [FindsBy(How = How.Id, Using = "expandCollapseAll")]
        public IWebElement expandCollapseAll { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.data-policy-container:nth-child(1) > td:nth-child(6) > i:nth-child(1)")]
        public IWebElement firstMoreOption { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "tr.cr-table-primary-highlight:nth-child(2)")]
        public IWebElement firstFullDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.expander-trigger-cell:nth-child(7) > i:nth-child(1)")]
        public IWebElement firstCalcMoreOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.cr-table-primary-highlight:nth-child(4) > td:nth-child(2)")]
        public IWebElement firstCalcFullDescription { get; set; }

        [FindsBy(How = How.Id, Using = "approve-status")]
        public IWebElement approveSpecification { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn:nth-child(2)")]
        public IWebElement approveDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".dropdown-menu")]
        public IWebElement publishMenu { get; set; }

        [FindsBy(How = How.LinkText, Using = "View calculation code")]
        public IWebElement viewCalculationLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Map data source file to data set")]
        public IWebElement viewMapDataSourceLink { get; set; }


    }
}



