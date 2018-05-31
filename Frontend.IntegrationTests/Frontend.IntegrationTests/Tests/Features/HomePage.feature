Feature: Home Page Navigation
	Vaildate I can correctly load and navigate from the hame page

@workitem:35383 Driver
Scenario: Select Manage The Specification Page
	Given I have successfully navigated to the Home Page
	When I select Specifications
	Then I am redirected to the Manage Specification page

@workitem:35383 Driver
Scenario: Select Manage The Data Page
	Given I have successfully navigated to the Home Page
	When I select Manage data
	Then I am redirected to the Manage Data page

@workitem:35383 Driver
Scenario: Select Manage The Tests Page
	Given I have successfully navigated to the Home Page
	When I select Quality assurance
	Then I am redirected to the Manage Tests page

@workitem:35383 Driver
Scenario: Select Manage The Calculation Page
	Given I have successfully navigated to the Home Page
	When I select Calculations
	Then I am redirected to the Manage Calculations page

@workitem:35383 Driver
Scenario: Select View the Results Page
	Given I have successfully navigated to the Home Page
	When I select View results
	Then I am redirected to the View the Results Options page

@workitem:35383 Driver
Scenario: Select Publish the Results Page
	Given I have successfully navigated to the Home Page
	When I select Approve funding
	Then I am redirected to the Publish the Results page
