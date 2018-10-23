using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Home_Page
{
    public class MSDfESignInPage
    {
        public MSDfESignInPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.tile:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement msUserSelection { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#i0116")]
        public IWebElement msUserInput { get; set; }

        [FindsBy(How = How.Id, Using = "idSIButton9")]
        public IWebElement msUserNext { get; set; }

    }
}
