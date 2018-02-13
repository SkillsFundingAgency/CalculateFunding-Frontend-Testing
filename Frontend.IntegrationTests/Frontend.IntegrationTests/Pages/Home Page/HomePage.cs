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

    [FindsBy(How = How.LinkText, Using = "Manage the Specification")]
    public IWebElement ManagetheSpecification { get; set; }

    [FindsBy(How = How.LinkText, Using = "Manage the Data")]
    public IWebElement ManagetheData { get; set; }

    [FindsBy(How = How.LinkText, Using = "Manage the tests")]
    public IWebElement ManagetheTests { get; set; }

    [FindsBy(How = How.LinkText, Using = "Manage the Calculations")]
    public IWebElement ManagetheCalculations { get; set; }

    [FindsBy(How = How.LinkText, Using = "View the Results")]
    public IWebElement ViewtheResults { get; set; }

    [FindsBy(How = How.LinkText, Using = "Publish the results")]
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

