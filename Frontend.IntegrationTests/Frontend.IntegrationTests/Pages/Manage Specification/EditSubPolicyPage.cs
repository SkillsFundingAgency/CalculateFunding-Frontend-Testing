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
    public class EditSubPolicyPage
    {
        public EditSubPolicyPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "EditSubPolicyViewModel-Name")]
        public IWebElement editSubPolicyName { get; set; }

        [FindsBy(How = How.Id, Using = "EditSubPolicyViewModel-Description")]
        public IWebElement editSubPolicyDesc { get; set; }

        [FindsBy(How = How.Id, Using = "EditSubPolicyViewModel-Description")]
        public IWebElement editSubPolicyUpdateButton { get; set; }

        [FindsBy(How = How.Id, Using = "EditSubPolicyViewModel-Description")]
        public IWebElement editSubPolicyBackLink { get; set; }

        [FindsBy(How = How.Id, Using = "EditSubPolicyViewModel-ParentPolicyId")]
        public IWebElement editSubPolicyPolicyDropdown { get; set; }

    }
}

