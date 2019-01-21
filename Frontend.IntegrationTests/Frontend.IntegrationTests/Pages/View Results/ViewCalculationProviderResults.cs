using System;
using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewCalculationProviderResults
    {
        public ViewCalculationProviderResults()
        {
            PageFactory.InitElements(Driver._driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > strong:nth-child(4)")]
        public IWebElement viewcalculationProviderTotalResultcount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.providers-searchresult-container:nth-child(1) > div:nth-child(1) > div:nth-child(1) > strong:nth-child(1) > span:nth-child(1)")]
        public IWebElement viewcalculationFirstProviderTotalValue { get; set; }
    }
}
