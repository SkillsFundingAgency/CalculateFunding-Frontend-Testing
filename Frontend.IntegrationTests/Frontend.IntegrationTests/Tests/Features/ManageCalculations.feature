Feature: ManageCalculations
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