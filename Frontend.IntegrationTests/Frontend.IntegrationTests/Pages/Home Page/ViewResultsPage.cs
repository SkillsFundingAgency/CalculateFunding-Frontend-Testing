using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    class ViewResultsPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://esfacfsfTest-web.azurewebsites.net/results/index";

        public ViewResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static ViewResultsPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new ViewResultsPage(driver);
        }

    }

}