Feature: Home Page Navigation
	Vaildate I can correctly load and navigate from the hame page

@workitem:35383
Scenario: Select Manage The Specification Page
	Given I have successfully navigated to the Home Page
	When I select Manage the Specification
	Then I am redirected to the Manage Specification page

@workitem:35383
Scenario: Select Manage The Data Page
	Given I have successfully navigated to the Home Page
	When I select Manage the Data
	Then I am redirected to the Manage Data page

@workitem:35383
Scenario: Select Manage The Tests Page
	Given I have successfully navigated to the Home Page
	When I select Manage the tests
	Then I am redirected to the Manage Tests page

@workitem:35383
Scenario: Select Manage The Calculation Page
	Given I have successfully navigated to the Home Page
	When I select Manage the Calculations
	Then I am redirected to the Manage Calculations page

@workitem:35383
Scenario: Select View the Results Page
	Given I have successfully navigated to the Home Page
	When I select View the Results
	Then I am redirected to the View the Results page

@workitem:35383
Scenario: Select Publish the Results Page
	Given I have successfully navigated to the Home Page
	When I select Publish the results
	Then I am redirected to the Publish the Results page