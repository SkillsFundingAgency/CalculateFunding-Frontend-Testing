﻿Feature: ManageDatasets
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
| Missing Dataset Schema		|              | Name    | This is a Description | You must assign a dataset for the specification					 |
| Missing Dataset Name			| High Needs   |         | This is a Description | You must give a unique name for this dataset schema relationship	 |
| Missing Dataset Description	| High Needs   | Name    |                       | You must provide a description for this new relationship			 |

