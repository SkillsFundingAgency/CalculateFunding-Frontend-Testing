Feature: UserPermissions
	
@Workitem 62977 62987 Driver
Scenario Outline: Update Permissions
Given the user '<userId>' has the following permissions for Funding Stream '<fundingStreamId>'
| Permission             | Granted |
| CanEditSpecification   | true    |
| CanCreateSpecification | true	   | 
| CanEditCalculation	 | true	   | 


Examples:
| userId                               | fundingStreamId |
| 40a8a720-2817-430e-9be1-98d337fd01f4 | PSG             |