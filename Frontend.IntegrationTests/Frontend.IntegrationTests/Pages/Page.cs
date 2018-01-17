using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Frontend.IntegrationTests
{
    public abstract class BasePage
    {
        protected IWebDriver WebDriver;

        protected BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }


    }
}
