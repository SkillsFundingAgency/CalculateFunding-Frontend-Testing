Feature: UserPermissions
	
@Workitem 62977 62987 Driver
Scenario Outline: Update ALL Permissions for a Specified User to True
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Examples:
| userId                               | fundingStreamId |
| 1541b7d8-8e03-4be3-a114-d0d72d168d4b | PSG	         | 

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Creation of a New Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Then I can successfully create a new Specification

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |


@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Edit Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And I have Navigated to the Edit Specifiction Page
When I update the Specification Name
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page
And the Specification is correctly updated

Examples:
| userId                               | fundingStreamId | 
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |


@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Create Dataset Access
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Then I can successfully navigate to the Create Dataset page

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Create Specification Policy Access
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Then I can successfully navigate to the Create Policy page

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Create Calculation Specification Access
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    | 
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Then I can successfully navigate to the Create Calculation Specificaton page

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Create Sub Policy Access
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

Then I can successfully navigate to the Create Sub Policy page

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to Enable Specification Approval Access
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And A Policy has been previously created with a Unique Policy Name
When I choose to mark the associated Specification as Approved
Then the Specification should be marked as approved

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to allow access to Edit a Calculation
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
Then The Name of the specification is displayed

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to allow access to Select data source page
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And I have already created a Specification with the appropruiate dataset & schema associated
And I have navigated to a specification data relationships page where dataset relationships exist
When the data set data schema relationship does have a data source associated
Then the name of the data source is displayed
And the version of the data source is displayed
And an option to change the data source is displayed

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to allow access to Create a QA Test
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And I have previously created a new specification
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification
And I have created a Test for the Specified Specification
Then I am notified my test scenario has validated successfully
When I click the Enabled Save Button
Then I am redirected to the Edit quality assurance test page

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |

@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions for a Specified User to allow access to Edit a QA Test
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted |
| CanAdministerFundingStream | true    |
| CanCreateSpecification     | true    |
| CanEditSpecification       | true    |
| CanApproveSpecification    | true    |
| CanEditCalculations        | true    |
| CanMapDatasets             | true    |
| CanChooseFunding           | true    |
| CanRefreshFunding          | true    |
| CanApproveFunding          | true    |
| CanPublishFunding          | true    |
| CanCreateQaTests           | true    |
| CanEditQaTests             | true    | 

And I have successfully navigated to the Edit quality assurance test page
When I update the existing Test Name
And select to Save the change
Then the Test Name is updated
And I am presented with confirmation of the change

Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |




