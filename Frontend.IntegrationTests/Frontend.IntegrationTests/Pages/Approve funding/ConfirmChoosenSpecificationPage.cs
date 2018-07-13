using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ConfirmChoosenSpecificationPage
    {
        public ConfirmChoosenSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "confirm-button")]
        public IWebElement confirmChoosenSpecConfirmButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back - do not choose")]
        public IWebElement confirmChoosenSpecBackButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".heading-large")]
        public IWebElement confirmChoosenSpecHeading { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".confirm-select-fundingstreams-container")]
        public IWebElement confirmChoosenSpecFundingStreams { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(2) > div:nth-child(1)")]
        public IWebElement confirmChoosenSpecWarningMessage { get; set; }






    }
}
