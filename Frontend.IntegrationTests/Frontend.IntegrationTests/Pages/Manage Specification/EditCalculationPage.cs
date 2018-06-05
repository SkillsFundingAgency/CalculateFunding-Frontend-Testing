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
    public class EditCalculationPage
    {
        public EditCalculationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "EditCalculationViewModel-Name")]
        public IWebElement editCalculationName { get; set; }

        [FindsBy(How = How.Id, Using = "EditCalculationViewModel-Description")]
        public IWebElement editCalculationDescription { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement editCalculationSave { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement editCalculationCancel { get; set; }

        [FindsBy(How = How.Id, Using = "EditCalculationViewModel-PolicyId")]
        public IWebElement editCalculationPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "CalculationTypes")]
        public IWebElement editCalculationCalculationType { get; set; }

        [FindsBy(How = How.Id, Using = "AllocationLines")]
        public IWebElement editCalculationAllocationLine { get; set; }



    }
}
