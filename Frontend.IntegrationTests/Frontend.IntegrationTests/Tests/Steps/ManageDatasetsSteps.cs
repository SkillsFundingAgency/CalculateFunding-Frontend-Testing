using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Helpers;
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
        HomePage homepage = new HomePage();
        ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
        ManageDatasetsPage managedatasetpage = new ManageDatasetsPage();
        ManageTheDataPage managethedatapage = new ManageTheDataPage();
        SpecifyDatasetRelationshipsPage specifyDatasetRelationshippage = new SpecifyDatasetRelationshipsPage();
        LoadNewDatasetPage loadnewdatasetpage = new LoadNewDatasetPage();
        ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();
        MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();
        SelectedSpecificationDataSourcePage selectedspecificationdatasourcepage = new SelectedSpecificationDataSourcePage();
        SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();
        UpdateDatasetPage updatedatasetpage = new UpdateDatasetPage();

        public string newname = "Test Name ";
        public string descriptiontext = "This is a Description";
        public static int? totalresults = null;
        public string datasetinformation = Actions.datasestinfo;


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

        [When(@"More than (.*) Results are available")]
        public void WhenMoreThanResultsAreAvailable(int totalItemCount)
        {
            IWebElement datasetTotal = managedatasetpage.manageDatasetsTotalResultCount;
            string datasetTotalValue = datasetTotal.Text;
            int totalPageCount = int.Parse(datasetTotalValue);

            if (totalPageCount < totalItemCount)
            {
                Assert.Inconclusive("Only 1 page of results is displayed as the Total results returned is less than " + totalItemCount);

            }
            else
            {
                Console.WriteLine("The Total results returned is " + totalPageCount);
            }

        }


        [Then(@"I can navigate to a page of the next (.*) data sets")]
        public void ThenICanNavigateToAPageOfTheNextDataSets(int endResultListCount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
            IWebElement endResultCount = managedatasetpage.manageDatasetsEndListItemCount;
            string endPageResultCount = endResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeGreaterOrEqualTo(endResultListCount, "Less than 50 Results have been returned on this Page");
        }

        [Then(@"I can navigate to a page of the previous (.*) data sets")]
        public void ThenICanNavigateToAPageOfThePreviousDataSets(int endResultListCount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
            IWebElement endResultCount = managedatasetpage.manageDatasetsEndListItemCount;
            string endPageResultCount = endResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(endResultListCount, "More than 50 Results are displayed on this Page");
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
            var randomName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["DatasetSchemaName"] = randomName;
            choosedatasetrelationshippage.datasetSchemaRelationshipName.SendKeys(randomName);
        }

        [Given(@"I have entered a Dataset Description")]
        public void GivenIHaveEnteredADatasetDescription()
        {
            choosedatasetrelationshippage.datasetSchemaRelationshipDescription.SendKeys(descriptiontext);
        }

        [Given(@"I have ticked the Set as provider data checkbox")]
        public void GivenIHaveTickedTheSetAsProviderDataCheckbox()
        {
            choosedatasetrelationshippage.createDatasetSetAsDataProvider.Click();
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
            var datasetName = ScenarioContext.Current["DatasetSchemaName"];
            string datasetCreated = datasetName.ToString();
            var datasetelements = Driver._driver.FindElements(By.CssSelector(".dataset-assigned-list"));
            IWebElement createddataset = null;
            foreach (var element in datasetelements)
            {
                if (element.Text.Contains(datasetCreated))
                {
                    {
                        createddataset = element;
                        break;
                    }
                }

            }

            Thread.Sleep(1000);
            if (createddataset != null)
            {
                Console.WriteLine("The New Dataset " + datasetCreated + " was Saved correctly");
            }
            else
            {
                createddataset.Should().NotBeNull("Unable to find dataset " + datasetCreated + " within the list view");
            }
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

            if (totalnolisted < NoOfSpecifications)
            {
                Assert.Inconclusive("Only 1 page of results is displayed as the Total results returned is less than " + NoOfSpecifications);

            }
            else
            {
                Console.WriteLine("The Total results returned is " + totalnolisted);
            }

        }

        [Given(@"the list is in ascending alphabetical order")]
        public void GivenTheListIsInAscendingAlphabeticalOrder()
        {

        }

        [When(@"I click to navigate to the next page of specifications")]
        public void WhenIClickToNavigateToTheNextPageOfSpecifications()
        {
            Actions.PaginationSelectPage();
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
            Actions.PaginationSelectPage();
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
            selectElement.SelectByValue("FY2017181");
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

        [Given(@"I have navigated to a specification data relationships page without any dataset relationships established")]
        public void GivenIHaveNavigatedToASpecificationDataRelationshipsPageWithoutAnyDatasetRelationshipsEstablished()
        {
            NavigateTo.SpecificationDataNoRelationshipsPage();
            Thread.Sleep(2000);
        }

        [Then(@"a message declaring that no dataset relationships have been established is displayed")]
        public void ThenAMessageDeclaringThatNoDatasetRelationshipsHaveBeenEstablishedIsDisplayed()
        {
            IWebElement noDataSourceMapped = selectedspecificationdatasourcepage.specificationNoDataSourceMappedMessage;
            string noDataSourceMessage = noDataSourceMapped.Text;
            Console.WriteLine(noDataSourceMessage);
        }

        [Then(@"instructions on what steps are required to create the relationships is displayed")]
        public void ThenInstructionsOnWhatStepsAreRequiredToCreateTheRelationshipsIsDisplayed()
        {
            IWebElement howToMessage = selectedspecificationdatasourcepage.specificationNoDataSourceMappedHowToMessage;
            string howToMessageText = howToMessage.Text;
            Console.WriteLine(howToMessageText);

            IWebElement howToSteps = selectedspecificationdatasourcepage.specificationNoDataSourceMappedHowToSteps;
            string howToStepsText = howToSteps.Text;
            Console.WriteLine(howToStepsText);

        }

        [Given(@"I have already created a Specification with the appropruiate dataset & schema associated")]
        public void GivenIHaveAlreadyCreatedASpecificationWithTheAppropruiateDatasetSchemaAssociated()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
            CreateDataSourceMapping.CreateADataSourceMapping();
            homepage.Header.Click();
            Thread.Sleep(2000);
        }


        [Given(@"I have navigated to a specification data relationships page where dataset relationships exist")]
        public void GivenIHaveNavigatedToASpecificationDataRelationshipsPageWhereDatasetRelationshipsExist()
        {
            NavigateTo.SpecificationDataRelationshipsExistPage();
            Thread.Sleep(2000);
        }

        [Then(@"the count of data sources established is displayed")]
        public void ThenTheCountOfDataSourcesEstablishedIsDisplayed()
        {
            selectedspecificationdatasourcepage.specificationDataSourceCount.Should().NotBeNull();
            IWebElement dataSourceCount = selectedspecificationdatasourcepage.specificationDataSourceCount;
            string dataSourceCountText = dataSourceCount.Text;
            Console.WriteLine(dataSourceCountText);
        }

        [Then(@"the Data schema name is displayed")]
        public void ThenTheDataSchemaNameIsDisplayed()
        {
            selectedspecificationdatasourcepage.specificationFirstDataSourceSchemaName.Should().NotBeNull();
            IWebElement dataSourceSchemaName = selectedspecificationdatasourcepage.specificationFirstDataSourceSchemaName;
            string dataSourceSchemaNameText = dataSourceSchemaName.Text;
            Console.WriteLine(dataSourceSchemaNameText);
        }

        [Then(@"the Data set name is displayed")]
        public void ThenTheDataSetNameIsDisplayed()
        {
            selectedspecificationdatasourcepage.specificationFirstDatasetName.Should().NotBeNull();
            IWebElement datasetName = selectedspecificationdatasourcepage.specificationFirstDatasetName;
            string datasetNameText = datasetName.Text;
            Console.WriteLine(datasetNameText);
        }

        [Then(@"the Data set description is displayed")]
        public void ThenTheDataSetDescriptionIsDisplayed()
        {
            selectedspecificationdatasourcepage.specificationFirstDatasetDescription.Should().NotBeNull();
            IWebElement datasetDescription = selectedspecificationdatasourcepage.specificationFirstDatasetDescription;
            string datasetDescriptionText = datasetDescription.Text;
            Console.WriteLine(datasetDescriptionText);
        }

        [When(@"the data set data schema relationship does not have a data source associated")]
        public void WhenTheDataSetDataSchemaRelationshipDoesNotHaveADataSourceAssociated()
        {
            Actions.SelectSpecificationDataNoDataSchemaAssociated();
        }

        [Then(@"I am provided with the option to select a data source")]
        public void ThenIAmProvidedWithTheOptionToSelectADataSource()
        {
            Console.WriteLine("The Select source dataset link is correctly displayed");
        }


        [When(@"the data set data schema relationship does have a data source associated")]
        public void WhenTheDataSetDataSchemaRelationshipDoesHaveADataSourceAssociated()
        {
            Actions.SelectSpecificationDataDataSchemaExists();
        }

        [Then(@"the name of the data source is displayed")]
        public void ThenTheNameOfTheDataSourceIsDisplayed()
        {
            Console.WriteLine(datasetinformation);

        }

        [Then(@"the version of the data source is displayed")]
        public void ThenTheVersionOfTheDataSourceIsDisplayed()
        {
            //Console writeline in the previous class displays the required information as this info ont he page cannot be seperated out
        }

        [Then(@"an option to change the data source is displayed")]
        public void ThenAnOptionToChangeTheDataSourceIsDisplayed()
        {
            //Console writeline in the previous class displays the required information as this info ont he page cannot be seperated out
        }

        [Given(@"I have already created a Specification with the appropruiate dataset associated")]
        public void GivenIHaveAlreadyCreatedASpecificationWithTheAppropruiateDatasetAssociated()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
            homepage.Header.Click();
            Thread.Sleep(2000);
        }


        [Given(@"I have navigated to the Choose data sources for specifications page where dataset relationships exist")]
        public void GivenIHaveNavigatedToTheChooseDataSourcesForSpecificationsPageWhereDatasetRelationshipsExist()
        {
            NavigateTo.SpecificationDataRelationshipsExistPage();
            Thread.Sleep(2000);
        }

        [When(@"I click on the Select Source Dataset option")]
        public void WhenIClickOnTheSelectSourceDatasetOption()
        {
            selectedspecificationdatasourcepage.specificationDataSourceMissing.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am presented with the Select source datasets page")]
        public void ThenIAmPresentedWithTheSelectSourceDatasetsPage()
        {
            selectsourcedatasetspage.selectSourceDatasetSaveButton.Should().NotBeNull();
        }

        [Then(@"the Name of the selected specification is displayed")]
        public void ThenTheNameOfTheSelectedSpecificationIsDisplayed()
        {
            selectsourcedatasetspage.selectSourceDatasetSpecName.Should().NotBeNull();
        }

        [Then(@"the schema relationship name is displayed")]
        public void ThenTheSchemaRelationshipNameIsDisplayed()
        {
            selectsourcedatasetspage.selectSourceDatasetSchemaRelationshipName.Should().NotBeNull();
        }

        [Then(@"a list of datasets within the associated schema is displayed")]
        public void ThenAListOfDatasetsWithinTheAssociatedSchemaIsDisplayed()
        {
            selectsourcedatasetspage.selectSourceDatasetList.Should().NotBeNull();
        }

        [Given(@"I have navigated to the Select Source Dataset")]
        public void GivenIHaveNavigatedToTheSelectSourceDataset()
        {
            NavigateTo.SelectSourceDatasetPage();
        }

        [When(@"I click a displayed datasets option")]
        public void WhenIClickADisplayedDatasetsOption()
        {
            var savebuttondisabledtrue = selectsourcedatasetspage.selectSourceDatasetSaveButton.GetAttribute("disabled");
            savebuttondisabledtrue.Should().NotBeNull();
            Actions.SelectSourceDatasetsRadioOption();
            Thread.Sleep(2000);
        }

        [Then(@"that dataset is shown to be selected")]
        public void ThenThatDatasetIsShownToBeSelected()
        {
            IWebElement datasourceverisoncontainer = selectsourcedatasetspage.selectSourceDatasetVersionContainer;
            IWebElement datasourceexiststext = datasourceverisoncontainer.FindElement(By.CssSelector("h4.heading-small"));
            datasourceexiststext.Should().NotBeNull();
            datasourceexiststext.Text.Should().Be("Select data source version");
            datasourceexiststext.Displayed.Should().BeTrue();
        }

        [Then(@"all the dataset versions that exist are displayed in descending order")]
        public void ThenAllTheDatasetVersionsThatExistAreDisplayedInDescendingOrder()
        {
            IWebElement datasourceverisoncontainer = selectsourcedatasetspage.selectSourceDatasetVersionContainer;
            IWebElement datasourceexistsname = datasourceverisoncontainer.FindElement(By.CssSelector(".ds-versions-container label"));
            datasourceexistsname.Should().NotBeNull();
            string datasourcename = datasourceexistsname.Text;
            Console.WriteLine("DataSource Version Name is " + datasourcename);
        }


        [Then(@"the selected dataset version is show to be selected")]
        public void ThenTheSelectedDatasetVersionIsShowToBeSelected()
        {
            var savebuttondisabledtrue = selectsourcedatasetspage.selectSourceDatasetSaveButton.GetAttribute("disabled");
            savebuttondisabledtrue.Should().NotBeNull();
            Actions.SelectSourceDatasetVersionRadioOption();
        }

        [Then(@"the Select source datasets Save data sources button is enabled")]
        public void ThenTheSelectSourceDatasetsSaveDataSourcesButtonIsEnabled()
        {
            var savebuttonenabled = selectsourcedatasetspage.selectSourceDatasetSaveButton.GetAttribute("disabled");
            savebuttonenabled.Should().BeNull();
        }

        [When(@"I click the Select source datasets cancel link")]
        public void WhenIClickTheSelectSourceDatasetsCancelLink()
        {
            selectsourcedatasetspage.selectSourceDatasetCancelLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I redirected to the Specification data relationships page")]
        public void ThenIRedirectedToTheSpecificationDataRelationshipsPage()
        {
            selectedspecificationdatasourcepage.specificationDataSourceMissing.Should().NotBeNull();
        }


        [When(@"I have selected a data source version")]
        public void WhenIHaveSelectedADataSourceVersion()
        {
            Actions.SelectSourceDatasetVersionRadioOption();
        }

        [When(@"I click the Select source datasets Save button")]
        public void WhenIClickTheSelectSourceDatasetsSaveButton()
        {
            selectsourcedatasetspage.selectSourceDatasetSaveButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"The change is saved")]
        public void ThenTheChangeIsSaved()
        {
            selectedspecificationdatasourcepage.specificationDataSourceAddedAlert.Displayed.Should().BeTrue();
        }

        [Then(@"the Specification data relationships page displayed a confirmation message for the change")]
        public void ThenTheSpecificationDataRelationshipsPageDisplayedAConfirmationMessageForTheChange()
        {
            var datasourcesavedalert = selectedspecificationdatasourcepage.specificationDataSourceAddedAlertText;
            string datasourcesavedconfirmation = datasourcesavedalert.Text;
            Console.WriteLine(datasourcesavedconfirmation);
            selectedspecificationdatasourcepage.specificationDataSourceDismissAlert.Should().NotBeNull();
            selectedspecificationdatasourcepage.specificationDataSourceDismissAlert.Click();
        }

        [Given(@"I have navigated to the Change source dataset")]
        public void GivenIHaveNavigatedToTheChangeSourceDataset()
        {
            NavigateTo.ChangeSourceDatasetPage();
        }

        [When(@"I click a different displayed datasets option")]
        public void WhenIClickADifferentDisplayedDatasetsOption()
        {
            var savebuttondisabledtrue = selectsourcedatasetspage.selectSourceDatasetSaveButton.GetAttribute("disabled");
            savebuttondisabledtrue.Should().NotBeNull();
            Actions.SelectNewSourceDatasetsRadioOption();
            Thread.Sleep(2000);
        }

        [When(@"I have selected the new data source version")]
        public void WhenIHaveSelectedTheNewDataSourceVersion()
        {
            Actions.SelectNewSourceDatasetVersionRadioOption();
        }

        [Then(@"an option to download the datasource is displayed")]
        public void ThenAnOptionToDownloadTheDatasourceIsDisplayed()
        {
            var downloadlinks = Driver._driver.FindElements(By.LinkText("Download"));
            IWebElement downloadoption = downloadlinks.FirstOrDefault();
            downloadoption.Should().NotBeNull();
        }

        [Given(@"The page displays a list view of all data sets that have been uploaded")]
        public void GivenThePageDisplaysAListViewOfAllDataSetsThatHaveBeenUploaded()
        {
            managedatasetpage.manageDatasetsListView.Should().NotBeNull();
        }

        [Given(@"An option to download the datasource is displayed")]
        public void GivenAnOptionToDownloadTheDatasourceIsDisplayed()
        {
            var downloadlinks = Driver._driver.FindElements(By.LinkText("Download"));
            IWebElement downloadoption = downloadlinks.FirstOrDefault();
            downloadoption.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [When(@"I click the Download link for a Data Source")]
        public void WhenIClickTheDownloadLinkForADataSource()
        {
            IWebElement firstdatasource = managedatasetpage.manageDatasetsFirstResultName;
            string datasourcename = firstdatasource.Text;
            Console.WriteLine(datasourcename + " is the first data source listed");
            Actions.SelectManageDataPageDataSourceDownloadoption();
        }

        [Then(@"The Download reddirect URL from Blogstorage is correctly generated")]
        public void ThenTheDownloadReddirectURLFromBlogstorageIsCorrectlyGenerated()
        {
            //Validation for this step is carried out within Actions.SelectManageDataPageDataSourceDownloadoption();
            //See redirected Blob URL in the Test Output row
        }

        [Then(@"The HTTP Status Code is reurned as OK")]
        public void ThenTheHTTPStatusCodeIsReurnedAsOK()
        {
            //Validation for this step is carried out within Actions.SelectManageDataPageDataSourceDownloadoption();
            //See the "File downloaded successfully. Filename = " Test Output row
        }

        [Then(@"an option to update the datasource is displayed")]
        public void ThenAnOptionToUpdateTheDatasourceIsDisplayed()
        {
            managedatasetpage.manageDatasetsUpdateLink.Should().NotBeNull();

        }

        [When(@"I click on the Update Link for a Dataset")]
        public void WhenIClickOnTheUpdateLinkForADataset()
        {
            Thread.Sleep(2000);
            Actions.SelectManageDataPageDataSourceUpdateOption();
        }

        [Then(@"I am sucessfully redirected to the Update data source page")]
        public void ThenIAmSucessfullyRedirectedToTheUpdateDataSourcePage()
        {
            updatedatasetpage.updateDataSetDescription.Should().NotBeNull();
        }

        [Given(@"I have selected a Dataset to Update")]
        public void GivenIHaveSelectedADatasetToUpdate()
        {
            Thread.Sleep(2000);
            Actions.SelectManageDataPageDataSourceUpdateOption();
        }

        [Then(@"the selected Dataset information is displayed correctly")]
        public void ThenTheSelectedDatasetInformationIsDisplayedCorrectly()
        {
            IWebElement datasetNameVersion = updatedatasetpage.updateDataSetNameVersion;
            datasetNameVersion.Should().NotBeNull();
            string datasetNameText = datasetNameVersion.Text;
            Console.WriteLine("Dataset Selected to Update is: " + datasetNameText);
            
            IWebElement datasetUser = updatedatasetpage.updateDataSetUser;
            datasetUser.Should().NotBeNull();
            string datasetUserText = datasetUser.Text;
            Console.WriteLine("Dataset Last Updated by: " + datasetUserText);

            IWebElement datasetLastUpdate = updatedatasetpage.updateDataSetLastUpdated;
            datasetLastUpdate.Should().NotBeNull();
            string datasetLastDate = datasetLastUpdate.Text;
            Console.WriteLine("Dataset Last Updated Date is: " + datasetLastDate);

        }


        [Then(@"an opion to update the Description is displayed")]
        public void ThenAnOpionToUpdateTheDescriptionIsDisplayed()
        {
            updatedatasetpage.updateDataSetDescription.Should().NotBeNull();        }

        [Then(@"an option to add a Change note is displayed")]
        public void ThenAnOptionToAddAChangeNoteIsDisplayed()
        {
            updatedatasetpage.updateDataSetChangeNote.Should().NotBeNull();
        }

        [Then(@"a Browser for file button is displayed")]
        public void ThenABrowserForFileButtonIsDisplayed()
        {
            updatedatasetpage.updateDataSetBrowseButton.Should().NotBeNull();
        }

        [Then(@"an Update Dataset Button is displayed")]
        public void ThenAnUpdateDatasetButtonIsDisplayed()
        {
            updatedatasetpage.updateDataSetUpdateButton.Should().NotBeNull();
        }

        [Then(@"a Cancel change link is displayed")]
        public void ThenACancelChangeLinkIsDisplayed()
        {
            updatedatasetpage.updateDataSetCancelLink.Should().NotBeNull();
        }

        [When(@"I update the Dataset Description")]
        public void WhenIUpdateTheDatasetDescription()
        {
            updatedatasetpage.updateDataSetDescription.Clear();
            updatedatasetpage.updateDataSetDescription.SendKeys("This is An Updated Dataset Description");
        }

        [When(@"I add a Change note")]
        public void WhenIAddAChangeNote()
        {
            updatedatasetpage.updateDataSetChangeNote.Clear();
            updatedatasetpage.updateDataSetChangeNote.SendKeys("This is An Updated Dataset Change note");
        }

        [When(@"I click the Update Dataset Cancel Link")]
        public void WhenIClickTheUpdateDatasetCancelLink()
        {
            updatedatasetpage.updateDataSetCancelLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected back to the Manage Datasets Page")]
        public void ThenIAmRedirectedBackToTheManageDatasetsPage()
        {
            managedatasetpage.manageDatasetsListView.Should().NotBeNull();
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
