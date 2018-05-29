using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    class EditSpecificationPage
    {
        public EditSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "EditSpecificationViewModel-Name")]
        public IWebElement editSpecificationName { get; set; }

        [FindsBy(How = How.Id, Using = "EditSpecificationViewModel-Description")]
        public IWebElement editSpecificationDescription { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement editSpecificationSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement editSpecificationCancelLink { get; set; }

        [FindsBy(How = How.Id, Using = "EditSpecificationViewModel-FundingPeriodId")]
        public IWebElement editSpecificationFundingPeriodDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-selection__choice__remove")]
        public IWebElement editSpecificationFundingStreamRemove { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert")]
        public IWebElement editSpecificationFundingStreamRemovedAlert { get; set; }

        [FindsBy(How = How.Id, Using = "EditSpecificationViewModel-FundingStreamIds")]
        public IWebElement editSpecificationFundingStreamContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-selection")]
        public IWebElement editSpecificationFundingStream { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-search__field")]
        public IWebElement editSpecFundingStreamTextField { get; set; }






    }
}
