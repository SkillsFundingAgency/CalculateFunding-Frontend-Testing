
using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ConfirmPublishPage
    {
        public ConfirmPublishPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "publish")]
        public IWebElement confirmPublishButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".heading-large")]
        public IWebElement confirmPublishPageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "confirmpublish-page-container")]
        public IWebElement confirmPublishPageCaontainer { get; set; }



    }
}