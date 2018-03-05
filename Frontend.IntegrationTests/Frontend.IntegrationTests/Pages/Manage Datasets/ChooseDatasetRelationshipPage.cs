﻿using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class ChooseDatasetRelationshipPage
    {
        public ChooseDatasetRelationshipPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".select2-selection")]
        public IWebElement selectDatasetSchemaDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "datasetSchemaName")]
        public IWebElement datasetSchemaRelationshipName { get; set; }

        [FindsBy(How = How.Id, Using = "contents")]
        public IWebElement datasetSchemaRelationshipDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".button")]
        public IWebElement datasetSchemaRelationshipSaveButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".form-submit-container > a:nth-child(2)")]
        public IWebElement datasetSchemaRelationshipCancelLink { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-AssignDatasetSchemaViewModel-DatasetDefinitionId")]
        public IWebElement createDatasetDatasetSchemaRelationshipError { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-AssignDatasetSchemaViewModel-Name")]
        public IWebElement createDatasetDatasetNameError { get; set; }

        [FindsBy(How = How.Id, Using = "validation-link-for-AssignDatasetSchemaViewModel-Description")]
        public IWebElement createDatasetDatasetDescriptionError { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-search__field")]
        public IWebElement selectDatasetSchemaDropDownTextSearch { get; set; }

    }
}
