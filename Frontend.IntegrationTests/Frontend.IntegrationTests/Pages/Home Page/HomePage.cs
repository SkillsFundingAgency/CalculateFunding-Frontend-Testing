using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests
{
    public class HomePage

    {
        public HomePage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "proposition-name")]
        public IWebElement Header { get; set; }

        [FindsBy(How = How.LinkText, Using = "Specifications")]
        public IWebElement ManagetheSpecification { get; set; }

        [FindsBy(How = How.LinkText, Using = "Manage data")]
        public IWebElement ManagetheData { get; set; }

        [FindsBy(How = How.LinkText, Using = "Quality assurance tests")]
        public IWebElement ManagetheTests { get; set; }

        [FindsBy(How = How.LinkText, Using = "Calculations")]
        public IWebElement ManagetheCalculations { get; set; }

        [FindsBy(How = How.LinkText, Using = "View results")]
        public IWebElement ViewtheResults { get; set; }

        [FindsBy(How = How.LinkText, Using = "Funding approvals")]
        public IWebElement Publishtheresults { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".govuk-beta-label > span:nth-child(1) > a:nth-child(1)")]
        public IWebElement SurveyText { get; set; }

        [FindsBy(How = How.LinkText, Using = "help us improve the service")]
        public IWebElement SurveyLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".user-container > span:nth-child(2)")]
        public IWebElement userContainer { get; set; }

    }
}

/*
    public abstract class BasePage
    {
        public IWebDriver WebDriver;
        public const string PageUri = @"https://esfacfsftest-web.azurewebsites.net";
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
           
        }
        public static HomePage Navigateto(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new HomePage(driver);
        }
    */

