using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    public class CreatePolicyPage
    {
        public CreatePolicyPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "CreatePolicyViewModel-Name")]
        public IWebElement PolicyName { get; set; }

        [FindsBy(How = How.Id, Using = "contents")]
        public IWebElement PolicyDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div/form/p/button")]
        public IWebElement SavePolicy { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back")]
        public IWebElement CancelPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreatePolicyViewModel-Description")]
        public IWebElement PolicyDescriptionErrorText { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreatePolicyViewModel-Name")]
        public IWebElement PolicyNameErrorText { get; set; }

    }
}
