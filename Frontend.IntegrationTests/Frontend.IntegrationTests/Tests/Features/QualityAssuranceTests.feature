Feature: Quality Assurance Tests
As a funding calculation analyst I need to see a list of test scenarios that have been created 
So that I can establish if I need to edit or create scenarios to further quality assure the funding that has been calculated for providers

@Workitem: 36666 Driver
Scenario: Verify the Quality Assurance Test Scenario List Page
Given I have successfully navigated to the Home Page
When I select Quality assurance
Then I am redirected to the Manage Tests page
And a Search Tests funciton is displayed
And an option to create a new QA Test is displayed

@Workitem: 36666 Driver
Scenario: Verify the Quality Assurance Test Scenario List Page Counts
Given I have successfully navigated to the Home Page
When I select Quality assurance
Then I am redirected to the Manage Tests page
And the list shows up to 50 Test Scenarios
And the total Test Scenario Count is displayed

@Workitem: 36666 Driver
Scenario: Verify the Quality Assurance Test Scenario List Page Pagination
Given I have successfully navigated to the Home Page
When I select Quality assurance
Then I am redirected to the Manage Tests page
When I have over 50 Test Scenarios listed
And I click to navigate to the next page of 50 test scenarios
Then my test scenarios list view displays the next 50 results
And I am able to navigate to the previous page of 50 test scenarios

@Workitem: 36666 Driver
Scenario: Verify Listed Test Scenario Information
Given I have successfully navigated to the Home Page
When I select Quality assurance
Then I am redirected to the Manage Tests page
And the name of test scenario is displayed
And the description of the test scenario is displayed
And the current status of the test scenario is displayed
And the specification that the test is associated with is displayed
And the date time the test scenario was last updated is displayed