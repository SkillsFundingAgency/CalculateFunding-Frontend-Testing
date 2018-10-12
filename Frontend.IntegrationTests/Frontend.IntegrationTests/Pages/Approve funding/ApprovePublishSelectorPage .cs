using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ApprovePublishSelectorPage
    {
        public ApprovePublishSelectorPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "fundingperiod")]
        public IWebElement approvePublishSelectorFundingPeriodDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "specification")]
        public IWebElement approvePublishSelectorSpecificationDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "fundingstreams")]
        public IWebElement approvePublishSelectorFundingStreamsDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "ViewFunding")]
        public IWebElement approvePublishSelectorViewFundingButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".material-icons-content-container")]
        public IWebElement approvePublishSelectorWarning { get; set; }

    }
}
