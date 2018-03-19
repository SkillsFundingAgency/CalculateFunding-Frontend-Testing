Feature: ViewResults
As a funding calculation analyst
I need to see a list of providers and the funding that has been calculated for them
So that I can review if the funding that has been calculated is as expected and I need to view 
the funding a provider has been calculated across all of ESFA's allocation lines
So that I can ensure the funding calculated for that provider is correct before publishing the allocation to the provider

@Workitem:37466 Driver
Scenario: Verify the View Provider Results Page Results list
Given I have successfully navigated to the Home Page
When I select View results
Then I am navigated to a page displaying providers
And the name of the provider is displayed
And all the relevant provider details are displayed
And the list is displayed by provider name in ascending order

@Workitem:37466 Driver
Scenario: Verify the View Provider Results Page Search and Filter Options
Given I have navigated to the View Provider Results Page
Then the list displays up to 50 providers per page
And an option to filter by search is displayed
And options are displayed to filter the results by specific fields

@Workitem:37466 Driver
Scenario: Verify the View Provider Results Page Pagination
Given I have navigated to the View Provider Results Page
And I have over 50 providers with results
When I click to navigate to the next page of 50 providers
Then my list view displays the next 50 results
And I am able to navigate to the previous page of 50 providers

@Workitem:37466 Driver
Scenario: Verify the View Provider Results Page Pagination Next and Previous options
Given I have navigated to the View Provider Results Page
And I have over 200 providers with results
When I click the Next option
Then my list view displays the next 200 results
When I click the Previous option
Then my list view displays the previous 200 results

@Workitem:37466 Driver
Scenario: Select a Provider from the View Provider Results Page
Given I have navigated to the View Provider Results Page
When I click a provider
Then I am redirected to the View provider allocations page for the selected provider

@Workitem:37468 Driver
Scenario: Verify the Search option on the View Provider Results Page
Given I have navigated to the View Provider Results Page
When I enter text in the Search Provider field
And click the Search Provider button
Then the list of displayed providers refreshes to display only the providers that comply with the search text entered

@Workitem:37468 Driver
Scenario Outline: Verify the Search option on the View Provider Results Page using specific information
Given I have navigated to the View Provider Results Page
When I enter text in the Search Provider field that matches or contains <text>
And click the Search Provider button
Then the list of displayed providers refreshes to display only the providers that comply with the search text entered

Examples: 
	 | SearchType					| text						|
	 | UPIN							| 506770					|
	 | UKPRN						| 506960					|
	 | URN							| 144331					|
	 | EstablishmentNumber			| 10062846					|
	 | ProviderName					| Aldington Primary School	|
	 | PartialUPIN					| 677						|
	 | PartialUKPRN					| 6960						|
	 | PartialURN					| 44						|
	 | PartialEstablishmentNumber	| 00628						|
	 | PartialProviderName			| Alexandra					|


@Workitem:37468 Driver
Scenario: Verify the Search option on the View Provider Results Page when additional filters are applied
Given I have navigated to the View Provider Results Page
And I have selected one or more filter options from the top navigation pane
When I enter text in the Search Provider field
And click the Search Provider button
Then the list of displayed providers refreshes to display only the providers that comply with the search text & filters selected

@Workitem:37467 Driver
Scenario: Select a Provider to display the Provider Allocation page
Given I have navigated to the View Provider Results Page
When I click on a listed provider
Then I am navigated to the View Provider Allocation page
And the relevant provider information is displayed
And a drop down option is displayed to select a year with the default year pre selected
And a drop down option is displayed to select a specification where the default is blank

@Workitem:37467 Driver
Scenario: Verify the Provider Allocations Page tab options
Given I have navigated to the View Provider Allocations Page
Then the default view is the tab displaying the allocation lines
And a selectable tab is available to display the calculation results
And no results are listed by default as no specification has been selected

@Workitem:37467 Driver
Scenario: Select Specification to display the associated allocation results
Given I have navigated to the View Provider Allocations Page
When I choose a specification from the drop down
And I am on the allocation view
Then the results are updated according to the year and spec selected
And I can see a list of Allocation names and the subtotals against the Allocation names

@Workitem:37467 Driver
Scenario: Select a new academic year and specification to display the associated allocation results
Given I have navigated to the View Provider Allocations Page
And I am on the Allocation view
When I choose a new year from the drop dwon option
And I choose a specification from the drop down
Then the results are updated according to the year and spec selected
And I can see a list of Allocation names and the subtotals against the Allocation names

@Workitem:37467 Driver
Scenario: Select the Calculations tab and a Specification to display the associated calculation results
Given I have navigated to the View Provider Allocations Page
When I choose to view the Calculation Tab
And I choose a specification from the drop down
Then the results are updated according to the year and spec selected
And I can see a list of Calculation names and the subtotals against the Calculation names

@Workitem:37467 Driver
Scenario: Verify the Provider Allocations Page Calculation tab
Given I have navigated to the View Provider Allocations Page
When I choose to view the Calculation Tab
Then a selectable tab is available to display the allocation results
And no results are listed by default as no specification has been selected

@Workitem:37467 Driver
Scenario: Select a new academic year and specification to display the associated calculation results
Given I have navigated to the View Provider Allocations Page
When I choose a new year from the drop dwon option
And I choose to view the Calculation Tab
And I choose a specification from the drop down
Then the results are updated according to the year and spec selected
And I can see a list of Calculation names and the subtotals against the Calculation names