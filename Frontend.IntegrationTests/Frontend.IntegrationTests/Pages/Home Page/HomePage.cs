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

    [FindsBy(How = How.LinkText, Using = "Quality assurance")]
    public IWebElement ManagetheTests { get; set; }

    [FindsBy(How = How.LinkText, Using = "Calculations")]
    public IWebElement ManagetheCalculations { get; set; }

    [FindsBy(How = How.LinkText, Using = "View results")]
    public IWebElement ViewtheResults { get; set; }

    [FindsBy(How = How.LinkText, Using = "Release funding")]
    public IWebElement Publishtheresults { get; set; }
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

