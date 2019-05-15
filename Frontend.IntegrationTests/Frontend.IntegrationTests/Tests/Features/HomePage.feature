Feature: Home Page Navigation
	Vaildate I can correctly load and navigate from the hame page

@workitem:6508 Driver
Scenario: Select Manage The Specification Page
Given I have successfully navigated to the Home Page
When I select Specifications
Then I am redirected to the Manage Specification page

@workitem:6508 Driver
Scenario: Select Manage The Data Page
Given I have successfully navigated to the Home Page
When I select Manage data
Then I am redirected to the Manage Data page

@workitem:6508 Driver
Scenario: Select Manage The Tests Page
Given I have successfully navigated to the Home Page
When I select Quality assurance tests
Then I am redirected to the Manage Tests page

@workitem:6508 Driver
Scenario: Select Manage The Calculation Page
Given I have successfully navigated to the Home Page
When I select Calculations
Then I am redirected to the Manage Calculations page

@workitem:6508 Driver
Scenario: Select View the Results Page
Given I have successfully navigated to the Home Page
When I select View results
Then I am redirected to the View the Results Options page

@workitem:6508 51061 Driver
Scenario: Select Approve funding Page
Given I have successfully navigated to the Home Page
When I select Funding approvals
Then I am redirected to the approval options page
And an option to select to Choose funding specification is displayed
And an option to select to Approve and publish funding is displayed

@workitem:52590 Driver
Scenario: Validate the User Survey Details and Link
Given I have successfully navigated to the Home Page
Then The Survey Text is displayed correctly on the page
And the link to the Survey form is displayed correctly
And the Link loads the correct Survey page

@workitem:52651 Driver
Scenario: Validate 404 Error Page
Given I have successfully navigated to the Home Page
When I select Specifications
Then I am redirected to the Manage Specification page
When I update the URL to an incorrect end point
Then a Page Not Found error message is played
And a link is displayed to return to the Home page
And a link is displayed to log a Service Desk Incident

@workitem:53379 Driver
Scenario: Log in using AD User Authentication
Given I have successfully navigated to the Microsoft Login page
When I enter valid User Log in details
Then I am redirected to the Department for Education sign in page
When I enter valid DfE User Credentials
Then I am redirected to the Home Page

@workitem:53379 Driver
Scenario: Log in using Invalid AD User Authentication
Given I have successfully navigated to the Microsoft Login page
When I enter Invalid User Log in details
Then I am redirected to the Department for Education sign in page
When I enter Invalid DfE User Credentials
Then an appropriate Incorrect user ID or passworderror message is displayed

@workitem:56627 Driver
Scenario: Select The Specification Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select Specifications
Then I am redirected to the Manage Specification page

@workitem:56627 Driver
Scenario: Select the Calculations Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select Calculations
Then I am redirected to the Manage Calculations page

@workitem:56627 Driver
Scenario: Select the Manage data Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select Manage Data
Then I am redirected to the Manage Data page

@workitem:56627 Driver
Scenario: Select the Quality assurance tests Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select Quality assurance tests
Then I am redirected to the Manage Tests page

@workitem:56627 Driver
Scenario: Select the View results Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select View results
Then I am redirected to the View the Results Options page

@workitem:56627 Driver
Scenario: Select the Funding approvals Page from the Top Navigation
Given I have successfully navigated to the Manage Specification Page
When I select Funding approvals
Then I am redirected to the approval options page