﻿Feature: ManageCalculations
	As a Funding Calculation Developer
	I need to view a list of specified calculations
	So that I can select the calculation I want to create OR edit as well as be able to view 
	an audit history of a specific calculation

@Workitem:35473 Driver
Scenario: View Current list of Calculations
Given I have successfully navigated to the Home Page
When I select Manage the Calculations
Then I am redirected to the Manage Calculations page
And the page lists the most recent calculations

@Workitem:35473 Driver
Scenario: View Edit Calculations Page
Given I have navigated to the Manage Calculations page
When I click on a calculation in the list
Then I am navigated to the Edit Calculation screen

@Workitem:35473 Driver
Scenario: Current list of Calculations Pagination
Given I have navigated to the Manage Calculations page
When there is greater than 50 calculations
Then The the correct pagination options are displayed
When I click a pagination option
Then My list refreshes to display the selected page of calculations

@Workitem:36090 Driver
Scenario: Verify the Filter options on the Calculations Page
Given I have navigated to the Manage Calculations page
Then I am presented a filter option to select ONE or MORE Year
And I am presented a filter option to select ONE or MORE calculation status
And I am presented a filter option to select ONE or MORE funding stream(s)
And I am presented a filter option to select ONE or MORE policy
And I am presented a filter option to select ONE or MORE allocation lines
And the filters are defaulted to show all calculations that are specified

@Workitem:36090 Driver
Scenario: Select to Filter the Calculations Page by Academic Year
Given I have navigated to the Manage Calculations page
And the filters are defaulted to show all calculations that are specified
When I chosen to select the academic year filter option
Then All other filters will update
And display only those options that return results
And a total count of all filtered results is displayed above the list of results
And a count of the specific filter results is displayed
And the filter options are sorted in descending order by the count of results

@Workitem:36090 Driver
Scenario: Select to Filter the Calculations Page by Funding Stream
Given I have navigated to the Manage Calculations page
When I choose to filter my list by funding stream
Then the list view of calculations updates to display only calculations for the selected funding streams

@Workitem:36090 Driver
Scenario: Select to Filter the Calculations Page by Policy Specification
Given I have navigated to the Manage Calculations page
When I choose to filter my list by policy
Then the list view of calculations updates to display only calculations for the selected policy

@Workitem:36090 Driver
Scenario: Select to Filter the Calculations Page by Status
Given I have navigated to the Manage Calculations page
When I choose to filter my list by Status
Then the list view of calculations updates to display only calculations for the selected Status

@Workitem:36090 Driver
Scenario: Select to Filter the Calculations Page by Allocation Line
Given I have navigated to the Manage Calculations page
When I choose to filter my list by Allocation Lines
Then the list view of calculations updates to display only calculations for the selected Allocation Lines

@Workitem:36090 Driver
Scenario: Deselect Filter options on the Calculations Page
Given I have navigated to the Manage Calculations page
And ONE or MORE filter Options have previously been selected
When I deselect one or more filter options
Then All other filters will update
And display only those options that return results
And a total count of all filtered results is displayed above the list of results
And a count of the specific filter results is displayed
And the filter options are sorted in descending order by the count of results

@Workitem:37014 Driver
Scenario: Select To Filter the Calculations Page by the Search Option
Given I have navigated to the Manage Calculations page
And No additional filter options have been selected
When I enter text in the search field
And I click the search button
Then the list view of calculations updates to display only calculations that comply with the search term entered

@Workitem:37014 Driver
Scenario: Select To Filter the Calculations Page Using an Exact Calculation Name 
Given I have navigated to the Manage Calculations page
And No additional filter options have been selected
When the text i enter into a search matches a calculation name exactly
And I click the search button
Then the list view of calculations updates to display the specfic search calculation only

@Workitem:37014 Driver
Scenario: Select To Filter the Calculations Page by the Search Option When Active Filters Are In Place
Given I have navigated to the Manage Calculations page
And ONE or MORE filter Options have previously been selected
When I enter text in the search field
And I click the search button
Then the list view of calculations updates to display only calculations that comply with the search term entered
And the previously selected filter options

@Workitem:35457 Driver
Scenario: Verify the Edit Calculation Page
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
Then The Name of the specification is displayed
And The Description of the specification is displayed
And The Build Calculation button is disabled
And The Save Calculation button is disabled
And The Publish Calculation button is disabled

@Workitem:35457 Driver
Scenario: Edit and Build the Calculation Visual Basic Code
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have edited the visual basic code
And I click the Build Calculation button
Then I am notified that my code is compiling in the output box
And I am notified that my code has finished compiling in the output box
And the results of the compilation is recorded in the output box

@Workitem:35457 Driver
Scenario: Incorrectly Edit and Build a Calculation
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have incorrectly edited the visual basic code
And I click the Build Calculation button
Then I am notified that my code is compiling in the output box
And the error result of the compilation is recorded in the output box

@Workitem:35457 Driver
Scenario: Edit and Save a New Calculation Version of the Code
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have edited the visual basic code
And I click the Build Calculation button
Then I am notified that my code is compiling in the output box
And I am notified that my code has finished compiling in the output box
And the results of the compilation is recorded in the output box
And I click the Save Calculation button
And I am returned to the manage calculation page
And a full audit record of my calculation is created
