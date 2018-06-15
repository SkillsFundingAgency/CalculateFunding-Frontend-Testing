using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages.Home_Page
{
    public class ApprovalOptionsPage
    {
        public ApprovalOptionsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.col-sm-4:nth-child(1) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement ChooseFundingSpecification { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(2) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement ApprovePublishFunding { get; set; }

        [FindsBy(How = How.CssSelector, Using = "head > title:nth-child(6)")]
        public IWebElement PageTitle { get; set; }

    }
}
