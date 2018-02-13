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
    class ManageCalcPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://esfacfsftest-web.azurewebsites.net/calcs";

        public ManageCalcPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static ManageCalcPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new ManageCalcPage(driver);
        }

    }

}