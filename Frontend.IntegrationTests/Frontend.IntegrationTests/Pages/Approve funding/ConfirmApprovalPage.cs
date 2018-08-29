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

        [FindsBy(How = How.Id, Using = "approve")]
        public IWebElement confirmApprovalButton { get; set; }
    }
}