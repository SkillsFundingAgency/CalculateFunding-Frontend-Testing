using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    class CreateCalculationPage
    { 
        public CreateCalculationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "CreateCalculationViewModel-Name")]
        public IWebElement CalculationName { get; set; }

        [FindsBy(How = How.Id, Using = "CreateCalculationViewModel-Description")]
        public IWebElement CalculationDescription { get; set; }

        [FindsBy(How = How.Id, Using = "CreateCalculationViewModel-PolicyId")]
        public IWebElement SelectPolicy_SubPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "AllocationLines")]
        public IWebElement CalculationAllocationLine { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement SaveCalculation { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement CancelCalculation { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must give a unique calculation name")]
        public IWebElement CalculationNameError { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must select a policy or subpolicy")]
        public IWebElement CalculationPolicyError { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must select an allocation line")]
        public IWebElement CalculationAllocationError { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must give a description for the calculation")]
        public IWebElement CalculationDescriptionError { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must select a calculation type")]
        public IWebElement CalculationTypeError { get; set; }
        
        [FindsBy(How = How.Id, Using = "CalculationTypes")]
        public IWebElement CalculationTypeDropDown { get; set; }


    }
}

