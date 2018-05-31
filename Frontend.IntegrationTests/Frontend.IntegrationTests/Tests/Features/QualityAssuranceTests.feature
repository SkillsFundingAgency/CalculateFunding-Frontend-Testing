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

@Workitem: 36667 Driver
Scenario: View the Quality Assurance Create quality assurance test page
Given I have successfully navigated to the Quality Assurance Test Scenario List Page
When I click the Create QA Test Button
Then I am redirected to the Create quality assurance test page

@Workitem: 36667 Driver
Scenario: Verify the Quality Assurance Create quality assurance test page
Given I have successfully navigated to the Create quality assurance test page
Then there is a field displayed where I can name my test scenario
And there is a field displayed where I can describe my test scenario
And there is an option to select the specification my test is linked to
And there is a monaco text editor field displayed
And there is a disabled option to select to validate the test
And the save option is disabled

@Workitem: 36667 Driver
Scenario: Enable Valiadate QA Test Button on the Create quality assurance test page
Given I have successfully navigated to the Create quality assurance test page
When I have choosen a specification from the drop down to link my test to
And I have entered a Test Name for my QA Test
And I have entered a description for my QA Test
And I have entered a text in the Test Scenario editor for my QA Test
Then the Valiadate QA Test Button should be Enabled

@Workitem: 36667 Driver
Scenario: Valiadate New QA Test script on the Create quality assurance test page
Given I have successfully navigated to the Create quality assurance test page
When I have choosen a specification from the drop down to link my test to
And I have entered a Test Name for my QA Test
And I have entered a description for my QA Test
And I have entered a text in the Test Scenario editor for my QA Test
Then the Valiadate QA Test Button should be Enabled
When I click the Validate QA Test Button
Then I am notified that the code being verified is in progress
And I am notified that the code being verified is complete

@Workitem: 36667 Driver
Scenario: Valiadate an incorrect QA Test script on the Create quality assurance test page
Given I have successfully navigated to the Create quality assurance test page
And I have completed the required QA Test Scenario fields 
When I enter incorrect text in to the Test Scenario editor
And I click the Validate QA Test Button
Then I am notified that the Test has not validated successfully 
And an appropriate error message is displayed
And the save option remains disabled

@Workitem: 36667 Driver
Scenario: Valiadate a New QA Test script without a Test Name or Description
Given I have successfully navigated to the Create quality assurance test page
When I have choosen a specification from the drop down to link my test to
And I have entered a text in the Test Scenario editor for my QA Test
Then the Valiadate QA Test Button should be Enabled
When I click the Validate QA Test Button
Then I am notified that the code being verified is in progress
And I am notified that the code being verified is complete

@Workitem: 36667 Driver
Scenario: Valiadate New QA Test script without a specification selected
Given I have successfully navigated to the Create quality assurance test page
When I have entered a Test Name for my QA Test
And I have entered a description for my QA Test
Then the Validate QA Test Button remains disabled

@Workitem: 36667 Driver
Scenario: Save a New QA Test script without a Test Name or Description
Given I have created a New Specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I edit the New Calculation for that Specification
And I have created a Test for the Specified Specification missing a Name and Description
Then I am notified my test scenario has validated successfully
When I click the Enabled Save Button
Then an error message is displayed to to notify that a Test Name has not been entered
And an error message is displayed to to notify that a Test Description has not been entered

@Workitem: 36667 Driver
Scenario: Save a New Valid QA Test script
Given I have created a New Specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I edit the New Calculation for that Specification
And I have created a Test for the Specified Specification
Then I am notified my test scenario has validated successfully
When I click the Enabled Save Button
Then I am redirected to the Edit quality assurance test page

@Workitem: 36691 Driver
Scenario: View the Edit quality assurance test page
Given I have successfully navigated to the Quality Assurance Test Scenario List Page
When I choose to select an Existing QA Test from the list displayed
Then I am redirected to the Edit quality assurance test page
And the associated Specification name is displayed
And the Edit QA Test Name field is displayed
And the Edit Description field is displayed
And the existing QA Test code is displayed in the Monaco Text Editor

@Workitem: 36691 Driver
Scenario: Edit the Name of an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I update the existing Test Name
And select to Save the change
Then the Test Name is updated
And I am presented with confirmation of the change

@Workitem: 36691 Driver
Scenario: Edit the Description of an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I update the existing Test Description
And select to Save the change
Then the Test Description is updated
And I am presented with confirmation of the change

@Workitem: 36691 Driver
Scenario: Edit the Test for an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I Update the existing Test
And I Validate the Test
And select to Save the change
Then I am presented with confirmation of the change

@Workitem: 36691 Driver
Scenario: Edit the Test Incorrectly for an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I Update the existing Test Incorrectly
And I Validate the Incorrect Test
Then I am presented with a failed validation message

@Workitem: 36691 Driver
Scenario: Incorrectly Edit the Name of an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I Incorrectly update the existing Test Name
And select to Save the change
Then An Enter a unique name Error is displayed

@Workitem: 36691 Driver
Scenario: Incorrectly Edit the Description of an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I Incorrectly update the existing Test Description
And select to Save the change
Then An Enter a description Error is displayed

@Workitem: 36691 Driver
Scenario: Cancel an Edit to an Existing quality assurance test
Given I have successfully navigated to the Edit quality assurance test page
When I update the existing Test Name
And I click on the Back link
Then I am redirected back to the Quality Assurance Test Scenario List Page
