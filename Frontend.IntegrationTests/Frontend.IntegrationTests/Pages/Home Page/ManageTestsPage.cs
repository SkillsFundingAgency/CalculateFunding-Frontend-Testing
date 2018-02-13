using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    class ManageTestsPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://esfacfsftest-web.azurewebsites.net/tests/manage";

        public ManageTestsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static ManageTestsPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new ManageTestsPage(driver);
        }

    }

}
