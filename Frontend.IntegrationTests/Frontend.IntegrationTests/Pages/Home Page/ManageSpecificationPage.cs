using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages
{
    public class ManageSpecificationPage
    {
        public ManageSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "select-spec-year")]
        public IWebElement SelectYear { get; set; }

        [FindsBy(How = How.Id, Using = "create-specification-button")]
        public IWebElement CreateSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "esfa-list")]
        public IWebElement SpecificationList { get; set; }

        [FindsBy(How = How.Id, Using = "create-specification-button-noneexists")]
        public IWebElement NoSpecificationsToDisplay { get; set; }

        [FindsBy(How = How.ClassName, Using = "selected")]
        public IWebElement DefaultYear { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Test Spec")]
        public IWebElement SelectSpecification { get; set; }

    } 
}
