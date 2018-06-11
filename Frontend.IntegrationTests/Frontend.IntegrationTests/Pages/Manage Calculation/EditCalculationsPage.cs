using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Calculation
{
    public class EditCalculationsPage
    {
        public EditCalculationsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "build-calculation-button")]
        public IWebElement BuildCalculationButton { get; set; }

        [FindsBy(How = How.Id, Using = "save-calculation-button")]
        public IWebElement SaveCalculationButton { get; set; }

        [FindsBy(How = How.Id, Using = "link-back")]
        public IWebElement BackCalculationLink { get; set; }

        [FindsBy(How = How.Id, Using = "view-previous-versions-button")]
        public IWebElement PreviousCalculationVersionsLink { get; set; }

        [FindsBy(How = How.Id, Using = "publish-button")]
        public IWebElement PublishCalculationButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".build-output")]
        public IWebElement CalculationBuildOutput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inline-collapse-heading > span:nth-child(2)")]
        public IWebElement CalculationSpecDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-title")]
        public IWebElement CalculationSpecName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".bannerpublish-status > strong:nth-child(1)")]
        public IWebElement CalculationStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.monaco-editor:nth-child(1)")]
        public IWebElement CalculationVBEditor { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div/div[1]/div/div[1]/textarea")]
        public IWebElement CalculationVBTextEditor { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".compiler-messages")]
        public IWebElement CalculationCompilierMessage { get; set; }

        [FindsBy(How = How.Id, Using = "approve-button-container")]
        public IWebElement ApproveCalculationContainer { get; set; }











    }
}
