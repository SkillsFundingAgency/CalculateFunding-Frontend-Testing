using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Quality_Assurance
{
    public class CreateQATestPage
    {
        public CreateQATestPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "CreateTestScenarioModel-Name")]
        public IWebElement createQATestName { get; set; }

        [FindsBy(How = How.Id, Using = "CreateTestScenarioModel-Description")]
        public IWebElement createQATestDescription { get; set; }

        [FindsBy(How = How.Id, Using = "monacoeditor")]
        public IWebElement createQATestScenario { get; set; }
        
        [FindsBy(How = How.Id, Using = "select-specifications")]
        public IWebElement createQATestSelectSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "appr-button")]
        public IWebElement createQATestApproveQATestButton { get; set; }

        [FindsBy(How = How.Id, Using = "validate-qa-test-button")]
        public IWebElement createQATestValidateQATestButton { get; set; }

        [FindsBy(How = How.Id, Using = "create-test-button")]
        public IWebElement createQATestCreateQATestButton { get; set; }

        [FindsBy(How = How.Id, Using = "link-back")]
        public IWebElement createQATestBackButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".build-output")]
        public IWebElement createQATestBuildOutputWindow { get; set; }
        
        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div/form/div[5]/div[2]/div/div[1]/textarea")]
        public IWebElement createQATestBuildMonacoEditorTextbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".build-output > div:nth-child(1)")]
        public IWebElement createQATestBuildBuildOutputText { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateTestScenarioModel-Name")]
        public IWebElement createQATestMissingNameError { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateTestScenarioModel-Description")]
        public IWebElement createQATestMissingDescriptionError { get; set; }



    }
}
