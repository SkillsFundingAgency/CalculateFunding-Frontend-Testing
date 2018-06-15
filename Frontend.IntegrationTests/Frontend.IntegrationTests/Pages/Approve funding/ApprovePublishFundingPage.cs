using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ApprovePublishFundingPage
    {
        public ApprovePublishFundingPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "specificationId")]
        public IWebElement approvePublishFundingSpecDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".noresults-panel")]
        public IWebElement approvePublishFundingNoResultsPanel { get; set; }

        [FindsBy(How = How.Id, Using = "selectAll")]
        public IWebElement approvePublishFundingSelectAll { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#approve")]
        public IWebElement approvePublishFundingApprove { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#publish")]
        public IWebElement approvePublishFundingPublish { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf")]
        public IWebElement approvePublishFundingProviderContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > thead:nth-child(1)")]
        public IWebElement approvePublishFundingProviderHeaders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1)")]
        public IWebElement approvePublishFundingFirstProviderRow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(1) > label:nth-child(2)")]
        public IWebElement approvePublishFundingFirstProviderName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(2)")]
        public IWebElement approvePublishFundingFirstProviderUKPRN { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(3)")]
        public IWebElement approvePublishFundingFirstProviderAllocStatusHeld { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.status-approved:nth-child(4)")]
        public IWebElement approvePublishFundingFirstProviderAllocStatusApproved { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(5)")]
        public IWebElement approvePublishFundingFirstProviderAllocStatusPublished { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(6) > span:nth-child(1)")]
        public IWebElement approvePublishFundingFirstProviderAllocStatusLastUpdated { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(7)")]
        public IWebElement approvePublishFundingFirstProviderSpecFundingAmt { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-trigger-container:nth-child(1) > td:nth-child(8)")]
        public IWebElement approvePublishFundingFirstProviderExpansionOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.expander-container:nth-child(2) > td:nth-child(1) > span:nth-child(3)")]
        public IWebElement approvePublishFundingFirstProviderQATestInfo { get; set; }

        












    }
}
