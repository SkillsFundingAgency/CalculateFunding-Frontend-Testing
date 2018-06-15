Feature: ApproveFunding
As an overseer I need to be able to see the previously approved specifications with supporting information 
for a given funding period and funding stream so that I can make a decision to choose a specification 
that I want to take forward as the funding methodology for a given funding period and funding stream.

@Workitem 51062 Driver
Scenario: Navigate to the Choose Funding Specification Page
Given I have successfully navigated to the Home Page
When I select Approve funding
Then I am redirected to the approval options page
When I click on the Choose Funidng Specification Option
Then I am redirected to the Choose Funding Specification Page

@Workitem 51062 Driver
Scenario: Validate the Choose Funding Specification Page Filter options
Given I have navigated to the Choose Funding Specification Page
Then an option to filter the results by Funding Period is displayed
And the default Period is selected
And an option to select a Funding Stream is displayed
And a message is displayed instructing the User to select a Funding Stream

@Workitem 51062 Driver
Scenario: Validate the list of approved or updated specifications Headers
Given I have navigated to the Choose Funding Specification Page
Then an empty list of approved or updated specifications is displayed with the appropriate headers

@Workitem 51062 Driver
Scenario: Select a Funding Stream to display the list of approved or updated specifications
Given I have navigated to the Choose Funding Specification Page
When I choose a funding stream from the drop down option
Then the list of approved or updated specifications is updated to display all the appropriate specifications
And The Name of the Approved or Updated specification is displayed
And the Specificaton Funding Streams are displayed
And the Specification Funding Value is displayed
And the Specification Status is displayed
And the Provider QA coverage is displayed
And the QA tests passed is displayed
And the Calculations approved is displayed
And an option to Choose to Fund the Specification is displayed

@Workitem 51062 Driver
Scenario: Verify an Approved specifications is correctly displayed
Given I have previously Approved a Specification
And I have navigated to the Choose Funding Specification Page
When I choose a funding stream from the drop down option
Then the list of approved or updated specifications is updated to display all the appropriate specifications
And the specification marked as approved is displayed correctly

@Workitem 51062 Driver
Scenario: Verify an Updated specifications is correctly displayed
Given I have previously Updated a Specification
And I have navigated to the Choose Funding Specification Page
When I choose a funding stream from the drop down option
Then the list of approved or updated specifications is updated to display all the appropriate specifications
And the specification marked as updated is displayed correctly

@Workitem 51062 Driver
Scenario Outline: Select a Funding Stream for a different Funding Period to display the list of approved or updated specifications
Given I have previously Approved a Specification for a <year>
And I have navigated to the Choose Funding Specification Page
When I choose a funding stream from the drop down option
And I change the Funding Period selected to equal <year>
Then the list of approved or updated specifications is updated to display all the appropriate specifications
And The Name of the Approved or Updated specification is displayed
And the Specificaton Funding Streams are displayed
And the Specification Funding Value is displayed
And the Specification Status is displayed
And the Provider QA coverage is displayed
And the QA tests passed is displayed
And the Calculations approved is displayed
And an option to Choose to Fund the Specification is displayed

Examples: 
	 | year			|
	 | AY2017181	|
	 | AY2018191	|
	 | FY2017181	|
	 | FY2018191	|

