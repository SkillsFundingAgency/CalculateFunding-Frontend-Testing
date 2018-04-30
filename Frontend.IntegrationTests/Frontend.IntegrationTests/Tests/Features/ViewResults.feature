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
And I click on the View provider results option
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
When I choose a new year from the drop down option
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
When I choose a new year from the drop down option
And I choose to view the Calculation Tab
And I choose a specification from the drop down
Then the results are updated according to the year and spec selected
And I can see a list of Calculation names and the subtotals against the Calculation names

@Workitem:40480 Driver
Scenario: Verify the Content for missing provider references returns No data found
Given I have successfully navigated to the Home Page
When I select View results
And I click on the View provider results option
Then I am navigated to a page displaying providers
And the name of the provider is displayed
And where a provider record has a 0 value the content No data found is displayed

@Workitem:39519 Driver
Scenario: Verify the View Results landing page
Given I have successfully navigated to the Home Page
When I select View results
Then I am presented the View Results landing page
And An option is displayed view the View provider results page
And An option is displayed view the View QA test results page
And An option is displayed view the View calculation results page

@Workitem:39520 Driver
Scenario: Navigate to the View QA test results Page
Given I have successfully navigated to the Home Page
When I select View results
Then I am presented the View Results landing page
When I click on the View QA test results option
Then I am naviagted to the View QA test results page

@Workitem:39520 Driver
Scenario: Verify the View QA test results Page
Given I have navigated to the view all test results screen
Then the Search QA Test option is displayed
And the Select Period drop down option is displayed
And the Select Specification drop down option is displayed
And a list of QA Test Results listed by Test is displayed with the correct column headers

@Workitem:39520 Driver
Scenario: Verify the QA test results displayed on the View QA Test Results Page
Given I have navigated to the view all test results screen
Then I am presented with a list of QA Test results
And the appropriate information is displayed for each QA Test

@Workitem:39520 Driver
Scenario: Verify the View QA test results Page Pagination
Given I have navigated to the view all test results screen
And I have over 50 QA Tests displayed
When I click to navigate to the next page of 50 QA Test Results
Then my list view updates to display the next set of 50 Results
And I am able to navigate to the previous page of 50 Results

@Workitem:39520 Driver
Scenario: Search Option to filter the View QA test results Page
Given I have navigated to the view all test results screen
When I choose to search for an existing QA Test
Then The list of QA Test Results is updated to display the correct QA Test

@Workitem:39520 Driver
Scenario Outline: Change Current list of QA Tests by Year
Given I have navigated to the view all test results screen
When I change the selected QA Test period drop down to <year>
Then the list of QA Test Results refreshes to display the selected years QA Tests

Examples: 
	 | year |
	 | 1819	|
	 | 1718	|
	 | 1617	|
	 
@Workitem:39520 Driver
Scenario Outline: Change Current list of QA Tests by Specification
Given I have navigated to the view all test results screen
When I change the selected QA Test specificaiton drop down to <specification>
Then the list of QA Test Results refreshes to display the selected specifications QA Tests

Examples: 
	 | specification                                   | 
	 | YP 201718 16-19 Learner Responsive              | 
	 | YP 201718 Academies 16-18                       | 
	 | YP 201718 Non Formula Funded Activity Academies | 
	 | YP 201718 School Sixth Form                     | 
	 | Adam Spec 001								   |
