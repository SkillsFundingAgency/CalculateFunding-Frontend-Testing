Feature: ManageDatasets
	As a Data analyst I need to relate data sets to specifications So that there is control on the data that is used in the calculations and tests

@Workitem:38307 Driver
Scenario: View the Manage Data Landing page
Given I have successfully navigated to the Home Page
When I select Manage the Data
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
Scenario: Select to Load a new Dataset
Given I have navigated to the Manage Datasets page
When I click the Load a New Dataset button
Then I am navigated to the load New Dataset page

@Workitem:36845 Driver
Scenario: Verify the Dataset Schema Relationship page from the option link
Given I have selected a valid specification from the Manage Specification page
When I click the Choose data type relationship link
Then I am redirected to the Choose Your Data page
And the Select Dataset Schema Drop Down is displayed
And the Dataset Schema Name field is displayed
And the Dataset Description field is displayed
And the Save Dataset Button is displayed
And the Cancel Dataset Schema Relationship link is displayed

