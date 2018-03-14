﻿Feature: ViewResults
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