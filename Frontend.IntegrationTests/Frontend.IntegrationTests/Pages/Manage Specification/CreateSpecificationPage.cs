﻿using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    public class CreateSpecificationPage
    {
        public CreateSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "CreateSpecificationViewModel-Name")]
        public IWebElement SpecName { get; set; }

        [FindsBy(How = How.Id, Using = "CreateSpecificationViewModel-Description")]
        public IWebElement SpecDescription { get; set; }

        [FindsBy(How = How.Id, Using = "CreateSpecificationViewModel-FundingStreamId")]
        public IWebElement FundingStream { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement SaveSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement CancelSpecification { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-CreateSpecificationViewModel-Name")]
        public IWebElement SpecNameError { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must give a unique specification name")]
        public IWebElement SpecNameErrorText { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must select at least one funding stream")]
        public IWebElement SpecFundingErrorText { get; set; }

        [FindsBy(How = How.LinkText, Using = "You must give a description for the specification")]
        public IWebElement SpecDescriptionErrorText { get; set; }
    }
}



/*
{
    private readonly IWebDriver _driver;
    private const string PageUri = @"https://esfacfsftest-web.azurewebsites.net/specs/createSpecification/1819";

    public CreateSpecificationPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public static CreateSpecificationPage NavigateTo(IWebDriver driver)
    {
        driver.Navigate().GoToUrl(PageUri);

        return new CreateSpecificationPage(driver);
    }

}

}
*/