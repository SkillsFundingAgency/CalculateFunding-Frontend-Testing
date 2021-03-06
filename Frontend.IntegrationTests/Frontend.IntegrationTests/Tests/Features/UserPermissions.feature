﻿Feature: UserPermissions
	
@Workitem 62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem 62987 Driver_TestUser
Scenario Outline: Update ALL Permissions for a Specified User to False
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Then I can successfully create a new Specification

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have Navigated to the Edit Specifiction Page
When I update the Specification Name
And click the Update Specification Button
Then I am redirected back to the Manage Polices Page
And the Specification is correctly updated

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Then I can successfully navigate to the Create Dataset page

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Then I can successfully navigate to the Create Policy page

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Then I can successfully navigate to the Create Calculation Specificaton page

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

Then I can successfully navigate to the Create Sub Policy page

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And A Policy has been previously created with a Unique Policy Name
When I choose to mark the associated Specification as Approved
Then the Specification should be marked as approved

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have navigated to the Manage Calculations page
And I click on a calculation in the displayed list
When The Edit Calculation screen is displayed
Then The Name of the specification is displayed

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have already created a Specification with the appropruiate dataset & schema associated
And I have navigated to a specification data relationships page where dataset relationships exist
When the data set data schema relationship does have a data source associated
Then the name of the data source is displayed
And the version of the data source is displayed
And an option to change the data source is displayed

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

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
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem  62987 Driver_TestUser
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have successfully navigated to the Edit quality assurance test page
When I update the existing Test Name
And select to Save the change
Then the Test Name is updated
And I am presented with confirmation of the change

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
Scenario Outline: Update Permissions for a Specified User to allow access to Refresh Funding
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have navigated to the Approve and publish funding Page
When I click the Refresh Funding Button
Then the approve and Published page refreshes the funding for all providers based on any Calculation or data changes
And a Validation Update message is displayed correctly

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
Scenario Outline: Update Permissions for a Specified User to allow access to Approve Funding Stream
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider with a status of Held
Then the Approve Button becomes enabled

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem  62987 Driver_TestUser
Scenario Outline: Update Permissions for a Specified User to allow access to Publish Funding Stream
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
| CanDeleteSpecification     | true    | 
| CanDeleteCalculations      | true    | 
| CanDeleteQaTests           | true    | 

And I have navigated to the Approve and publish funding Page
Then the Provider list updates to display all the provider information for the selected specification
When I Choose a Provider with a status of Approved
Then the Publish Button becomes enabled

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Edit a Calculation
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 


And I have navigated to the Manage Calculations page
When I click on a calculation in the list
Then I am navigated to the Edit Calculation screen
And A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Create a Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have successfully navigated to the Create Specification Page
Then A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Create a Policy
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have successfully navigated to the Manage Policies Page
When I click on the Create Policy Button
Then I am redirected to the Create Policy Page
And A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Edit a Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | true    |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have navigated to the Edit Specification Page
Then A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Create a Dataset
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | true    |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have successfully navigated to the Manage Policies Page
When I click on the Create Dataset Button
Then I am redirected to the Create Dataset Page
And A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Map a datasets for a Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have navigated to Map data sources to datasets page
When I click on a specification name
Then I am taken to the specification data relationships page for that specification
And A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |

@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Change the Mapping for this Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

Given I have navigated to the specification data relationships page
Then A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Create a QA Test
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have successfully navigated to the Create quality assurance test page
Then A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Edit a QA Test
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

And I have successfully navigated to the Quality Assurance Test Scenario List Page
When I choose to select an Existing QA Test from the list displayed
Then I am redirected to the Edit quality assurance test page
And A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |


@Workitem 5735 Driver_TestUser
Scenario Outline: User Does Not have Permissions to Approve Funding for a Specification
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission                 | Granted | 
| CanAdministerFundingStream | false   |
| CanCreateSpecification     | false   |
| CanEditSpecification       | false   |
| CanApproveSpecification    | false   |
| CanEditCalculations        | false   |
| CanMapDatasets             | false   |
| CanChooseFunding           | false   |
| CanRefreshFunding          | false   |
| CanApproveFunding          | false   |
| CanPublishFunding          | false   |
| CanCreateQaTests           | false   |
| CanEditQaTests             | false   | 
| CanDeleteSpecification     | false   | 
| CanDeleteCalculations      | false   | 
| CanDeleteQaTests           | false   | 

Given I have navigated to the Approve and publish funding Page for PE and Sport Specification
Then A Notification is diplayed to inform the user they do not have permission for this action

Examples:
| userId                               | fundingStreamId |
| 515afc96-c2c7-4d66-b62b-364b5619e359 | PSG             |