using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Calculation
{
    public class CompareCalculationsPage
    {
        public CompareCalculationsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "inLineCodeEditor")]
        public IWebElement inlineCodeEditor { get; set; }

        [FindsBy(How = How.Id, Using = "back-link")]
        public IWebElement compareCalculationsBackLink { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-diff-viewer")]
        public IWebElement inlineCodeEditorTextArea { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-left > span:nth-child(2)")]
        public IWebElement leftinlineCodeEditorAuthor { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-right > span:nth-child(2)")]
        public IWebElement rightInlineCodeEditorAuthor { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-left > span:nth-child(3)")]
        public IWebElement leftInlineCodeEditorDateTime { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-right > span:nth-child(3)")]
        public IWebElement rightInlineCodeEditorDateTime { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-left-status")]
        public IWebElement leftInlineCodeEditorStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".diff-right-status")]
        public IWebElement rightInlineCodeEditorStatus { get; set; }





    }


    }

