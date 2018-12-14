using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    public class ManageSpecificationPage
    {
        public ManageSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "div.col-xs-2:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement SelectYear { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".banner-floating-link-container > a:nth-child(1)")]
        public IWebElement CreateSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "specifications-table")]
        public IWebElement SpecificationList { get; set; }

        [FindsBy(How = How.Id, Using = "create-specification-button-noneexists")]
        public IWebElement NoSpecificationsToDisplay { get; set; }

        [FindsBy(How = How.ClassName, Using = "selected")]
        public IWebElement DefaultYear { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Test Spec")]
        public IWebElement SelectSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement SearchSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement SearchSpecificationButton { get; set; }

        [FindsBy(How = How.Id, Using = "table-filter-header")]
        public IWebElement SpecificationFilterContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#table-filter-header > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement SpecificationFundingStreamsFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-2:nth-child(3)")]
        public IWebElement SpecificationStatusFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-2:nth-child(4) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement SpecificationClearFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#totalResultsCount")]
        public IWebElement SpecificationListTotalResultCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-container:nth-child(2)")]
        public IWebElement SpecificationListExpandContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(4) > i:nth-child(1)")]
        public IWebElement SpecificationListMoreOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement SpecificationListFirstEditDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(3) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement SpecificationListSecondEditDate { get; set; }

    }
}
