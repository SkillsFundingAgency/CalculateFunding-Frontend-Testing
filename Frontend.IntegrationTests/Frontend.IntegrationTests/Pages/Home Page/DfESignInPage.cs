using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Home_Page
{
    public class DfESignInPage
    {
        public DfESignInPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "userNameInput")]
        public IWebElement userNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "passwordInput")]
        public IWebElement passwordInput { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        public IWebElement submitButton { get; set; }

        [FindsBy(How = How.Id, Using = "errorText")]
        public IWebElement loginError { get; set; }
    }
}
