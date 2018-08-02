Feature: ManageDatasets
	As a Data analyst I need to relate data sets to specifications So that there is control on the data that is used in the calculations and tests

@Workitem:38307 Driver
Scenario: View the Manage Data Landing page
Given I have successfully navigated to the Home Page
When I select Manage data
Then I am redirected to the Manage Data page
And I am presented the Manage Datasets option
And a description of the Manage Datasets option
And I am presented the Specify data source relationships option
And a description of the Specify data source relationships option

@Workitem:38307 Driver
Scenario: Select the Manage Datsets page
Given I have navigated to the data management option from the service home page
When I click on the Manage data sets option
Then I am presented with the Manage Datasets page

@Workitem:38307 Driver
Scenario: Select the Specify Data source Relationships page
Given I have navigated to the data management option from the service home page
When I click on the specify data source relationships option
Then I am presented with the Specify data source relationships page

@Workitem:37113 Driver
Scenario: Verify the Manage Dataset List View
Given I have navigated to the Manage Datasets page
Then the page displays a list view of all data sets that have been uploaded
And My list is in descending order from the most recent dataset
And the dataset name is displayed
And the datasets current status is displayed
And the datasets last Updated date is displayed

@Workitem:37113 Driver
Scenario: Verify the Manage Dataset Result Counts
Given I have navigated to the Manage Datasets page
Then my list shows up to 50 data sets
And a count of all data sets returned is displayed
And a link to Load new datasets is displayed

@Workitem:37113 Driver
Scenario: Validate the Manage Dataset List View Pagination
Given I have navigated to the Manage Datasets page
When More than 50 Results are available
Then I can navigate to a page of the next 50 data sets
And I can navigate to a page of the previous 50 data sets

@Workitem:37113 Driver
Scenario: Select to Load a new Dataset
Given I have navigated to the Manage Datasets page
When I click the Load a New Dataset button
Then I am navigated to the load New Dataset page

@Workitem:36845 Driver
Scenario: Verify the Dataset Schema Relationship page from the option link
Given I have selected a valid specification from the Manage Specification page
When I click the Create Dataset link
Then I am redirected to the Create dataset page
And the Select Dataset Schema Drop Down is displayed
And the Dataset Schema Name field is displayed
And the Dataset Description field is displayed
And the Save Dataset Button is displayed
And the Cancel Dataset Schema Relationship link is displayed

@Workitem:36845 Driver
Scenario: Verify the Dataset Schema Relationship page from the Data Type Tab
Given I have selected a valid specification with no datasets associated
When I click the Datasets Tab
Then a link is displayed to choose a data type
When I click the No Data Type Exists link
Then I am redirected to the Choose Your Data page

@Workitem:36845 Driver
Scenario: Create and Save a Dataset Schema Relationship where Provider Data is Set
Given I have navigated to the Choose Your Data page
And I have selected a Dataset Schema to relate to the specification
And I have entered a Dataset Schema Name
And I have entered a Dataset Description
And I have ticked the Set as provider data checkbox
When I click the Save Dataset button
Then I am redirected to a list view of dataset schema relationships for the specification
And the new dataset is saved and displayed correctly

@Workitem:36845 Driver
Scenario: Create and Save a Dataset Schema Relationship
Given I have navigated to the Choose Your Data page
And I have selected a Dataset Schema to relate to the specification
And I have entered a Dataset Schema Name
And I have entered a Dataset Description
When I click the Save Dataset button
Then I am redirected to a list view of dataset schema relationships for the specification
And the new dataset is saved and displayed correctly

@Workitem:36845 Driver
Scenario: Create and Cancel a Dataset Schema Relationship
Given I have navigated to the Choose Your Data page
And I have selected a Dataset Schema to relate to the specification
And I have entered a Dataset Schema Name
And I have entered a Dataset Description
When I click the Cancel Dataset
Then I am navigated back to the Manage Policies page

@Workitem:36845 Driver
Scenario Outline: Create and Save an incorrect Dataset Schema Relationship
Given I have navigated to the Choose Your Data page
And I have missed or duplicated the following details <schema> and <name> and <description>
When I click the Save Dataset button
Then the following Dataset Schema Relationship Error should be displayed for FieldName '<DatasetFieldName>' and '<dataseterror>'

Examples: 
| DatasetFieldName				| schema       | name	 | description           | dataseterror														 |
| Missing Dataset Schema		| ZZZZ         | Name    | This is a Description | Enter a data schema	 |
| Missing Dataset Name			| High Needs   |         | This is a Description | Enter a unique name	 |
| Missing Dataset Description	| High Needs   | Name    |                       | Enter a description	 |


@Workitem:37469 Driver
Scenario: Navigate to the Map Data Sources to Datasets Page
Given I have navigated to the data management option from the service home page
When I click the option to Map data sources to datasets
Then I am presented with the Map data sources to datasets page

@Workitem:37469 Driver
Scenario: View the Map Data Sources to Datasets Page
Given I have navigated to Map data sources to datasets page
Then I can see an option to search for a specification
And an option to filter by year
And the default year is preselected
And I am presented with all specifications for that year
And the Map Data Source Specification Name is displayed 
And the number of relationships that exist for that specification

@Workitem:37469 Driver
Scenario: Pagination for the Map Data Sources to Datasets Page 
Given I have navigated to Map data sources to datasets page
And I have over 20 spec results listed
And the list is in ascending alphabetical order
When I click to navigate to the next page of specifications
Then my list view updates with up to the next set of 20 results
And I am able to navigate to the previous page of 20 specs

@Workitem:37469 Driver
Scenario: Search Specifications listed on the Map data sources to datasets page
Given I have navigated to Map data sources to datasets page
When I enter text in the search specifications field
And click the search button
Then the list of results refreshes to display only the results that comply with the search text entered

@Workitem:37469 Driver
Scenario: Filter Specifications listed by Year on the Map data sources to datasets page
Given I have navigated to Map data sources to datasets page
When I choose a different year from the dropdown option
Then the list of results refreshes to display only the results that comply with the year selected

@Workitem:37469 Driver
Scenario: Select a Specific Specification from the Map data sources to datasets page
Given I have navigated to Map data sources to datasets page
When I click on a specification name
Then I am taken to the specification data relationships page for that specification

@Workitem:38550 Driver
Scenario: Select a Secification that has no dataset relationships associated
Given I have navigated to a specification data relationships page without any dataset relationships established
Then a message declaring that no dataset relationships have been established is displayed
And instructions on what steps are required to create the relationships is displayed

@Workitem:38550 Driver
Scenario: Select a Specification that does have dataset relationships associated
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to a specification data relationships page where dataset relationships exist
Then the count of data sources established is displayed
And the Data schema name is displayed
And the Data set name is displayed
And the Data set description is displayed

@Workitem:38550 Driver
Scenario: Select a Specification that has a dataset relationships but no Data Schema associated
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to a specification data relationships page where dataset relationships exist
When the data set data schema relationship does not have a data source associated
Then I am provided with the option to select a data source

@Workitem:38550 Driver
Scenario: Select a Specification that has a dataset relationships and a Data Schema associated
Given I have already created a Specification with the appropruiate dataset & schema associated
And I have navigated to a specification data relationships page where dataset relationships exist
When the data set data schema relationship does have a data source associated
Then the name of the data source is displayed
And the version of the data source is displayed
And an option to change the data source is displayed

@Workitem:38338 Driver
Scenario: Verify the Select Source Dataset Page
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Choose data sources for specifications page where dataset relationships exist
When I click on the Select Source Dataset option
Then I am presented with the Select source datasets page
And the Name of the selected specification is displayed
And the schema relationship name is displayed
And a list of datasets within the associated schema is displayed

@Workitem:38338 Driver
Scenario: Select Data Source Option to display Data Source Version
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Select Source Dataset
When I click a displayed datasets option
Then that dataset is shown to be selected

@Workitem:38338 Driver
Scenario: Verify the Select Data Source Version Option is displayed correctly
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Select Source Dataset
When I click a displayed datasets option
Then all the dataset versions that exist are displayed in descending order

@Workitem:38338 Driver
Scenario: Verify the Select Data Source Save Button is Enabled correctly
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Select Source Dataset
When I click a displayed datasets option
Then the selected dataset version is show to be selected
And the Select source datasets Save data sources button is enabled 

@Workitem:38338 Driver
Scenario: Verify the Select Data Source Cancel link
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Select Source Dataset
When I click a displayed datasets option
When I click the Select source datasets cancel link
Then I redirected to the Specification data relationships page

@Workitem:38338 Driver
Scenario: Save a Dataset Source Selection to Dataset
Given I have already created a Specification with the appropruiate dataset associated
And I have navigated to the Select Source Dataset
When I click a displayed datasets option
And I have selected a data source version
When I click the Select source datasets Save button
Then The change is saved
And I redirected to the Specification data relationships page
And the Specification data relationships page displayed a confirmation message for the change

@Workitem:38338 Driver
Scenario: Change and Save a Dataset Source Selection to Dataset
Given I have already created a Specification with the appropruiate dataset & schema associated
And I have navigated to the Change source dataset
When I click a different displayed datasets option
And I have selected the new data source version
When I click the Select source datasets Save button
Then The change is saved
And I redirected to the Specification data relationships page
And the Specification data relationships page displayed a confirmation message for the change

@Workitem:47000 Driver
Scenario: Verify Manage data sources Download data source option
Given I have navigated to the Manage Datasets page
Then the page displays a list view of all data sets that have been uploaded
And an option to download the datasource is displayed

@Workitem:47000 Driver
Scenario: Select the Download data source option on the Manage data sources page
Given I have navigated to the Manage Datasets page
And The page displays a list view of all data sets that have been uploaded
And An option to download the datasource is displayed
When I click the Download link for a Data Source
Then The Download reddirect URL from Blogstorage is correctly generated
And The HTTP Status Code is reurned as OK

@Workitem:36846 Driver
Scenario: Verify the Upload option on the Manage Datasets page
Given I have navigated to the Manage Datasets page
Then the page displays a list view of all data sets that have been uploaded
And an option to update the datasource is displayed

@Workitem:36846 Driver
Scenario: View the Update data source page
Given I have navigated to the Manage Datasets page
When I click on the Update Link for a Dataset
Then I am sucessfully redirected to the Update data source page

@Workitem:36846 Driver
Scenario: Verify the Update data source page
Given I have navigated to the Manage Datasets page
And I have selected a Dataset to Update
Then I am sucessfully redirected to the Update data source page
And the selected Dataset information is displayed correctly
And an opion to update the Description is displayed
And an option to add a Change note is displayed
And a Browser for file button is displayed
And an Update Dataset Button is displayed 
And a Cancel change link is displayed

@Workitem:36846 Driver
Scenario: Successfully Cancel an Update to an Existing data source
Given I have navigated to the Manage Datasets page
And I have selected a Dataset to Update
Then I am sucessfully redirected to the Update data source page
And the selected Dataset information is displayed correctly
When I update the Dataset Description
And I add a Change note
And I click the Update Dataset Cancel Link
Then I am redirected back to the Manage Datasets Page

@Workitem:54452 Driver
Scenario: Select the Download data schemas Page
Given I have navigated to the data management option from the service home page
When I choose the Download data schemas link
Then I am redirected to the Download data schemas Page

@Workitem:54452 Driver
Scenario: Verify the Download data schemas Page
Given I have navigated to the Download data schemas Page
Then I am presented with a search box to search data schemas by name
And I am presented with an option to download a template to request a new data schema
And I am presented with a table listing all of the existing data schemas
And the page is paginated to show only 50 results on a single page
And the table listing headers are displayed correctly

@Workitem:54452 Driver
Scenario: Validate the Information for a Data schema template
Given I have navigated to the Download data schemas Page
Then I am presented with the Relevant information for the Template

@Workitem:54452 Driver
Scenario: Validate the More Information option for a Data schema template
Given I have navigated to the Download data schemas Page
When I choose to view more information for a data schema
Then I am presented with the provider identifier and description
