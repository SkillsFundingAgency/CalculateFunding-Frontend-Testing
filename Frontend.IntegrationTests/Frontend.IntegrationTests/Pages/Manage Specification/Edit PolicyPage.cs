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
    public class EditPolicyPage
    {
        public EditPolicyPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "EditPolicyViewModel-Name")]
        public IWebElement editPolicyName { get; set; }

        [FindsBy(How = How.Id, Using = "EditPolicyViewModel-Description")]
        public IWebElement editPolicyDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".button")]
        public IWebElement editPolicyUpdateButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back")]
        public IWebElement editPolicyBackLink { get; set; }

    }
}
