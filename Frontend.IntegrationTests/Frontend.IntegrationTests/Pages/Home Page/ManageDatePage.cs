using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    public class ManageDatePage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://esfacfsftest-web.azurewebsites.net/data";

        public ManageDatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static ManageDatePage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new ManageDatePage(driver);
        }

    }


}
