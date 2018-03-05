using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class ManageTheDataPage
    {
        public ManageTheDataPage()
        {
        PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.col-sm-4:nth-child(1) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement manageDataSetsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-sm-4:nth-child(1) > div:nth-child(2)")]
        public IWebElement manageDataSetsDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(2) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement specifyDataSetRelationshipLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(2) > div:nth-child(2)")]
        public IWebElement specifyDataSetRelationshipDescription { get; set; }




    }
}
