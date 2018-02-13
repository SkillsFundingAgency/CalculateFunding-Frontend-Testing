using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    class PublishResultsPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://esfacfsftest-web.azurewebsites.net/results/publish";

        public PublishResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static PublishResultsPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new PublishResultsPage(driver);
        }

    }

}