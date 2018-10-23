Feature: ApproveFunding
As an overseer I need to be able to see the previously approved specifications with supporting information 
for a given funding period and funding stream so that I can make a decision to choose a specification 
that I want to take forward as the funding methodology for a given funding period and funding stream.

@Workitem 51062 Driver Smoke
Scenario: Navigate to the Choose Funding Specification Page
Given I have successfully navigated to the Home Page
When I select Funding approvals
Then I am redirected to the approval options page
When I click on the Choose Funding Specification Option
Then I am redirected to the Choose Funding Specification Page

@Workitem 51062 Driver Smoke
Scenario: Validate the Choose Funding Specification Page Filter options
Given I have navigated to the Choose Funding Specification Page
Then an option to filter the results by Funding Period is displayed
And the default Period is selected
And an option to select a Funding Stream is displayed
And a message is displayed instructing the User to select a Funding Stream

@Workitem 51062 Driver Smoke
Scenario: Validate the list of approved or updated specifications Headers
Given I have navigated to the Choose Funding Specification Page
Then an empty list of approved or updated specifications is displayed with the appropriate headers

@Workitem 51062 Driver Smoke
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


@Workitem 57915 Driver Smoke
Scenario: Navigate to the Approve and publish Specification Selection Page
Given I have successfully navigated to the Home Page
When I select Funding approvals
Then I am redirected to the approval options page
When I click on the Approve and publish funding Option
Then I am redirected to the Approve and Publish Specification Selection Page

@Workitem 57915 Driver Smoke
Scenario: Validate the Approve and publish Specification Selection Page
Given I have successfully navigated to the Approve and publish Specification Selection Page
Then the Dropdown option to select Select funding period is Displayed
And the Dropdown option to select Select specification is Displayed
And the Dropdown option to select Select funding stream is Displayed
And the option to then view funding button is displayed
And a warning is displayed that only one funding stream can be selected

@Workitem 57915 51065 Driver Smoke
Scenario: Select a Specification to Approve and Publish
Given I have successfully navigated to the Approve and publish Specification Selection Page
When I choose a Specifcation to View the Funding for
And I click the View Funding Button
Then I am redirected to the Approve and publish funding Page

@Workitem 51065 57158 Driver Smoke
Scenario: Validate the Approve and publish funding Page
Given I have navigated to the Approve and publish funding Page
Then an Approve Button is displayed and is Disabled
And a Publish Button is displayed and is Disabled
And a Select All Providers Tick Box is Displayed
And a Refresh Funding Button is displayed

@Workitem 51065 Driver Smoke
Scenario: The list of Provider Infomation is displayed for the Choosen Specification 
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
And the Name of the provider for the specification is displayed
And the UKPRN of the provider for the specification is displayed
And the Allocation Line Status (Held) for the specification is displayed
And the Allocation Line Status (Approved) for the specification is displayed
And the Allocation Line Status (Published) for the specification is displayed
And the Allocation Line Status Last Updated date for the specification is displayed
And the Specification Funding Amount for the specification is displayed

@Workitem 51065 Driver Smoke
Scenario: Expand a Provider to display the related QA Test Coverage Results
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
And an option to expand the Provider Information is displayed
When I choose to expand the Provider information
Then the QA Test Coverage information is displayed

@Workitem 51065 Driver
Scenario: Select All Providers to Enable the Approve and Publish Options
Given I have navigated to the Approve and publish funding Page
And the Provider list updates to display all the provider information for the selected specification
When I check the Select All tick box option
Then the Approve Button becomes enabled

@Workitem 51066 Driver
Scenario: Expand a Provider to display the related Funding Streams
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
And an option to expand the Provider Information is displayed
When I choose to expand the Provider information
Then the Funding Stream information is correctly displayed

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider Allocation Line to mark as Approved
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider Allocation Line with a status of Held
Then the Approve Button becomes enabled
When I click on the Approve Button
Then I am redirected to the Confirm Approval Page
When I click on the Confirm Approval Button
Then the Provider Allocation Line is successfully approved

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider Allocation Line to mark as Published
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider Allocation Line with a status of Approved
Then the Publish Button becomes enabled
When I click on the Publish Button
Then I am redirected to the Confirm Publish Page
When I click on the Confirm Publish Button
Then the Provider Allocation Line is successfully published

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider Funding Stream to mark as Approved
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider Funding Stream with a status of Held
Then the Approve Button becomes enabled
When I click on the Approve Button
Then I am redirected to the Confirm Approval Page
When I click on the Confirm Approval Button
Then the Provider Funding Stream is successfully approved

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider Funding Stream to mark as Published
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider Funding Stream with a status of Approved
Then the Publish Button becomes enabled
When I click on the Publish Button
Then I am redirected to the Confirm Publish Page
When I click on the Confirm Publish Button
Then the Provider Funding Stream is successfully published

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider to mark as Approved
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider with a status of Held
Then the Approve Button becomes enabled
When I click on the Approve Button
Then I am redirected to the Confirm Approval Page
When I click on the Confirm Approval Button
Then the Provider is successfully approved

@Workitem 51066 56069 57342 Driver
Scenario: Select a Provider to mark as Published
Given I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider with a status of Approved
Then the Publish Button becomes enabled
When I click on the Publish Button
Then I am redirected to the Confirm Publish Page
When I click on the Confirm Publish Button
Then the Provider is successfully published

@Workitem 57158 Driver
Scenario: Select the Refresh Funding option on the Approve and publish funding Page
Given I have navigated to the Approve and publish funding Page
When I click the Refresh Funding Button
Then the approve and Published page refreshes the funding for all providers based on any Calculation or data changes
And a Validation Update message is displayed correctly

@Workitem 51064 Driver
Scenario: Select the Choose Action for an Approved Specification
Given I have navigated to the Choose Funding Specification Page
When there is an availabe Funding Stream to Choose
And I click on the selected Specification Choose Button
Then I am redirected to the Confirmation to chose a specification for a funding stream and period page
And I am presented with the name of the specification I have selected
And I am presented with the funding period and the funding streams for the selected specification
And I am presented with a message explaining the consequences if were to choose the selected specification
And I am presented with an option choose the selected specification
And I am presented with an option to cancel choosing the selected specification

@Workitem 51064 Driver
Scenario: Select the Back option on the Confirmation to chose a specification page
Given I have navigated to the Choose Funding Specification Page
When there is an availabe Funding Stream to Choose
And I click on the selected Specification Choose Button
Then I am redirected to the Confirmation to chose a specification for a funding stream and period page
When I click on the Back do not choose option
Then I am redirected to the Choose Funding Specification Page

@Workitem 51064 Driver
Scenario: Select the View Funding Option for an Approved Specification
Given I have navigated to the Choose Funding Specification Page
When there is a previously Choosen Funding Stream available
And I click on the selected Specification View Funding option
Then I am redirected to the Approve and publish funding Page