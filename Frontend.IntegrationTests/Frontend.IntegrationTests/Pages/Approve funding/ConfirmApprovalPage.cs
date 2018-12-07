using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ConfirmApprovalPage
    {
        public ConfirmApprovalPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".confirmapproval-buttons > button:nth-child(1)")]
        public IWebElement confirmApprovalButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".heading-large")]
        public IWebElement confirmApprovalPageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "confirmapproval-page-container")]
        public IWebElement confirmApprovalPageCaontainer { get; set; }

    }
}