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
    class CreateSubPolicyPage
    {
        public CreateSubPolicyPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "CreateSubPolicyViewModel-Name")]
        public IWebElement SubPolicyName { get; set; }

        [FindsBy(How = How.Id, Using = "CreateSubPolicyViewModel-Description")]
        public IWebElement SubPolicyDescription { get; set; }

        [FindsBy(How = How.Id, Using = "CreateSubPolicyViewModel-ParentPolicyId")]
        public IWebElement SelectPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement SaveSubPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement CancelSubPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateSubPolicyViewModel-Name")]
        public IWebElement SubPolicyMissingNameErrorText { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateSubPolicyViewModel-ParentPolicyId")]
        public IWebElement SubPolicyMissingPolicyErrorText { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateSubPolicyViewModel-Description")]
        public IWebElement SubPolicyMissingDescriptionErrorText { get; set; }
    }
}

