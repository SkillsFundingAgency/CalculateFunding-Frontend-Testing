using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Quality_Assurance
{
    public class EditQATestPage
    {
        public EditQATestPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "EditScenarioViewModel-Name")]
        public IWebElement editQATestName { get; set; }

        [FindsBy(How = How.Id, Using = "EditScenarioViewModel-Description")]
        public IWebElement editQATestDescription { get; set; }

        [FindsBy(How = How.Id, Using = "validate-qa-test-button")]
        public IWebElement editQATestValidateButton { get; set; }

        [FindsBy(How = How.Id, Using = "save-test-button")]
        public IWebElement editQATestSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "link-back")]
        public IWebElement editQATestBackLink { get; set; }

        [FindsBy(How = How.Id, Using = "monacoeditor")]
        public IWebElement editQATestMonacoEditorConatiner { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div/form/div[5]/div[2]/div/div[1]/textarea")]
        public IWebElement editQATestMonacoEditorTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(2) > div:nth-child(1)")]
        public IWebElement editQATestAssocSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "SaveStatus")]
        public IWebElement editQATestSavedAlert { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".build-output > div:nth-child(1)")]
        public IWebElement editQATestBuildOutputText { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-EditTestScenarioModel-Name")]
        public IWebElement editQATestNameError { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-EditTestScenarioModel-Description")]
        public IWebElement editQATestDescriptionError { get; set; }







    }
}
