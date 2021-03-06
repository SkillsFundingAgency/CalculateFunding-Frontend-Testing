﻿Feature: ManageCalculations
	As a Funding Calculation Developer
	I need to view a list of specified calculations
	So that I can select the calculation I want to create OR edit as well as be able to view 
	an audit history of a specific calculation

@Workitem:6678 Driver Smoke
Scenario: View Current list of Calculations
Given I have successfully navigated to the Home Page
When I select Calculations
Then I am redirected to the Manage Calculations page
And the page lists the most recent calculations

@Workitem:6678 Driver Smoke
Scenario: View Edit Calculations Page
Given I have navigated to the Manage Calculations page
When I click on a calculation in the list
Then I am navigated to the Edit Calculation screen

@Workitem:6678 Driver Smoke
Scenario: Current list of Calculations Pagination
Given I have navigated to the Manage Calculations page
When there is greater than 50 calculations
Then The the correct pagination options are displayed
When I click a pagination option
Then My list refreshes to display the selected page of calculations

@Workitem:6686 Driver Smoke
Scenario: Verify the Filter options on the Calculations Page
Given I have navigated to the Manage Calculations page
Then I am presented a filter option to select ONE or MORE Year
And I am presented a filter option to select ONE or MORE calculation status
And I am presented a filter option to select ONE or MORE funding stream(s)
And I am presented a filter option to select ONE or MORE policy
And I am presented a filter option to select ONE or MORE allocation lines
And the filters are defaulted to show all calculations that are specified

@Workitem:6686 Driver Smoke
Scenario: Verify the Calculations Results Displayed on the Calculations Page
Given I have navigated to the Manage Calculations page
Then I am presented with a list of Calculation results
And the appropriate information is displayed for each calculation

@Workitem:6686 Driver
Scenario: Select to Filter the Calculations Page by Academic Year
Given I have navigated to the Manage Calculations page
And the filters are defaulted to show all calculations that are specified
When I chosen to select the academic year filter option
Then All other filters will update
And display only those options that return results
And a total count of all filtered results is displayed above the list of results
And a count of the specific filter results is displayed
And the filter options are sorted in descending order by the count of results

@Workitem:6686 Driver
Scenario: Select to Filter the Calculations Page by Funding Stream
Given I have navigated to the Manage Calculations page
When I choose to filter my list by funding stream
Then the list view of calculations updates to display only calculations for the selected funding streams

@Workitem:6686 Driver
Scenario: Select to Filter the Calculations Page by Policy Specification
Given I have navigated to the Manage Calculations page
When I choose to filter my list by policy
Then the list view of calculations updates to display only calculations for the selected policy

@Workitem:6686 Driver
Scenario: Select to Filter the Calculations Page by Status
Given I have navigated to the Manage Calculations page
When I choose to filter my list by Status
Then the list view of calculations updates to display only calculations for the selected Status

@Workitem:6686 Driver
Scenario: Select to Filter the Calculations Page by Allocation Line
Given I have navigated to the Manage Calculations page
When I choose to filter my list by Allocation Lines
Then the list view of calculations updates to display only calculations for the selected Allocation Lines

@Workitem:6686 Driver
Scenario: Deselect Filter options on the Calculations Page
Given I have navigated to the Manage Calculations page
And ONE or MORE filter Options have previously been selected
When I deselect one or more filter options
Then All other filters will update
And display only those options that return results
And a total count of all filtered results is displayed above the list of results
And a count of the specific filter results is displayed
And the filter options are sorted in descending order by the count of results

@Workitem:6695 Driver
Scenario: Select To Filter the Calculations Page by the Search Option
Given I have navigated to the Manage Calculations page
And No additional filter options have been selected
When I enter text in the search field
And I click the search button
Then the list view of calculations updates to display only calculations that comply with the search term entered

@Workitem:6695 Driver
Scenario: Select To Filter the Calculations Page by the Search Option When Active Filters Are In Place
Given I have navigated to the Manage Calculations page
And ONE or MORE filter Options have previously been selected
When I enter text in the search field
And I click the search button
Then the list view of calculations updates to display only calculations that comply with the search term entered
And the previously selected filter options

@Workitem:6669, 5617 Driver Smoke
Scenario: Verify the Edit Calculation Page
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
Then The Name of the specification is displayed
And The Description of the specification is displayed
And The Build Calculation button is disabled
And The Save Calculation button is disabled
And the Option to view the related Calculation Results is displayed

@Workitem:6669 Driver
Scenario: Edit and Build the Calculation Visual Basic Code
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have edited the visual basic code
And I click the Build Calculation button
Then I am notified that my code is compiling in the output box
And I am notified that my code has finished compiling in the output box
And the results of the compilation is recorded in the output box

@Workitem:6669 Driver
Scenario: Incorrectly Edit and Build a Calculation
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have incorrectly edited the visual basic code
And I click the Build Calculation button
Then I am notified that my code is compiling in the output box
And the error result of the compilation is recorded in the output box

@Workitem:6669 Driver
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

@Workitem:6669 7910 Driver
Scenario: Leave the Edit Calculation Page without saving your changes
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
And I have edited the visual basic code
And I click on the Edit Calculation Back Link
And I click the Leave Button in the Windows Dialog box
Then I am returned to the manage calculation page

@Workitem:6675 Driver Smoke
Scenario: Verify the Compare Calculation Versions Page
Given I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
And The Edit Calculation screen is displayed
When I click the View previous versions link 
Then I am redirected to the Compare Calculation Versions page
And a list view of calculation versions is displayed

@Workitem:6675 Driver
Scenario: Validate Compare Calculation Versions Page Calculation Information
Given I have navigated to the Compare Calculation Versions page
Then I can see who created the calculation version as the Author 
And the date time the version was Created or Updated
And the calculation version number is displayed
And the calculation status is displayed
And the list is sorted in descending order by Updated date

@Workitem:6682 Driver
Scenario: Select One Previous Calculation Code Version from the Compare Calculation Versions page
Given I have navigated to the Compare Calculation Versions page
And More than one version of code has been previously saved
When I click only one version of the calculation code
Then The Compare Calculations button remains disabled

@Workitem:6682 Driver
Scenario: Select Two Previous Calculation Code Versions from the Compare Calculation Versions page
Given I have navigated to the Compare Calculation Versions page
And More than one version of code has been previously saved
When I click to select two versions of the code
And I click the Compare The Calculations button
Then I am redirected to the Calculation Comparison page

@Workitem:6682 Driver
Scenario: View the Calculation Comparison Page
Given I have navigated to the Calculation Comparison page
Then the status of each version is correctly displayed
And the date time each version was Created or Updated is displayed
And the name of the Author of each version is displayed
And The applicable code for both versions is displayed side by side
And The Inline Code Editor option can be selected
And The Back Link can be selected to return to the Previous Calculation Page

@Workitem:6625 Driver
Scenario: Validate Approve Calculation Option on the Edit Calculation Page
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
When I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
Then I am presented with the View Calculation Page 
And The option to Approve the Calculation is displayed correctly

@Workitem:6625 Driver
Scenario: Verify that a Calculation can be marked as Approved
Given A Calculation Specification has been previously created with a Unique Name
When I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I choose to mark the Calculation as Approved
Then the Calculation should be updated to show the status is Approved

@Workitem:5320 Driver
Scenario: Validate an Aggregate Sum Function for calculation results in the calculation script
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created two new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation
And I navigate to the View Calculations Page
And I open the Provider Results for the Aggregate Calculation
Then The total value for each Provider is the Sum of the number of Providers multipled by the first calculations returned value

@Workitem:5320 Driver
Scenario: Validate an Aggregate Avg Function for calculation results in the calculation script
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created two new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation and add the Avg
And I navigate to the View Calculations Page
And I open the Provider Results for the Aggregate Calculation
Then The total value for each Provider is the Sum of the number of Providers multipled by the first calculations returned value plus the Average Amount

@Workitem:5320 Driver
Scenario: Validate an Aggregate Max Function for calculation results in the calculation script
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created two new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation and add the Max
And I navigate to the View Calculations Page
And I open the Provider Results for the Aggregate Calculation
Then The total value for each Provider is the Sum of the number of Providers multipled by the first calculations returned value plus the Max Amount

@Workitem:5320 Driver
Scenario: Validate an Aggregate Min Function for calculation results in the calculation script
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created two new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation and add the Min
And I navigate to the View Calculations Page
And I open the Provider Results for the Aggregate Calculation
Then The total value for each Provider is the Sum of the number of Providers multipled by the first calculations returned value plus the Min Amount

@Workitem:5320 Driver
Scenario: Validate the validation error when an Aggregate Function calculation calls another Aggregated Calculation
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created Three new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation
Then I choose to view the Additional Aggregate Calculation I have created
And I edit the second calculation to Sum the second calculation an approriate error is displayed

@Workitem:5617 Driver
Scenario: Verify the View Results Link within the Edit Calculation Page
Given I have previously created a new Pe & Sport Specification
And I have created a New Policy for that Specification
And I have created two new Number calculations ready to be aggregated
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I navigate to the Manage Calculations Page
And I choose to view the new Calculation I have created
And I edit the first calculation to return the value of 100
And I choose to view the new Aggregate Calculation I have created
And I edit the second calculation to Sum the first calculation
And I choose to view the new Aggregate Calculation I have created
Then the Option to view the related Calculation Results is available to select
And I am then redirtected to the Calculation Provider Results Page