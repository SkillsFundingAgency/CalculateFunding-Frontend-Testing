Feature: ManageSpecifications
	As a Funding Calculation Analyst I need to view the names and description of 
	Specifications that have already been created as well as edit an existing 
	specification OR create a new specification

@Workitem:35394 Driver
Scenario: View Current list of Specifications
Given I have successfully navigated to the Home Page
When I select Specifications
Then I am redirected to the Manage Specification page
And The Default Specification Year is displayed correctly
And A list of Specifications is displayed for the default year

@Workitem:35394 49352 Driver
Scenario: Change Current list of Specifications by Year
Given I have successfully navigated to the Manage Specification Page
When I change the Select A Year drop down to a different year
Then the list of specifications refreshes to display the selected years specifications

@Workitem:35394 Driver
Scenario: No Specifications for a given Year
Given I have successfully navigated to the Manage Specification Page
When I change the Select A Year drop down to a different year
And The selected Year has no specifications
Then the list of specifications refreshes to display no visable specifications

@Workitem:35384 Driver
Scenario: Create and Save a new Specification
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose a specification Funding Stream
And I click the Save button
Then I am redirected to the Manage Specification Page
And My new specification is correctly listed

@Workitem:35384 Driver
Scenario: Create and Save a new Specification selecting a different Funding Period
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a different specification Funding Period
And I choose a specification Funding Stream
And I click the Save button
Then I am redirected to the Manage Specification Page
And My new specification is correctly listed

@Workitem:35384 Driver
Scenario: Create and Cancel a new Specification
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose a specification Funding Stream
And I click the Cancel button
Then I am redirected to the Manage Specification Page

@Workitem:35384 Driver
Scenario: Create a new Specification with an Existing Specification Name
Given A Specification has been previously created with a Unique Name
And I have successfully navigated to the Create Specification Page
When I enter an Existing Specification Name
And I enter a Description
And I choose a specification Funding Period
And I choose a specification Funding Stream
And I click the Save button
Then A Unique Specification Name Error is Displayed

@Workitem:35384 Driver
Scenario: Create & Save an Incomplete Specification with no Funding Stream Selected
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I choose a specification Funding Period
And I enter a Description
And I click the Save button
Then A Unique Funding Stream Error is Displayed

@Workitem:35384 Driver
Scenario Outline: Create and Save an incomplete Specification
Given I have successfully navigated to the Create Specification Page
And I have missed the field <name> and <description>
And I choose a specification Funding Period
And I choose a specification Funding Stream
When I click the Save button
Then the following Specification Error should be displayed for FieldName '<SpecFieldName>' and '<error>'

Examples: 
	 | SpecFieldName			| name         | description           | error					|
	 | Missing Spec Name		|              | This is a Description | Enter a unique name	|
	 | Missing Spec Description	| Test Spec 03 |                       | Enter a description	|


@Workitem:35397 Driver
Scenario: Select to Create a New Policy
Given I have successfully navigated to the Manage Policies Page
When I click on the Create Policy Button
Then I am redirected to the Create Policy Page
	
@Workitem:35397 Driver
Scenario: Create and Save a new Policy
Given I have successfully navigated to the Create Policy Page
When I enter a Policy Name
And I enter a Policy Description
And I click the Save Policy button
Then I am redirected to the Manage Policies Page
And My new policy is correctly listed

@Workitem:35397 Driver
Scenario: Create and Cancel a new Policy
Given I have successfully navigated to the Create Policy Page
When I enter a Policy Name
And I enter a Policy Description
And I click the Cancel Policy Button
Then I am redirected to the Manage Policies Page

@Workitem:35397 Driver
Scenario: Create and Save a new Policy with an Existing Specification Name
Given A Policy has been previously created with a Unique Policy Name
And I have successfully navigated to the Create Policy Page for the previously created specification
When I enter an existing Policy Name
And I enter a Policy Description
And I click the Save Policy button
Then A Unique Policy Name Error is Displayed

@Workitem:35397 Driver
Scenario Outline: Create and Save an incomplete Policy
Given I have successfully navigated to the Create Policy Page
And I have missed the policy field <name> and <description>
When I click the Save Policy button
Then the following Policy Error should be displayed for FieldName '<policyfieldname>' and '<policyerror>'

	Examples: 
	 | policyfieldname     | name        | description           | policyerror         |
	 | Missing Name        |             | This is a Description | Enter a name        |
	 | Missing Description | Policy Name |                       | Enter a description |


@Workitem:35401 Driver
Scenario: Select to Create Calculation Specification
Given I have successfully navigated to the Manage Policies Page
When I click the Create calculation specification
Then I am redirected to the Create Calculation Specification for Policy Page

@Workitem:35401, 40012 Driver
Scenario: Create and Save a new Calculation Specification with Calculation Type Funding
Given I have successfully navigated to the Create Calculation Specification for Policy Page
When I enter a Calculation Name
And I choose a Policy or sub policy
And I choose funding calculation type
And I choose an Allocation Line
And I enter a Calculation Description
And I click the Save Calculation button
Then I am redirected to the Manage Policies Page
And My new Calculation is correctly listed

@Workitem:35401, 40012 Driver
Scenario: Create and Save a new Calculation Specification with Calculation Type Number
Given I have successfully navigated to the Create Calculation Specification for Policy Page
When I enter a Calculation Name
And I choose a Policy or sub policy
And I choose Number calculation type
And I enter a Calculation Description
And I click the Save Calculation button
Then I am redirected to the Manage Policies Page
And My new Calculation is correctly listed

@Workitem:35401, 40012 Driver
Scenario: Create and Cancel a new Calculation Specification
Given I have successfully navigated to the Create Calculation Specification for Policy Page
When I enter a Calculation Name
And I choose a Policy or sub policy
And I choose funding calculation type
And I choose an Allocation Line
And I enter a Calculation Description
And I click the Cancel Calculation button
Then I am redirected to the Manage Policies Page

@Workitem:35401, 40012 Driver
Scenario: Create and Save a new Calculation Specification with an Existing Name
Given A Calculation Specification has been previously created with a Unique Name
And I have successfully navigated to the Create Calculation Specification Page
When I enter an Existing Calculation Name
And I choose a Policy or sub policy
And I choose funding calculation type
And I choose an Allocation Line
And I enter a Calculation Description
And I click the Save Calculation button
Then A Unique Calculation Name Error is Displayed

@Workitem:35401, 40012 Driver
Scenario: Create and Save a new Calculation Specification without selecting a Calc Type
Given I have successfully navigated to the Create Calculation Specification for Policy Page
When I enter a Calculation Name
And I choose a Policy or sub policy
And I enter a Calculation Description
And I click the Save Calculation button
Then A Calculation Type Error is Displayed

@Workitem:35401, 40012 Driver
Scenario Outline: Create and Save an incomplete Funding Calculation Specification
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I click the Create calculation specification
And I have missed the calculation field <name> and <type> and <allocation> and <description>
And I have correctly selected a Policy
When I click the Save Calculation button
Then the following Calculation Error should be displayed for FieldName '<CalculationFieldname>' and '<calcerror>'

Examples: 
	 | CalculationFieldname			 | name		| type    | allocation			| description  | calcerror							   |
	 | MissingCalcFundingName		 |			| Funding | Additional Funding  | Error1       | Enter a unique name				   |
	 | MissingCalcFundingDescription | TestXYZ	| Funding | Additional Funding  |			   | Enter a description				   |
	 | MissingCalcFundingAllocation  | TestXYZ	| Funding |						| Error3	   | Select an allocation line			   |

@Workitem:35401, 40012 Driver
Scenario Outline: Create and Save an incomplete Number Calculation Specification
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I click the Create calculation specification
And I have not completed the following calculation fields <name> and <type> and <description>
And I have correctly selected a Policy
When I click the Save Calculation button
Then the following Number Calculation Error should be displayed for FieldName '<CalculationFieldname>' and '<calcerror>'

Examples: 
	 | CalculationFieldname			| name		| type		| description  | calcerror								|
	 | MissingCalcNumberName		|			| Number	| Error1       | Enter a unique name					|
	 | MissingCalcNumberDescription | TestXYZ	| Number	| 			   | Enter a description					|

@Workitem:35402 Driver
Scenario: Select to Create a Sub Policy
Given I have successfully navigated to the Manage Policies Page
When I click the select Create sub policy
Then I am redirected to the Create a Sub Policy Page

@Workitem:35402 Driver
Scenario: Create and Save a new Sub Policy
Given I have successfully navigated to the Create Sub Policy Page
When I enter a Sub Policy Name
And I choose a Policy from the dropdown
And I enter a Sub Policy Description
And I click the Save Sub Policy button
Then I am redirected to the Manage Policies Page
And the new Sub Policy is correctly listed

@Workitem:35402 Driver
Scenario: Create and Cancel a new Sub Policy
Given I have successfully navigated to the Create Sub Policy Page
When I enter a Sub Policy Name
And I choose a Policy from the dropdown
And I enter a Sub Policy Description
And I click the Cancel Sub Policy button
Then I am redirected to the Manage Specification Page

@Workitem:35402 Driver
Scenario: Create and Save a new Sub Policy with an Existing Name
Given A Sub Policy has been previously created with a Unique Name
And I have successfully navigated to the Create Sub Policy Page for the same Specification
When I enter a Sub Policy Name that already exists
And I choose a Policy from the dropdown
And I enter a Sub Policy Description
And I click the Save Sub Policy button
Then A Unique Sub Policy Name Error is Displayed

@Workitem:35402 Driver
Scenario Outline: Create and Save an incomplete Sub Policy
Given I have successfully navigated to the Create Sub Policy Page
And  And I have missed the Sub Policy field <name> and <description>
And I choose a Policy from the dropdown
When I click the Save Sub Policy button
Then the following Sub Policy Error should be displayed for FieldName '<SubPolicyFieldname>' and '<subpolicyerror>'

Examples: 
	 | SubPolicyFieldname			| name         | description | subpolicyerror		|
	 | SubPolicyNameMissing			|              | Description | Enter a name			|
     | SubPolicyDescriptionMissing	| Test Spec 03 |	         | Enter a description	|
	 
@Workitem:35402 Driver
Scenario: Create and Save an incomplete Sub Policy without selecting a Policy
Given I have successfully navigated to the Create Sub Policy Page
When I enter a Sub Policy Name
And I enter a Sub Policy Description
And I click the Save Sub Policy button
Then a Sub Policy Missing Policy Error should be displayed

@Workitem:40075, 40012 Driver
Scenario: Create and Save a new Calculation Specification without selecting an Allocation Line
Given I have successfully navigated to the Create Calculation Specification for Policy Page
When I enter a Calculation Name
And I choose a Policy or sub policy
And I choose funding calculation type
And I enter a Calculation Description
And I click the Save Calculation button
Then A Unique Allocation Error is Displayed


@Workitem:40032 Driver
Scenario: Create a New Specification and no alert about provider datasets is displayed
Given I have previously created a new specification
And redirected to the Manage Specificaiton Page
When I choose to view the datasets tab
Then No alert about provider datasets is displayed

@Workitem:40032 Driver
Scenario: Create a New Specification and Dataset without marking as provider data should display an Alert
Given I have previously created a new specification
And redirected to the Manage Specificaiton Page
When I choose to view the datasets tab
And I choose to create a new dataset without setting as Provider Data
And I am redirected to the DataSet page
Then the new dataset has been saved and displayed correctly
And An Alert that No dataset has been set as provider data should be displayed

@Workitem:40032 Driver
Scenario: Create a New Specification and New Dataset marked as provider data set should not display an Alert
Given I have previously created a new specification
And redirected to the Manage Specificaiton Page
When I choose to view the datasets tab
And I choose to create a new dataset set as Provider Data
And I am redirected to the DataSet page
Then the new dataset has been saved and displayed correctly
And No alert about provider datasets is displayed

@Workitem:49358 Driver
Scenario: Create and Save a new Specification with 2 Funding Streams selected
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose 2 specification Funding Streams
And I click the Save button
Then I am redirected to the Manage Specification Page
And My new specification is correctly listed


@Workitem:49358 Driver
Scenario: Create and Save a new Specification with 5 Funding Streams selected
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose 5 specification Funding Streams
And I click the Save button
Then I am redirected to the Manage Specification Page
And My new specification is correctly listed

@Workitem:49358 Driver
Scenario: Create and Save a new Specification with ALL Funding Streams selected
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose All specification Funding Streams
And I click the Save button
Then I am redirected to the Manage Specification Page
And My new specification is correctly listed

@Workitem:49358 Driver
Scenario: Create a new Specification with 2 Funding Streams selected then removed
Given I have successfully navigated to the Create Specification Page
When I enter a Name
And I enter a Description
And I choose a specification Funding Period
And I choose 2 specification Funding Streams
And I then select to remove a Funding Stream
Then the selected funding stream is removed from the new Specification

@Workitem:49359 Driver
Scenario: Verify Edit Policy Option within Manage Policies Page
Given I have previously created a new specification
And I have created a New Policy for that Specification
Then the Manage Policies Policy List displays the Edit Policy option

@Workitem:49360 Driver
Scenario: Verify Edit Sub Policy Option within Manage Policies Page
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Sub Policy for that Specification
Then the Manage Policies Policy List displays the Edit Sub Policy option

@Workitem:49359 Driver
Scenario: Successfully Edit an Existing Policies Policy Name
Given I have navigated to the Edit Policy Page
When I update the Policy Name
And click the Update Button
Then I am redirected back to the Manage Polices Page
And the Policy Name is correctly updated

@Workitem:49359 Driver
Scenario: Successfully Edit an Existing Policies Policy Description
Given I have navigated to the Edit Policy Page
When I update the Policy Description
And click the Update Button
Then I am redirected back to the Manage Polices Page
And the Policy Description is correctly updated

@Workitem:49359 Driver
Scenario: Cancel an Edit to an Existing Policy 
Given I have navigated to the Edit Policy Page
When I update the Policy Name
And I choose to click the Back Link
Then I am redirected back to the Manage Polices Page

@Workitem:49360 Driver
Scenario: Successfully Edit an Existing Sub Policies Name
Given I have navigated to the Edit Sub Policy Page
When I update the Sub Policy Name
And click the Update Button
Then I am redirected back to the Manage Polices Page
And the Sub Policy Name is correctly updated

@Workitem:49360 Driver
Scenario: Successfully Edit an Existing Sub Policies Description
Given I have navigated to the Edit Sub Policy Page
When I update the Sub Policy Description
And click the Update Button
Then I am redirected back to the Manage Polices Page
And the Sub Policy Description is correctly updated

@Workitem:49360 Driver
Scenario: Successfully Edit an Existing Sub Policies Associated Policy
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Sub Policy for that Specification
And I then create an additional Policy for the Specification
And I have selected to Edit the Sub Policy
When I update the Sub Policies associated Policy
And click the Update Button
Then I am redirected back to the Manage Polices Page
And the Sub Policy is shown as associated to the selected Policy

@Workitem:49360 Driver
Scenario: Cancel an Edit to an Existing Sub Policy 
Given I have navigated to the Edit Sub Policy Page
When I update the Sub Policy Name
And I choose to click the Back Link
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Verify Edit Specification Option within Manage Policies Page
Given I have previously created a new specification
And I have navigated to the Manage Policies Page
Then the Manage Policies Policy List displays the Edit Specification option

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification Name
Given I have navigated to the Edit Specification Page
When I update the Specification Name
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page
And the Specification is correctly updated

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification Description
Given I have navigated to the Edit Specification Page
When I update the Specification Description
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification Funding period
Given I have navigated to the Edit Specification Page
When I update the Specification Funding period
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page
And the Specification Funding Period has correctly updated

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification Funding stream
Given I have navigated to the Edit Specification Page
When I delete the existing Specification Funding stream
Then an Alert is displayed warning that no Funding Streams are associated to the specification
When I choose 2 New Funding Streams
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification for Multiple Funding streams
Given I have navigated to the Edit Specification Page
When I delete the existing Specification Funding stream
Then an Alert is displayed warning that no Funding Streams are associated to the specification
When I choose 5 New Funding Streams
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification for All Funding streams
Given I have navigated to the Edit Specification Page
When I delete the existing Specification Funding stream
Then an Alert is displayed warning that no Funding Streams are associated to the specification
When I choose All New Funding Streams
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Cancel an Edit to an Existing Specification
Given I have navigated to the Edit Specification Page
When I update the Specification Name
And I click the Cancel option
Then I am redirected back to the Manage Polices Page

@Workitem:49593 Driver
Scenario: Successfully Edit an Existing Specification for All fields
Given I have navigated to the Edit Specification Page
When I delete the existing Specification Funding stream
Then an Alert is displayed warning that no Funding Streams are associated to the specification
When I choose 2 New Funding Streams
And I update the Specification Funding period
And I update the Specification Description
And I update the Specification Name
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page
And the Specification is correctly updated
And the Specification Funding Period has correctly updated

@Workitem:49361 Driver
Scenario: Verify Edit Calculation Specification option within Manage Policies Page
Given I have created a new specification
And I have created a new policy
And I have created a new calculation specification
When I click on the calculation specifcation within the Manage Policies Page
Then I am redirected successfully to the Edit Calculation Specifcation Page

@Workitem:49361 Driver
Scenario: Validate Edit Calculation Specification Page when the Calculation Type is Funding
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
Then the option to edit the Calculation Specification Name is displayed
And the option to edit the Calculation Specification Description is displayed
And the option to edit the Calculation Specification Policy or Sub Policy is displayed
And the option to edit the Calculation Specification Calculation Type is displayed
And the option to edit the Calculation Specification Allocation Line is displayed
And an option to Save the Changes is displayed
And an option to cancel the changes is displayed

@Workitem:49361 Driver
Scenario: Validate Edit Calculation Specification Page when the Calculation Type is Number
Given I have successfully created a new Calculation Specification with Calculation Type of Number
And I have navigated to the Edit Calculation Page
Then the option to edit the Calculation Specification Name is displayed
And the option to edit the Calculation Specification Description is displayed
And the option to edit the Calculation Specification Policy or Sub Policy is displayed
And the option to edit the Calculation Specification Calculation Type is displayed
And an option to Save the Changes is displayed
And an option to cancel the changes is displayed

@Workitem:49361 Driver
Scenario: Edit an existing Calculation Specification Name
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton Name
Then I am redirected to the Manage Policies Page
And the Calculation Specification Name has been successfully updated

@Workitem:49361 Driver
Scenario: Edit an existing Calculation Specification Description
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton Description
Then I am redirected to the Manage Policies Page
And the Calculation Specification Description has been successfully updated

@Workitem:49361 Driver
Scenario: Edit an existing Calculation Specifications Allocation Line where the Calculation Type is Funding
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton Allocation Line 
Then I am redirected to the Manage Policies Page
And the Calculation Specification has been successfully updated

@Workitem:49361 Driver
Scenario: Edit an existing Calculation Specifications Calculation Type
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton Calculation Type 
Then I am redirected to the Manage Policies Page
And the Calculation Specification has been successfully updated

@Workitem:49361 Driver
Scenario: Edit an existing Calculation Specifications Policy
Given I have successfully created a new Calculation Specification
And I then create an additional Policy for the Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton Associated Policy
Then I am redirected to the Manage Policies Page
And the Calculation Specification associated policy has been successfully updated

@Workitem:49361 Driver
Scenario: Cancel an Edit to an existing Calculation Specification
Given I have successfully created a new Calculation Specification
And I have navigated to the Edit Calculation Page
When I update the existing Calculation Specificaton
And select to Cancel the edit
Then I am redirected to the Manage Policies Page

@Workitem:49352 Driver
Scenario: Filter Specifications list by Funding Stream
Given I have successfully navigated to the Manage Specification Page
When I choose to filter the list by Funding Stream
Then the list of specifications refreshes to display the filtered selection

@Workitem:49352 Driver
Scenario: Filter Specifications list by Status
Given I have successfully navigated to the Manage Specification Page
When I choose to filter the list by Status
Then the list of specifications refreshes to display the filtered selection

@Workitem:49352 Driver
Scenario: Clear All Filters selected for the Specifications list
Given I have successfully navigated to the Manage Specification Page
And I choose to filter the list
When I choose the Clear Filter option
Then the list of specifications refreshes to display all the specifications available

@Workitem:49352 Driver
Scenario: Verify the Specifications list Column Headers
Given I have successfully navigated to the Manage Specification Page
Then the list of specifications is displayed
And the following Headers are correctly displayed

@Workitem:49352 Driver
Scenario: Verify the Specifications list is displayed in descending order
Given I have successfully navigated to the Manage Specification Page
Then the list of specifications is displayed
And the displayed in descending order by Last Edit Date

@Workitem:49352 Driver
Scenario: Verify the Specifications list Column Infomation
Given I have successfully navigated to the Manage Specification Page
Then the list of specifications is displayed
And the following Headers are correctly displayed
And the Information in each column is displayed correctly

@Workitem:49352 Driver
Scenario: Verify the Specifications list More Infomation is Displayed correctly
Given I have successfully navigated to the Manage Specification Page
When I click on the More Option in for a specific Specification
Then the description of that specification is displayed
And the funding stream associated with the specification is displayed
And the funding period associated with the specification is displayed
And there is an option to edit the specification displayed

@Workitem:49356 Driver
Scenario: Verify the Manage Policies List Column Headers
Given I have successfully navigated to the Manage Policies Page
Then the list of associated Polcies and Calculations are displayed
And the following Specification related Headers are correctly displayed

@Workitem:49356 Driver
Scenario: Validate the Policy Data displayed within the Manage Policies List
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have successfully navigated to the Manage Policies Page for the new specification
Then the list of associated Polcies and Calculations are displayed
And the associated policies are displayed as rows in my table
And the name of the policy is displayed
And the description of the policy is displayed
And the last edited date time for the policy is displayed
And there is the ability to view more information about the policy

@Workitem:49356 Driver
Scenario: Validate the Calculation Data displayed within the Manage Policies List
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I then create an additional Policy for the Specification
And I have successfully navigated to the Manage Policies Page for the new specification
Then the list of associated Polcies and Calculations are displayed
And the associated calculations are displayed as rows in my table
And I am able to see the name of the calculation specifications
And the description of the calculation specification is displayed
And I am able to select to view more details about the calculations specification
And the type of the calculation specification is displayed

@Workitem:49356 Driver
Scenario: Verify the Policy More option displays the Full Description within the Manage Policies List
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have successfully navigated to the Manage Policies Page for the new specification
And the list of associated Polcies and Calculations are displayed
And the associated policies are displayed as rows in my table
When I click on the More drop down option
Then I can view the full policy description

@Workitem:49356 Driver
Scenario: Verify the Calculation More option displays the Full Description within the Manage Policies List
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have successfully navigated to the Manage Policies Page for the new specification
And the list of associated Polcies and Calculations are displayed
And the associated calculations are displayed as rows in my table
When I click on the Calculation More drop down option
Then I can view the full Calculation description

@Workitem:49356 Driver
Scenario: Display a Policies information by selecting the Jump To option within the Manage Policies List
Given I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I then create an additional Policy for the Specification
And I have successfully navigated to the Manage Policies Page for the new specification
When I click on the Jump To Drop down
Then I am able to select from all the available policies
And jump to the displayed information for the selected policy

@Workitem:49356 Driver
Scenario: Verify the Expand and Collapse All option for the Policy List on the Manage Policies Page
Given I have successfully navigated to the Manage Policies Page
When I click the Expand All Link
Then All rows in the Policy List are expanded to display all additional information
When I click the Expand All Link
Then All rows in the Policy List are collapsed again

@Workitem:50078 Driver
Scenario: Verify the Approve Specification Option on the Manage Policies Page
Given I have previously created a new specification
And I have successfully navigated to the Manage Policies Page for the new specification
Then the Approve Specification option is correctly displayed

@Workitem:50078 Driver
Scenario: Verify that a Specification with an associated Policy can be marked as Approved
Given A Policy has been previously created with a Unique Policy Name
When I choose to mark the associated Specification as Approved
Then the Specification should be marked as approved

@Workitem:50078 Driver
Scenario: Verify that a Specification with an associated Calculation can be marked as Approved
Given A Calculation Specification has been previously created with a Unique Name
When I choose to mark the associated Specification as Approved
Then the Specification should be marked as approved

@Workitem:50078 Driver
Scenario: Verify that a Specification with an associated Sub Policy can be marked as Approved
Given A Sub Policy has been previously created with a Unique Name
When I choose to mark the associated Specification as Approved
Then the Specification should be marked as approved