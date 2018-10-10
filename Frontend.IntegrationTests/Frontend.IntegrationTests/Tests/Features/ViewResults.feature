Feature: ViewResults
As a funding calculation analyst
I need to see a list of providers and the funding that has been calculated for them
So that I can review if the funding that has been calculated is as expected and I need to view 
the funding a provider has been calculated across all of ESFA's allocation lines
So that I can ensure the funding calculated for that provider is correct before publishing the allocation to the provider

@Workitem:37466 Driver Smoke
Scenario: Verify the View Provider Results Page Results list
Given I have successfully navigated to the Home Page
When I select View results
And I click on the View provider results option
Then I am navigated to a page displaying providers
And the name of the provider is displayed
And all the relevant provider details are displayed
And the list is displayed by provider name in ascending order

@Workitem:37466 Driver Smoke
Scenario: Verify the View Provider Results Page Search and Filter Options
Given I have navigated to the View Provider Results Page
Then the list displays up to 50 providers per page
And an option to filter by search is displayed
And options are displayed to filter the results by specific fields

@Workitem:37466 Driver Smoke
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

@Workitem:37466 Driver Smoke
Scenario: Select a Provider from the View Provider Results Page
Given I have navigated to the View Provider Results Page
When I click a provider
Then I am redirected to the View provider allocations page for the selected provider

@Workitem:37468 Driver Smoke
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
	 | EstablishmentNumber			| 10020219					|
	 | ProviderName					| Aldington					|
	 | PartialUPIN					| 138						|
	 | PartialUKPRN					| 1004						|
	 | PartialURN					| 125						|
	 | PartialEstablishmentNumber	| 9366						|
	 | PartialProviderName			| Alexandra					|


@Workitem:37468 Driver
Scenario: Verify the Search option on the View Provider Results Page when additional filters are applied
Given I have navigated to the View Provider Results Page
And I have selected one or more filter options from the top navigation pane
When I enter text in the Search Provider field
And click the Search Provider button
Then the list of displayed providers refreshes to display only the providers that comply with the search text & filters selected

@Workitem:37467 Driver Smoke
Scenario: Select a Provider to display the Provider Allocation page
Given I have navigated to the View Provider Results Page
When I click on a listed provider
Then I am navigated to the View Provider Allocation page
And the relevant provider information is displayed
And a drop down option is displayed to select a year with the default year pre selected
And a drop down option is displayed to select a specification where the default is blank

@Workitem:37467 Driver Smoke
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

@Workitem:37467 Driver Smoke
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

@Workitem:39519 Driver Smoke
Scenario: Verify the View Results landing page
Given I have successfully navigated to the Home Page
When I select View results
Then I am presented the View Results landing page
And An option is displayed view the View provider results page
And An option is displayed view the View QA test results page
And An option is displayed view the View calculation results page

@Workitem:39520 40039 Driver Smoke
Scenario: Navigate to the View QA test results Page
Given I have successfully navigated to the Home Page
When I select View results
Then I am presented the View Results landing page
When I click on the View QA test results option
Then I am naviagted to the View QA test results page

@Workitem:39520 40039 Driver Smoke
Scenario: Verify the View QA test results Page
Given I have navigated to the view all test results screen
Then the Search QA Test option is displayed
And the Select Period drop down option is displayed
And the Select Specification drop down option is displayed
And a list of QA Test Results listed by Test is displayed with the correct column headers

@Workitem:39520 40039 Driver Smoke
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
	 | year			|
	 | AY2018191	|
	 | FY2017181	|
	 | FY2018191	|
	 | AY2017181	|
	 

@Workitem:39520 Driver Smoke
Scenario: Change Current list of QA Tests by Specification
Given I have navigated to the view all test results screen
When I choose a specification from the QA Test drop down Option
Then the list of QA Test Results refreshes to display the selected specifications QA Tests

@Workitem:39522 Driver Smoke
Scenario: Navigate to View the test results of all providers for a single test
Given I have navigated to the view all test results screen
When I choose a QA Test from the displayed list of tests
Then I am redirected to the selected QA Test results for all providers page

@Workitem:39522 Driver Smoke
Scenario: Verify the View test results of all providers for a single test
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then A Search Filter option is correctly displayed
And A Provider Type Filter drop Down is correctly displayed
And A Provider Sub Type Filter drop down is correctly displayed
And A Local Authority Filter drop down is correctly displayed

@Workitem:39522 Driver
Scenario: Verify the View test results of all providers for a single test Pagination
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then the page lists up to the first 50 Providers
When there are more than 50 Providers returned
And I click to navigate to the next page of 50 providers test results
Then my page list view displays the next 50 test results
And I am able to navigate to the previous page of 50 providers test results

@Workitem:39522 Driver
Scenario: Validate Provider Info on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then The name of the provider for the single test is displayed
And all the relevant provider details for the single are displayed

@Workitem:39522 Driver
Scenario: Validate Provider Test Result on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then The name of the provider for the single test is displayed
And the QA Test Result for the provider is displayed

@Workitem:39522 Driver Smoke
Scenario: Validate Selected QA Test Info on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then details of the Test selected are displayed on the page correctly

@Workitem:39522 Driver
Scenario: Validate Search Results on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
And I decide to filter my results by using the search filter
Then the Provider Results list is refreshed to display only the providers that comply with the filter selected

@Workitem:39522 Driver
Scenario: Validate Provider Type Filtered Results on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
And I decide to filter my results by using the Provider Type Filter
Then the Provider Results list is refreshed to display only the providers that comply with the filter selected

@Workitem:39522 Driver
Scenario: Validate Provider Sub Type Filtered Results on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
And I decide to filter my results by using the Provider Sub Type Filter
Then the Provider Results list is refreshed to display only the providers that comply with the filter selected

@Workitem:39522 Driver
Scenario: Validate Local Authority Filtered Results on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
And I decide to filter my results by using the Local Authority Filter
Then the Provider Results list is refreshed to display only the providers that comply with the filter selected

@Workitem:39523 Driver Smoke
Scenario: Navigate to the View provider results for an Individual Provider Page
Given I have navigated to the Provider results for an Individual Provider Page
Then a tab is displayed to show the Allocation Line results
And a tab is displayed to show the Calculation results
And a tab is displayed to show the Test results

@Workitem:39523 Driver Smoke
Scenario: Verify the View provider results for an Individual Provider Page
Given I have navigated to the Provider results for an Individual Provider Page
Then the drop down option to select an academic year is displayed
And the drop down option to select a specification is displayed
And the relevant provider information is displayed

@Workitem:39523 39517 Driver
Scenario: Check Passed Result on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then the Provider List of Test results for the selected QA Test is displayed
And a Provider where the QA Test has Passed can be selected to display the specific QA Test Result
And the QA Test Coverage for the Provider is displayed correctly
And the QA Test Results for the Provider are displayed correctly

@Workitem:39523 39517 Driver
Scenario: Check Failed Result on the View test results of all providers for a single test page
Given I have navigated to the view all test results screen
And I choose a QA Test from the displayed list of tests
When I am redirected to the selected QA Test results for all providers page
Then the Provider List of Test results for the selected QA Test is displayed
And a Provider where the QA Test has Failed can be selected to display the specific QA Test Result
And the QA Test Coverage for the Provider is displayed correctly
And the QA Test Results for the Provider are displayed correctly

@Workitem:39523 39517 Driver
Scenario Outline: Validate the Provider Test results for an Individual Provider with a result of Passed for each Academic Year
Given I have created a New Specification for <year>
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification for <year>
And I edit the New Calculation for that Specification
And I have created a New Test for the Specification
And I then select the appropriate Test from the View provider results list page
Then I can select the Provider with a Passed Test Result from the View provider results for an Individual Provider Page
And I can click on the Test Tab to view the Test result for the Individual Provider and Specification
And the QA Test Coverage for the Provider is displayed correctly
And the QA Test Results for the Provider are displayed correctly

Examples: 
	 | year			|
	 | AY2017181	|
	 | AY2018191	|
	 | FY2017181	|
	 | FY2018191	|

@Workitem:39523 39517 Driver
Scenario Outline: Validate the Provider Test results for an Individual Provider with a result of Failed for each Academic Year
Given I have created a New Specification for <year>
And I have created a New Policy for that Specification
And I have created a New Calculation Specification for that Specification
And I have create a New Dataset for that Specificaton
When I have specified a data Source Relationship for the Specification for <year>
And I edit the New Calculation for that Specification
And I have created a New Test for the Specification
And I then select the appropriate Test from the View provider results list page
Then I can select the Provider with a Failed Test Result from the View provider results for an Individual Provider Page
And I can click on the Test Tab to view the Test result for the Individual Provider and Specification
And the QA Test Coverage for the Provider is displayed correctly
And the QA Test Results for the Provider are displayed correctly

Examples: 
	 | year			|
	 | AY2017181	|
	 | AY2018191	|
	 | FY2017181	|
	 | FY2018191	|


@Workitem:48412 Driver Smoke
Scenario: Navigate to View calculation results Page
Given I have successfully navigated to the Home Page
When I select View results
And I click on the View calculation results option
Then I am redirected to the View calculation results Page

@Workitem:48412 Driver Smoke
Scenario: Verify the View calculation results Page Filter options
Given I have successfully navigated to the View Calculation Page
Then the Search option filter is displayed correctly
And the Allocation Line Dropdown option is displayed correctly
And the Funding Period Dropdown option is displayed correctly
And the Funding Stream Dropdown option is displayed correctly
And the Specificaiton Name Dropdown option is displayed correctly
And the Calculation Status Dropdown option is displayed correctly

@Workitem:48412 Driver
Scenario: Verify the View calculation results Pagination options
Given I have successfully navigated to the View Calculation Page
And I have over 50 calculations
When I click to navigate to the next page of 50 calculations
Then my list view displays the next 50 calculations
And I am able to navigate to the previous page of 50 calculations

@Workitem:48412 Driver
Scenario: Validate the Displayed Results for each Calculation on the View calculation results Page
Given I have successfully navigated to the View Calculation Page
Then a list of calculations is displayed with the correct column headers
And the appropriate calculation information is displayed in the list

@Workitem:48412 Driver
Scenario: Filter the Displayed Calculation Results by Funding Period
Given I have successfully navigated to the View Calculation Page
When I choose to filter the results by Funding Period
Then the calculation results are updated accordingly
And the appropriate calculation information is displayed in the list

@Workitem:48412 Driver Smoke
Scenario: Filter the Displayed Calculation Results by Funding Stream
Given I have successfully navigated to the View Calculation Page
When I choose to filter the results by Funding Stream
Then the calculation results are updated accordingly
And the appropriate calculation information is displayed in the list

@Workitem:48412 Driver
Scenario: Filter the Displayed Calculation Results by Spec Name
Given I have successfully navigated to the View Calculation Page
When I choose to filter the results by Spec Name
Then the calculation results are updated accordingly
And the appropriate calculation information is displayed in the list

@Workitem:48412 Driver
Scenario: Filter the Displayed Calculation Results by Calculation Status
Given I have successfully navigated to the View Calculation Page
When I choose to filter the results by Calculation Status
Then the calculation results are updated accordingly
And the appropriate calculation information is displayed in the list

@Workitem:48412 Driver
Scenario: Filter the Displayed Calculation Results by Allocation Line
Given I have successfully navigated to the View Calculation Page
When I choose to filter the results by Allocation Line
Then the calculation results are updated accordingly
And the appropriate calculation information is displayed in the list