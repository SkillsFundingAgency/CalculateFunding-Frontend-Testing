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
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             | 


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


