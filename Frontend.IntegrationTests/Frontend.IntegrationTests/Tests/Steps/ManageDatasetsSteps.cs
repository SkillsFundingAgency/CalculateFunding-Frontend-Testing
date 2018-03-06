using System;
using System.Globalization;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ManageDatasetsSteps
    {
        ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
        ManageDatasetsPage managedatasetpage = new ManageDatasetsPage();
        ManageTheDataPage managethedatapage = new ManageTheDataPage();
        SpecifyDatasetRelationshipsPage specifyDatasetRelationshippage = new SpecifyDatasetRelationshipsPage();
        LoadNewDatasetPage loadnewdatasetpage = new LoadNewDatasetPage();
        ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();
        MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();
        SelectedSpecificationDataSourcePage selectedspecificationdatasourcepage = new SelectedSpecificationDataSourcePage();

        public string newname = "Test Name 008";
        public string descriptiontext = "This is a Description";
        public static int? totalresults = null;


        [Given(@"I have navigated to the data management option from the service home page")]
        public void GivenIHaveNavigatedToTheDataManagementOptionFromTheServiceHomePage()
        {
            NavigateTo.ManageTheDataPage();
            managethedatapage.manageDataSetsLink.Should().NotBeNull();
        }

        [When(@"I click on the Manage data sets option")]
        public void WhenIClickOnTheManageDataSetsOption()
        {
            managethedatapage.manageDataSetsLink.Click();
        }

        [When(@"I click on the specify data source relationships option")]
        public void WhenIClickOnTheSpecifyDataSourceRelationshipsOption()
        {
            managethedatapage.specifyDataSetRelationshipLink.Click();
        }

        [Then(@"I am presented the Manage Datasets option")]
        public void ThenIAmPresentedTheManageDatasetsOption()
        {
            managethedatapage.manageDataSetsLink.Should().NotBeNull();
        }

        [Then(@"a description of the Manage Datasets option")]
        public void ThenADescriptionOfTheManageDatasetsOption()
        {
            managethedatapage.manageDataSetsDescription.Should().NotBeNull();
        }

        [Then(@"I am presented the Specify data source relationships option")]
        public void ThenIAmPresentedTheSpecifyDataSourceRelationshipsOption()
        {
            managethedatapage.specifyDataSetRelationshipLink.Should().NotBeNull();
        }

        [Then(@"a description of the Specify data source relationships option")]
        public void ThenADescriptionOfTheSpecifyDataSourceRelationshipsOption()
        {
            managethedatapage.specifyDataSetRelationshipDescription.Should().NotBeNull();
        }

        [Then(@"I am presented with the Manage Datasets page")]
        public void ThenIAmPresentedWithTheManageDatasetsPage()
        {
            managedatasetpage.manageDataSetsSearchField.Should().NotBeNull();
        }

        [Then(@"I am presented with the Specify data source relationships page")]
        public void ThenIAmPresentedWithTheSpecifyDataSourceRelationshipsPage()
        {
            specifyDatasetRelationshippage.specifyDatasetSearchField.Should().NotBeNull();
        }

        [Given(@"I have navigated to the Manage Datasets page")]
        public void GivenIHaveNavigatedToTheManageDatasetsPage()
        {
            NavigateTo.ManageDatasetsPage();
            Thread.Sleep(2000);
        }

        [Then(@"the page displays a list view of all data sets that have been uploaded")]
        public void ThenThePageDisplaysAListViewOfAllDataSetsThatHaveBeenUploaded()
        {
            managedatasetpage.manageDatasetsListView.Should().NotBeNull();
        }

        [Then(@"My list is in descending order from the most recent dataset")]
        public void ThenMyListIsInDescendingOrderFromTheMostRecentDataset()
        {
            IWebElement firstResultLastUpdated = managedatasetpage.manageDatasetsFirstResultLastUpdated;
            string firstResultUpdatedDate = firstResultLastUpdated.Text;
            DateTime firstUpdatedDate = DateTime.ParseExact(firstResultUpdatedDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            IWebElement secondResultLastUpdated = managedatasetpage.manageDatasetsSecondResultLastUpdated;
            string secondResultUpdatedDate = secondResultLastUpdated.Text;
            DateTime secondUpdatedDate = DateTime.ParseExact(secondResultUpdatedDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            firstUpdatedDate.Should().BeAfter(secondUpdatedDate, "Dataset List is Ordered Incorrectly");

        }

        [Then(@"the dataset name is displayed")]
        public void ThenTheDatasetNameIsDisplayed()
        {
            managedatasetpage.manageDatasetsFirstResultName.Should().NotBeNull();
        }

        [Then(@"the datasets current status is displayed")]
        public void ThenTheDatasetsCurrentStatusIsDisplayed()
        {
            managedatasetpage.manageDatasetsFirstResultStatus.Should().NotBeNull();
        }

        [Then(@"the datasets last Updated date is displayed")]
        public void ThenTheDatasetsLastUpdatedDateIsDisplayed()
        {
            managedatasetpage.manageDatasetsFirstResultLastUpdated.Should().NotBeNull();
        }

        [Then(@"my list shows up to (.*) data sets")]
        public void ThenMyListShowsUpToDataSets(int endResultListCount)
        {
            IWebElement endResultCount = managedatasetpage.manageDatasetsEndListItemCount;
            string endPageResultCount = endResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(endResultListCount, "More than 50 Results are displayed on this Page");
            Console.WriteLine("Total Page Results Displayed is " + endResultCount.Text);
        }

        [Then(@"a count of all data sets returned is displayed")]
        public void ThenACountOfAllDataSetsReturnedIsDisplayed()
        {
            managedatasetpage.manageDatasetsTotalResultCount.Should().NotBeNull();
            Console.WriteLine("Total Results Displayed is " + managedatasetpage.manageDatasetsTotalResultCount.Text);
        }

        [Then(@"a link to Load new datasets is displayed")]
        public void ThenALinkToLoadNewDatasetsIsDisplayed()
        {
            managedatasetpage.loadNewDatasetsButton.Should().NotBeNull();
        }

        [When(@"I click the Load a New Dataset button")]
        public void WhenIClickTheLoadANewDatasetButton()
        {
            managedatasetpage.loadNewDatasetsButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am navigated to the load New Dataset page")]
        public void ThenIAmNavigatedToTheLoadNewDatasetPage()
        {
            loadnewdatasetpage.loadDatasetName.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [Given(@"I have selected a valid specification from the Manage Specification page")]
        public void GivenIHaveSelectedAValidSpecificationFromTheManageSpecificationPage()
        {
            NavigateTo.ManagePolicies();
            Thread.Sleep(2000);
        }

        [When(@"I click the Create Dataset link")]
        public void WhenIclicktheCreateDatasetlink()
        {
            managepoliciespage.Createdatatyperelationship.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create dataset page")]
        public void ThenIAmRedirectedToTheCreatedatasetPage()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipName.Should().NotBeNull();
        }

        [Then(@"the Select Dataset Schema Drop Down is displayed")]
        public void ThenTheSelectDatasetSchemaDropDownIsDisplayed()
        {
            choosedatasetrelationshippage.selectDatasetSchemaDropDown.Should().NotBeNull();
        }

        [Then(@"the Dataset Schema Name field is displayed")]
        public void ThenTheDatasetSchemaNameFieldIsDisplayed()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipName.Should().NotBeNull();
        }

        [Then(@"the Dataset Description field is displayed")]
        public void ThenTheDatasetDescriptionFieldIsDisplayed()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipDescription.Should().NotBeNull();
        }

        [Then(@"the Save Dataset Button is displayed")]
        public void ThenTheSaveDatasetButtonIsDisplayed()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipSaveButton.Should().NotBeNull();
        }

        [Then(@"the Cancel Dataset Schema Relationship link is displayed")]
        public void ThenTheCancelDatasetSchemaRelationshipLinkIsDisplayed()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipCancelLink.Should().NotBeNull();
        }

        [Given(@"I have selected a valid specification with no datasets associated")]
        public void GivenIHaveSelectedAValidSpecificationWithNoDatasetsAssociated()
        {
            CreateNewSpecification.CreateANewSpecification();
            managepoliciespage.datasetsTab.Should().NotBeNull();

        }

        [When(@"I click the Datasets Tab")]
        public void WhenIClickTheDatasetsTab()
        {
            managepoliciespage.datasetsTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"a link is displayed to choose a data type")]
        public void ThenALinkIsDisplayedToChooseADataType()
        {
            managepoliciespage.datasetsTabNoDatasetsExistLink.Should().NotBeNull();
        }

        [When(@"I click the No Data Type Exists link")]
        public void WhenIClickTheNoDataTypeExistsLink()
        {
            managepoliciespage.datasetsTabNoDatasetsExistLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Choose Your Data page")]
        public void ThenIAmRedirectedToTheChooseYourDataPage()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipSaveButton.Should().NotBeNull();
        }

        [Given(@"I have navigated to the Choose Your Data page")]
        public void GivenIHaveNavigatedToTheChooseYourDataPage()
        {
            NavigateTo.CreateDatasetPage();
            Thread.Sleep(2000);
        }

        [Given(@"I have selected a Dataset Schema to relate to the specification")]
        public void GivenIHaveSelectedADatasetSchemaToRelateToTheSpecification()
        {
            Actions.SelectDatasetDataSchemaDropDown();
        }

        [Given(@"I have entered a Dataset Schema Name")]
        public void GivenIHaveEnteredADatasetSchemaName()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipName.SendKeys(newname);
        }

        [Given(@"I have entered a Dataset Description")]
        public void GivenIHaveEnteredADatasetDescription()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipDescription.SendKeys(descriptiontext);
        }

        [When(@"I click the Save Dataset button")]
        public void WhenIClickTheSaveDatasetButton()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipSaveButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to a list view of dataset schema relationships for the specification")]
        public void ThenIAmRedirectedToAListViewOfDatasetSchemaRelationshipsForTheSpecification()
        {
            managepoliciespage.datasetsTabNoDatasetsExistLink.Should().NotBeNull();
        }

        [Then(@"the new dataset is saved and displayed correctly")]
        public void ThenTheNewDatasetIsSavedAndDisplayedCorrectly()
        {
            Driver._driver.FindElement(By.LinkText(newname));
        }

        [When(@"I click the Cancel Dataset")]
        public void WhenIClickTheCancelDataset()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipCancelLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am navigated back to the Manage Policies page")]
        public void ThenIAmNavigatedBackToTheManagePoliciesPage()
        {
            managepoliciespage.datasetsTab.Should().NotBeNull();
        }

        [Given(@"I have missed or duplicated the following details (.*) and (.*) and (.*)")]
        public void GivenIHaveMissedOrDuplicatedTheFollowingDetailsAndAnd(string schema, string name, string description)
        {
            choosedatasetrelationshippage.selectDatasetSchemaDropDown.Click();
            choosedatasetrelationshippage.selectDatasetSchemaDropDownTextSearch.SendKeys(schema);
            choosedatasetrelationshippage.selectDatasetSchemaDropDown.SendKeys(OpenQA.Selenium.Keys.Enter);
            choosedatasetrelationshippage.datasetSchemaRelationshipName.SendKeys(name);
            choosedatasetrelationshippage.datasetSchemaRelationshipDescription.SendKeys(description);
            Thread.Sleep(2000);
        }

        [Then(@"the following Dataset Schema Relationship Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingDatasetSchemaRelationshipErrorShouldBeDisplayedForFieldNameAnd(string DatasetFieldName, string dataseterror)
        {
            Thread.Sleep(1000);
            if (DatasetFieldName == "Missing Dataset Schema")
                Assert.AreEqual(dataseterror, choosedatasetrelationshippage.createDatasetDatasetSchemaRelationshipError.Text);

            else if (DatasetFieldName == "Missing Dataset Name")
                Assert.AreEqual(dataseterror, choosedatasetrelationshippage.createDatasetDatasetNameError.Text);

            else if (DatasetFieldName == "Missing Dataset Description")
                Assert.AreEqual(dataseterror, choosedatasetrelationshippage.createDatasetDatasetDescriptionError.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);
        }


        [When(@"I click the option to Map data sources to datasets")]
        public void WhenIClickTheOptionToMapDataSourcesToDatasets()
        {
            managethedatapage.specifyDataSetRelationshipLink.Click();
            Thread.Sleep(5000);
        }

        [Then(@"I am presented with the Map data sources to datasets page")]
        public void ThenIAmPresentedWithTheMapDataSourcesToDatasetsPage()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSearchTermField.Should().NotBeNull();

        }

        [Given(@"I have navigated to Map data sources to datasets page")]
        public void GivenIHaveNavigatedToMapDataSourcesToDatasetsPage()
        {
            NavigateTo.MapDataSourcesToDatasetsPage();
            Thread.Sleep(2000);

        }

        [Then(@"I can see an option to search for a specification")]
        public void ThenICanSeeAnOptionToSearchForASpecification()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSearchTermField.Should().NotBeNull();
        }

        [Then(@"an option to filter by year")]
        public void ThenAnOptionToFilterByYear()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSpecficationYearDropDown.Should().NotBeNull();
        }

        [Then(@"the default year is preselected")]
        public void ThenTheDefaultYearIsPreselected()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSpecificationYearDropDownDefault.Should().NotBeNull();
        }

        [Then(@"I am presented with all specifications for that year")]
        public void ThenIAmPresentedWithAllSpecificationsForThatYear()
        {
            mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed.Should().NotBeNull();
            string totalnumberofspecifications = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed.Text;
            Console.WriteLine("The Total Number of Specficiations listed for the default year is " + totalnumberofspecifications);
        }

        [Then(@"the Map Data Source Specification Name is displayed")]
        public void ThenTheMapDataSourceSpecificationNameIsDisplayed()
        {
            mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationName.Should().NotBeNull();
        }

        [Then(@"the number of relationships that exist for that specification")]
        public void ThenTheNumberOfRelationshipsThatExistForThatSpecification()
        {
            mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationRelationships.Should().NotBeNull();
            IWebElement numberofdatarelationships = mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationRelationships;
            string datarelationshipexists = numberofdatarelationships.Text;
            Console.WriteLine("For the selected Specification " + datarelationshipexists);
        }

        [Given(@"I have over (.*) spec results listed")]
        public void GivenIHaveOverSpecResultsListed(int NoOfSpecifications)
        {
            IWebElement totalspecificationslisted = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed;
            string totallisted = totalspecificationslisted.Text;
            int totalnolisted = int.Parse(totallisted);
            totalnolisted.Should().BeGreaterThan(NoOfSpecifications, "Less than "+ NoOfSpecifications + " are displayed");
        }

        [Given(@"the list is in ascending alphabetical order")]
        public void GivenTheListIsInAscendingAlphabeticalOrder()
        {

        }

        [When(@"I click to navigate to the next page of specifications")]
        public void WhenIClickToNavigateToTheNextPageOfSpecifications()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSecondPage.Click();
            Thread.Sleep(2000);
        }

        [Then(@"my list view updates with up to the next set of (.*) results")]
        public void ThenMyListViewUpdatesWithUpToTheNextSetOfResults(int firstspecificationresultlisted)
        {
            IWebElement firstspecification = mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationsListed;
            string firstspecificationadditionalpage = firstspecification.Text;
            int additionalpagefirstresult = int.Parse(firstspecificationadditionalpage);
            additionalpagefirstresult.Should().BeGreaterThan(firstspecificationresultlisted, "Less than " + firstspecificationresultlisted + " are displayed");
        }

        [Then(@"I am able to navigate to the previous page of (.*) specs")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfSpecs(int pagetotalreults)
        {
            mapdatasourcestodatasetspage.mapDataSounrcesFirstPage.Click();
            IWebElement lastspecification = mapdatasourcestodatasetspage.mapDataSourcesLastSpecificationsListed;
            string lastspecificationfirstpage = lastspecification.Text;
            int lastresult = int.Parse(lastspecificationfirstpage);
            lastresult.Should().BeLessOrEqualTo(pagetotalreults, "The Results page is displaying incorrectly");
        }

        [When(@"I enter text in the search specifications field")]
        public void WhenIEnterTextInTheSearchSpecificationsField()
        {
            IWebElement initaltotalallresults = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed;
            string defaulttotal = initaltotalallresults.Text;
            int initaltotal = int.Parse(defaulttotal);
            Console.WriteLine("Inital results returned for the selected year was " + initaltotal);
            ManageDatasetsSteps.totalresults = initaltotal;

            mapdatasourcestodatasetspage.mapDataSourcesSearchTermField.SendKeys("Test");
        }

        [When(@"click the search button")]
        public void WhenClickTheSearchButton()
        {
            mapdatasourcestodatasetspage.mapDataSourcesSearchTermButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list of results refreshes to display only the results that comply with the search text entered")]
        public void ThenTheListOfResultsRefreshesToDisplayOnlyTheResultsThatComplyWithTheSearchTextEntered()
        {
            IWebElement filteredresults = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed;
            string filteredtotal = filteredresults.Text;
            int filteredsearchresults = int.Parse(filteredtotal);
            Console.WriteLine("Filtered results by search term returned for the selected year was " + filteredsearchresults);
            ManageDatasetsSteps.totalresults.Should().NotBeNull("Previous Steps have not executed correctly");
            filteredsearchresults.Should().BeLessOrEqualTo(ManageDatasetsSteps.totalresults.Value, "Results have not been filtered correctly by the Search Term");

        }

        [When(@"I choose a different year from the dropdown option")]
        public void WhenIChooseADifferentYearFromTheDropdownOption()
        {
            IWebElement initaltotalallresults = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed;
            string defaulttotal = initaltotalallresults.Text;
            int initaltotal = int.Parse(defaulttotal);
            Console.WriteLine("Inital results returned for the selected year was " + initaltotal);
            ManageDatasetsSteps.totalresults = initaltotal;

            var selectYear = mapdatasourcestodatasetspage.mapDataSourcesSpecficationYearDropDown;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1718");
            Thread.Sleep(2000);
        }

        [Then(@"the list of results refreshes to display only the results that comply with the year selected")]
        public void ThenTheListOfResultsRefreshesToDisplayOnlyTheResultsThatComplyWithTheYearSelected()
        {
            IWebElement filteredresults = mapdatasourcestodatasetspage.mapDataSourcesTotalSpecificationsListed;
            string filteredtotal = filteredresults.Text;
            int filteredsearchresults = int.Parse(filteredtotal);
            Console.WriteLine("Filtered results by a different year returned " + filteredsearchresults + " results");
            ManageDatasetsSteps.totalresults.Should().NotBeNull("Previous Steps have not executed correctly");
            filteredsearchresults.Should().BeLessOrEqualTo(ManageDatasetsSteps.totalresults.Value, "Results have not been filtered correctly by the selected year");

        }

        [When(@"I click on a specification name")]
        public void WhenIClickOnASpecificationName()
        {
            mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationName.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am taken to the specification data relationships page for that specification")]
        public void ThenIAmTakenToTheSpecificationDataRelationshipsPageForThatSpecification()
        {
            selectedspecificationdatasourcepage.specificationDataSourcePageTitle.Should().Equals("Specification Relationships - Calculate funding");
            Thread.Sleep(2000);
        }


        [AfterScenario()]
        public void FixtureTearDown()
        {
            if (Driver._driver != null)
            {
                Driver._driver.Quit();
                Driver._driver.Dispose();
            }
        }

    }
}
