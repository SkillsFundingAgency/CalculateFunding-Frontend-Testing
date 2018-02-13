Feature: ManageSpecifications
	As a Funding Calculation Analyst I need to view the names and description of 
	Specifications that have already been created as well as edit an existing 
	specification OR create a new specification

@Workitem:35394 Driver
Scenario: View Current list of Specifications
	Given I have successfully navigated to the Home Page
	When I select Manage the Specification
	Then I am redirected to the Manage Specification page
	And The Default Specification Year is displayed correctly
	And A list of Specifications is displayed for the default year

@Workitem:35394 Driver
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
Scenario: Select to Create a New Specifications for a given Year
	Given I have successfully navigated to the Manage Specification Page
	And I have selected an academic year
	When I click on the Create a Specification Button
	Then I am redirected to the Create Specification Page

@Workitem:35384 Driver
Scenario: Create and Save a new Specification
	Given I have successfully navigated to the Create Specification Page
	When I enter a Name
	And I enter a Description
	And I choose a specification Funding Stream
	And I click the Save button
	Then I am redirected to the Manage Specification Page
	And My new specification is correctly listed
	And A Full Audit record is created

@Workitem:35384 Driver
Scenario: Create and Cancel a new Specification
	Given I have successfully navigated to the Create Specification Page
	When I enter a Name
	And I enter a Description
	And I choose a specification Funding Stream
	And I click the Cancel button
	Then I am redirected to the Manage Specification Page

@Workitem:35384 Driver
Scenario: Create a new Specification with an Existing Specification Name
	Given I have successfully navigated to the Create Specification Page
	When I enter an Existing Specification Name
	And I enter a Description
	And I choose a specification Funding Stream
	And I click the Save button
	Then A Unique Specification Name Error is Displayed

@Workitem:35384 Driver
Scenario Outline: Create and Save an incomplete Specification
	Given I have successfully navigated to the Create Specification Page
	And I have missed the field <name> and <funding> and <description>
	When I click the Save button
	Then the following Specification Error should be displayed for FieldName '<SpecFieldName>' and '<error>'

Examples: 
	 | SpecFieldName			| name         | funding | description           | error											 |
	 | Missing Spec Name		|              | DSG     | This is a Description | You must give a unique specification name		 |
	 | Missing Spec Funding		| Test Spec 02 |         | This is a Description | You must select at least one funding stream		 |
	 | Missing Spec Description	| Test Spec 03 | DSG     |                       | You must give a description for the specification |

@Workitem:35397 Driver
Scenario: View Current List of Policies
	Given I have successfully navigated to the Manage Specification Page
	When I click to view an existing Specification
	Then I am redirected to the Manage Policies Page
	And A list of Policies is displayed

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
	And A Full Audit record is created

@Workitem:35397 Driver
Scenario: Create and Cancel a new Policy
	Given I have successfully navigated to the Create Policy Page
	When I enter a Policy Name
	And I enter a Policy Description
	And I click the Cancel Policy Button
	Then I am redirected to the Manage Policies Page

@Workitem:35397 Driver
Scenario: Create and Save a new Policy with an Existing Specification Name
	Given I have successfully navigated to the Create Policy Page
	When I enter a Policy Name
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
	 | policyfieldname     | name        | description           | policyerror                                |
	 | Missing Name        |             | This is a Description | You must give a unique policy name         |
	 | Missing Description | Policy Name |                       | You must give a description for the policy |

@Workitem:35401 Driver
Scenario: Select to Create Calculation Specification
	Given I have successfully navigated to the Manage Policies Page
	When I click the Create calculation specification
	Then I am redirected to the Create Calculation Specification for Policy Page

@Workitem:35401 Driver
Scenario: Create and Save a new Calculation Specification
	Given I have successfully navigated to the Create Calculation Specification for Policy Page
	When I enter a Calculation Name
	And I choose a Policy or sub policy
	And I choose an Allocation Line
	And I enter a Calculation Description
	And I click the Save Calculation button
	Then I am redirected to the Manage Policies Page
	And My new Calculation is correctly listed
	And A Full Audit record is created

@Workitem:35401 Driver
Scenario: Create and Cancel a new Calculation Specification
	Given I have successfully navigated to the Create Calculation Specification for Policy Page
	When I enter a Calculation Name
	And I choose a Policy or sub policy
	And I choose an Allocation Line
	And I enter a Calculation Description
	And I click the Cancel Calculation button
	Then I am redirected to the Manage Policies Page

@Workitem:35401 Driver
Scenario: Create and Save a new Calculation Specification with an Existing Name
	Given I have successfully navigated to the Create Calculation Specification for Policy Page
	When I enter a Calculation Name
	And I choose a Policy or sub policy
	And I choose an Allocation Line
	And I enter a Calculation Description
	And I click the Save Calculation button
	Then A Unique Calculation Name Error is Displayed

@Workitem:35401 Driver
Scenario Outline: Create and Save an incomplete Calculation Specification
	Given I have successfully navigated to the Create Calculation Specification for Policy Page
	And I have missed the calculation field <name> and <policy> and <allocation> and <description>
	When I click the Save Calculation button
	Then the following Calculation Error should be displayed for FieldName '<CalculationFieldname>' and '<calcerror>'

Examples: 
	 | CalculationFieldname   | name | policy      | allocation      | description | calcerror                                       |
	 | MissingCalcName        |      | Test Spec03 | DSG Allocations | Error1      | You must give a unique calculation name         |
	 | MissingCalcPolicy      | Test |             | DSG Allocations | Error2      | You must select a policy or subpolicy           |
	 | MissingCalcAllocation  | Test | Test Spec03 |                 | Error3      | You must select an allocation line              |
	 | MissingCalcDescription | Test | Test Spec03 | DSG Allocations |			   | You must give a description for the calculation |

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
	And My new Sub Policy is correctly listed
	And A Full Audit record is created

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
	Given I have successfully navigated to the Create Sub Policy Page
	When I enter a Sub Policy Name
	And I choose a Policy from the dropdown
	And I enter a Sub Policy Description
	And I click the Save Sub Policy button
	Then A Unique Sub Policy Name Error is Displayed

@Workitem:35402 Driver
Scenario Outline: Create and Save an incomplete Sub Policy
	Given I have successfully navigated to the Create Sub Policy Page
	And  And I have missed the Sub Policy field <name> and <policy> and <description>
	When I click the Save Sub Policy button
	Then the following Sub Policy Error should be displayed for FieldName '<SubPolicyFieldname>' and '<subpolicyerror>'

Examples: 
	 | SubPolicyFieldname			| name         | policy			 | description | subpolicyerror									|
	 | SubPolicyNameMissing			|              | Test Spec03	 | Description | You must give a unique policy name				|
	 | SubPolicyPolicyMissing		| Test Spec 02 |				 | Description | You must select a policy						|
     | SubPolicyDescriptionMissing	| Test Spec 03 | Test Spec03	 |			   | You must give a description for the subpolicy	|