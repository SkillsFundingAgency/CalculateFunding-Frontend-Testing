using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using System.Threading;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Create
{

    [Binding]
    public static class CreateDataSourceMapping
    {
        public static void CreateADataSourceMapping()

        {
            HomePage homepage = new HomePage();
            SelectedSpecificationDataSourcePage selectedspecificationdatasourcepage = new SelectedSpecificationDataSourcePage();
            SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();
            MapDataSourcesToDatasetsPage mapdatasourcestodatasetpage = new MapDataSourcesToDatasetsPage();

            homepage.Header.Click();
            Thread.Sleep(2000);

            NavigateTo.MapDataSourcesToDatasetsPage();
            Thread.Sleep(2000);

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            string specCreatedID = specName.ToString().Replace("Test Spec Name ","");

            var selectYear = mapdatasourcestodatasetpage.mapDataSourcesSpecficationYearDropDown;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1819");
            Thread.Sleep(2000);

            mapdatasourcestodatasetpage.mapDataSourcesSearchTermField.SendKeys(specCreatedID);
            mapdatasourcestodatasetpage.mapDataSourcesSearchTermButton.Click();
            Thread.Sleep(4000);

            Actions.MapDataSourcesToDatasetsForSpecification();
            Thread.Sleep(2000);
            selectedspecificationdatasourcepage.specificationDataSourceCount.Should().NotBeNull();

            selectedspecificationdatasourcepage.specificationDataSourceMissing.Click();
            Thread.Sleep(2000);
            selectsourcedatasetspage.selectSourceDatasetSaveButton.Should().NotBeNull();

            Actions.SelectSourceDatasetsRadioOption();
            Thread.Sleep(2000);
            Actions.SelectSourceDatasetVersionRadioOption();
            Thread.Sleep(2000);
            selectsourcedatasetspage.selectSourceDatasetSaveButton.Click();
            Thread.Sleep(2000);

            selectedspecificationdatasourcepage.specificationDataSourceMissing.Should().NotBeNull();
            selectedspecificationdatasourcepage.specificationDataSourceAddedAlert.Displayed.Should().BeTrue();
            Thread.Sleep(5000);

        }


    }
}
