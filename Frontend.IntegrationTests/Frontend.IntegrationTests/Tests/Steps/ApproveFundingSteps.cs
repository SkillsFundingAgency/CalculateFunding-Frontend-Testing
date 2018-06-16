﻿using Frontend.IntegrationTests.Pages.Approve_funding;
using Frontend.IntegrationTests.Pages.Home_Page;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.View_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Frontend.IntegrationTests.Helpers;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ApproveFundingSteps
    {
        ApprovalOptionsPage approvaloptionspage = new ApprovalOptionsPage();
        HomePage homepage = new HomePage();
        ChooseFundingSpecificationPage choosefundingspecificationpage = new ChooseFundingSpecificationPage();
        ApprovePublishFundingPage approvepublishfundingpage = new ApprovePublishFundingPage();
        ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
        EditSpecificationPage editspecificationpage = new EditSpecificationPage();



        [When(@"I click on the Choose Funidng Specification Option")]
        public void WhenIClickOnTheChooseFunidngSpecificationOption()
        {
            approvaloptionspage.ChooseFundingSpecification.Click();
            Thread.Sleep(2000);
        }
        
        [Then(@"I am redirected to the Choose Funding Specification Page")]
        public void ThenIAmRedirectedToTheChooseFundingSpecificationPage()
        {
            choosefundingspecificationpage.chooseFundingSpecFundingPeriodDropdown.Should().NotBeNull();
        }

        [Given(@"I have navigated to the Choose Funding Specification Page")]
        public void GivenIHaveNavigatedToTheChooseFundingSpecificationPage()
        {
            NavigateTo.ChooseFundingSpecPage();
        }

        [Then(@"an option to filter the results by Funding Period is displayed")]
        public void ThenAnOptionToFilterTheResultsByFundingPeriodIsDisplayed()
        {
            IWebElement fundingPeriod = choosefundingspecificationpage.chooseFundingSpecFundingPeriodDropdown;
            fundingPeriod.Should().NotBeNull();
        }

        [Then(@"the default Period is selected")]
        public void ThenTheDefaultPeriodIsSelected()
        {
            IWebElement fundingPeriodSelected = choosefundingspecificationpage.chooseFundingSpecDefaultFundingPeriod;
            string fundingPeriodDefault = fundingPeriodSelected.Text;
            Console.WriteLine("The Default Funding Period Displayed is: " + fundingPeriodDefault);
        }
        
        [Then(@"an option to select a Funding Stream is displayed")]
        public void ThenAnOptionToSelectAFundingStreamIsDisplayed()
        {
            IWebElement fundingStream = choosefundingspecificationpage.chooseFundingSpecFundingStreamDropdown;
            fundingStream.Should().NotBeNull();
        }

        [Then(@"a message is displayed instructing the User to select a Funding Stream")]
        public void ThenAMessageIsDisplayedInstructingTheUserToSelectAFundingStream()
        {
            IWebElement noResultsDisplayedMessage = choosefundingspecificationpage.chooseFundingSpecNoResultsPanel;
            noResultsDisplayedMessage.Should().NotBeNull();
            string noResultsText = noResultsDisplayedMessage.Text;
            Console.WriteLine("The No Results Displayed message is: " + noResultsText);
        }

        [Then(@"an empty list of approved or updated specifications is displayed with the appropriate headers")]
        public void ThenAnEmptyListOfApprovedOrUpdatedSpecificationsIsDisplayedWithTheAppropriateHeaders()
        {
            IWebElement policycontainer = choosefundingspecificationpage.chooseFundingSpecContainer;
            var propertyElements = policycontainer.FindElements(By.CssSelector(".cf > thead:nth-child(1) > tr:nth-child(1)"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }

            IWebElement noResultsDisplayedMessage = choosefundingspecificationpage.chooseFundingSpecNoResultsPanel;
            noResultsDisplayedMessage.Should().NotBeNull();
            string noResultsText = noResultsDisplayedMessage.Text;
            Console.WriteLine("The No Results Displayed message is: " + noResultsText);
        }

        [When(@"I choose a funding stream from the drop down option")]
        public void WhenIChooseAFundingStreamFromTheDropDownOption()
        {
            var selectFundingStream = choosefundingspecificationpage.chooseFundingSpecFundingStreamDropdown;
            var selectElement = new SelectElement(selectFundingStream);
            selectElement.SelectByValue("YPLRA"); ;
            Thread.Sleep(15000);
        }
        
        [Then(@"the list of approved or updated specifications is updated to display all the appropriate specifications")]
        public void ThenTheListOfApprovedOrUpdatedSpecificationsIsUpdatedToDisplayAllTheAppropriateSpecifications()
        {
            IWebElement firstSpecification = choosefundingspecificationpage.chooseFundingSpecFirstSpecName;
            firstSpecification.Should().NotBeNull();
        }

        [Then(@"The Name of the Approved or Updated specification is displayed")]
        public void ThenTheNameOfTheApprovedOrUpdatedSpecificationIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecName;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification Name is: " + firstVlaueText);
        }

        [Then(@"the Specificaton Funding Streams are displayed")]
        public void ThenTheSpecificatonFundingStreamsAreDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstFundingStream;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification Funding Stream is: " + firstVlaueText);

        }

        [Then(@"the Specification Funding Value is displayed")]
        public void ThenTheSpecificationFundingValueIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecFundingValue;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification Funding Value is: " + firstVlaueText);
        }

        [Then(@"the Specification Status is displayed")]
        public void ThenTheSpecificationStatusIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecStatus;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification Status is: " + firstVlaueText);
        }

        [Then(@"the Provider QA coverage is displayed")]
        public void ThenTheProviderQACoverageIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecQACoverage;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification QA Test Coverage is: " + firstVlaueText);
        }

        [Then(@"the QA tests passed is displayed")]
        public void ThenTheQATestsPassedIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecQATests;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Specification QA Tests Passed is: " + firstVlaueText);
        }

        [Then(@"the Calculations approved is displayed")]
        public void ThenTheCalculationsApprovedIsDisplayed()
        {
            IWebElement firstValue = choosefundingspecificationpage.chooseFundingSpecFirstSpecCalcs;
            string firstVlaueText = firstValue.Text;
            Console.WriteLine("Calculations Approved are: " + firstVlaueText);
        }

        [Then(@"an option to Choose to Fund the Specification is displayed")]
        public void ThenAnOptionToChooseToFundTheSpecificationIsDisplayed()
        {
            IWebElement chooseButton = choosefundingspecificationpage.chooseFundingSpecFirstActionButton;
            chooseButton.Should().NotBeNull();
            
        }

        [Given(@"I have previously Approved a Specification")]
        public void GivenIHavePreviouslyApprovedASpecification()
        {
            CreateNewSpecification.CreateANewSpecification();

            IWebElement approveButton = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            approveButton.Should().NotBeNull();

            managepoliciespage.approveDropDown.Click();
            IWebElement publishoptions = managepoliciespage.publishMenu;
            publishoptions.Should().NotBeNull();

            Driver._driver.FindElement(By.CssSelector(".dropdown-menu")).Click();
            Thread.Sleep(2000);

            IWebElement approved = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            string approveStatus = approved.Text;
            approveStatus.Should().Be("Approved", "The Status of the Specification is not Draft");
            Console.WriteLine("The New Status of the selected Specification is: " + approveStatus);

            homepage.Header.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the specification marked as approved is displayed correctly")]
        public void ThenTheSpecificationMarkedAsApprovedIsDisplayedCorrectly()
        {
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            var containerElements = choosefundingspecificationpage.chooseFundingSpecContainer;
            IWebElement SelectCreatedSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("span"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains(specCreated))
                        {

                            SelectCreatedSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectCreatedSpec != null)
                {
                    string approvedSpec = SelectCreatedSpec.Text;
                    Console.WriteLine("THe Following Approved Specification was correctly displayed: " + approvedSpec);
                    Thread.Sleep(2000);
                }
                else
                {
                    SelectCreatedSpec.Should().NotBeNull("Newly Created Specification is not displayed");
                }
            }
            else
            {
                SelectCreatedSpec.Should().NotBeNull("No Approved Specification could be successfully selected");
            }
        }

        [Given(@"I have previously Updated a Specification")]
        public void GivenIHavePreviouslyUpdatedASpecification()
        {
            CreateNewSpecification.CreateANewSpecification();

            IWebElement approveButton = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            approveButton.Should().NotBeNull();

            managepoliciespage.approveDropDown.Click();
            IWebElement publishoptions = managepoliciespage.publishMenu;
            publishoptions.Should().NotBeNull();

            Driver._driver.FindElement(By.CssSelector(".dropdown-menu")).Click();
            Thread.Sleep(2000);

            IWebElement approved = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            string approveStatus = approved.Text;
            approveStatus.Should().Be("Approved", "The Status of the Specification is not Approved");
            Console.WriteLine("The New Status of the selected Specification is: " + approveStatus);

            managepoliciespage.editSpecification.Click();
            Thread.Sleep(2000);

            string editspecificationname = "Test Specification Edited Name ";

            var randomEditSpecificationName = editspecificationname + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditSpecificationName"] = randomEditSpecificationName;

            editspecificationpage.editSpecificationName.Clear();
            editspecificationpage.editSpecificationName.SendKeys(randomEditSpecificationName);
            editspecificationpage.editSpecificationSaveButton.Click();
            Console.WriteLine("The Edited Specification Name is: " + randomEditSpecificationName);
            Thread.Sleep(2000);

            homepage.Header.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the specification marked as updated is displayed correctly")]
        public void ThenTheSpecificationMarkedAsUpdatedIsDisplayedCorrectly()
        {
            var specName = ScenarioContext.Current["EditSpecificationName"];
            string specUpdated = specName.ToString();

            var containerElements = choosefundingspecificationpage.chooseFundingSpecContainer;
            IWebElement SelectCreatedSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("span"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains(specUpdated))
                        {

                            SelectCreatedSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectCreatedSpec != null)
                {
                    string approvedSpec = SelectCreatedSpec.Text;
                    Console.WriteLine("THe Following Updated Specification was correctly displayed: " + approvedSpec);
                    Thread.Sleep(2000);
                }
                else
                {
                    SelectCreatedSpec.Should().NotBeNull("Newly Updated Specification is not displayed");
                }
            }
            else
            {
                SelectCreatedSpec.Should().NotBeNull("No Updated Specification could be successfully selected");
            }
        }

        [Given(@"I have previously Approved a Specification for a (.*)")]
        public void GivenIHavePreviouslyApprovedASpecificationForAAY(string year)
        {
            ScenarioContext.Current["SpecificationYear"] = year;
            CreateNewSpecification_VarYr.CreateANewSpecification_VarYr();

            IWebElement approveButton = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            approveButton.Should().NotBeNull();

            managepoliciespage.approveDropDown.Click();
            IWebElement publishoptions = managepoliciespage.publishMenu;
            publishoptions.Should().NotBeNull();

            Driver._driver.FindElement(By.CssSelector(".dropdown-menu")).Click();
            Thread.Sleep(2000);

            IWebElement approved = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            string approveStatus = approved.Text;
            approveStatus.Should().Be("Approved", "The Status of the Specification is not Draft");
            Console.WriteLine("The New Status of the selected Specification is: " + approveStatus);

            homepage.Header.Click();
            Thread.Sleep(2000);

        }

        [When(@"I change the Funding Period selected to equal (.*)")]
        public void WhenIChangeTheFundingPeriodSelectedToEqualAY(string year)
        {
            ScenarioContext.Current["SpecificationYear"] = year;

            var selectFundingPeriod = choosefundingspecificationpage.chooseFundingSpecFundingPeriodDropdown;
            var selectElement = new SelectElement(selectFundingPeriod);
            selectElement.SelectByValue(year); ;
            Thread.Sleep(5000);
        }

        [When(@"I click on the Approve and publish funding Option")]
        public void WhenIClickOnTheApproveAndPublishFundingOption()
        {
            approvaloptionspage.ApprovePublishFunding.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Approve and publish funding Page")]
        public void ThenIAmRedirectedToTheApproveAndPublishFundingPage()
        {
            approvepublishfundingpage.approvePublishFundingSpecDropdown.Should().NotBeNull();
        }

        [Given(@"I have navigated to the Approve and publish funding Page")]
        public void GivenIHaveNavigatedToTheApproveAndPublishFundingPage()
        {
            NavigateTo.ApprovePublishFundingage();
            Thread.Sleep(2000);
        }

        [Then(@"a dropdown option is displayed to select a Specification")]
        public void ThenADropdownOptionIsDisplayedToSelectASpecification()
        {
            approvepublishfundingpage.approvePublishFundingSpecDropdown.Should().NotBeNull();
        }

        [Then(@"an Approve Button is displayed and is Disabled")]
        public void ThenAnApproveButtonIsDisplayedAndIsDisabled()
        {
            IWebElement approveButton = approvepublishfundingpage.approvePublishFundingApprove;
            approveButton.Should().NotBeNull();
            approveButton.Enabled.Should().BeFalse();
        }

        [Then(@"a Publish Button is displayed and is Disabled")]
        public void ThenAPublishButtonIsDisplayedAndIsDisabled()
        {
            IWebElement publishButton = approvepublishfundingpage.approvePublishFundingPublish;
            publishButton.Should().NotBeNull();
            publishButton.Enabled.Should().BeFalse();
        }

        [Then(@"a Select All Providers Tick Box is Displayed")]
        public void ThenASelectAllProvidersTickBoxIsDisplayed()
        {
            approvepublishfundingpage.approvePublishFundingSelectAll.Should().NotBeNull();
        }

        [Then(@"a message is displayed to state that a Specification needs to be selected")]
        public void ThenAMessageIsDisplayedToStateThatASpecificationNeedsToBeSelected()
        {
            IWebElement noResults = approvepublishfundingpage.approvePublishFundingNoResultsPanel;
            noResults.Should().NotBeNull();
            string noResultsMessage = noResults.Text;
            Console.WriteLine("The following No Results message was correctly displayed: " + noResultsMessage);
        }

        [Then(@"an empty list of Provider Infomation for a Specification is displayed with the appropriate headers")]
        public void ThenAnEmptyListOfProviderInfomationForASpecificationIsDisplayedWithTheAppropriateHeaders()
        {
            IWebElement headers = approvepublishfundingpage.approvePublishFundingProviderHeaders;
            string headerText = headers.Text;
            Console.WriteLine("The Headers displayed for the table are: " + headerText);
        }

        [When(@"I choose a Choosen Specification from the dropdown")]
        public void WhenIChooseAChoosenSpecificationFromTheDropdown()
        {
            var containerElements = approvepublishfundingpage.approvePublishFundingSpecDropdown;
            IWebElement SelectFirstSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("High Needs"))
                        {

                            SelectFirstSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstSpec != null)
                {
                    string specSelected = SelectFirstSpec.Text;
                    Console.WriteLine("Specification Selected: " + specSelected);
                    SelectFirstSpec.Click();
                    Thread.Sleep(5000);
                }
                else
                {
                    SelectFirstSpec.Should().NotBeNull("No Specification could be successfully selected");
                }
            }
            else
            {
                SelectFirstSpec.Should().NotBeNull("No Specification was available to select");
            }
        }

        [Then(@"the Provider list updates to display all the provider information for the selected specification")]
        public void ThenTheProviderListUpdatesToDisplayAllTheProviderInformationForTheSelectedSpecification()
        {
            approvepublishfundingpage.approvePublishFundingFirstProviderRow.Should().NotBeNull();
        }

        [Then(@"the Name of the provider for the specification is displayed")]
        public void ThenTheNameOfTheProviderForTheSpecificationIsDisplayed()
        {
            IWebElement name = approvepublishfundingpage.approvePublishFundingFirstProviderName;
            name.Should().NotBeNull();
            string providername = name.Text;
            Console.WriteLine("First Provider Name Displayed is: " + providername);
        }

        [Then(@"the UKPRN of the provider for the specification is displayed")]
        public void ThenTheUKPRNOfTheProviderForTheSpecificationIsDisplayed()
        {
            IWebElement number = approvepublishfundingpage.approvePublishFundingFirstProviderUKPRN;
            number.Should().NotBeNull();
            string providernumber = number.Text;
            Console.WriteLine("First UKPRN Displayed is: " + providernumber);
        }

        [Then(@"the Allocation Line Status \(Held\) for the specification is displayed")]
        public void ThenTheAllocationLineStatusHeldForTheSpecificationIsDisplayed()
        {
            IWebElement held = approvepublishfundingpage.approvePublishFundingFirstProviderAllocStatusHeld;
            held.Should().NotBeNull();
            string allocationheld = held.Text;
            Console.WriteLine("First Allocation Line Status Held Result Displayed is: " + allocationheld);
        }

        [Then(@"the Allocation Line Status \(Approved\) for the specification is displayed")]
        public void ThenTheAllocationLineStatusApprovedForTheSpecificationIsDisplayed()
        {
            IWebElement approved = approvepublishfundingpage.approvePublishFundingFirstProviderAllocStatusApproved;
            approved.Should().NotBeNull();
            string allocationapproved = approved.Text;
            Console.WriteLine("First Allocation Line Status Approved Result Displayed is: " + allocationapproved);
        }

        [Then(@"the Allocation Line Status \(Published\) for the specification is displayed")]
        public void ThenTheAllocationLineStatusPublishedForTheSpecificationIsDisplayed()
        {
            IWebElement published = approvepublishfundingpage.approvePublishFundingFirstProviderAllocStatusPublished;
            published.Should().NotBeNull();
            string allocationpublished = published.Text;
            Console.WriteLine("First Allocation Line Status Published Result Displayed is: " + allocationpublished);
        }

        [Then(@"the Allocation Line Status Last Updated date for the specification is displayed")]
        public void ThenTheAllocationLineStatusLastUpdatedDateForTheSpecificationIsDisplayed()
        {
            IWebElement lastUpdated = approvepublishfundingpage.approvePublishFundingFirstProviderAllocStatusLastUpdated;
            lastUpdated.Should().NotBeNull();
            string lastUpdateddate = lastUpdated.Text;
            Console.WriteLine("Last updated Date for the First Specification Displayed is: " + lastUpdateddate);
        }

        [Then(@"the Specification Funding Amount for the specification is displayed")]
        public void ThenTheSpecificationFundingAmountForTheSpecificationIsDisplayed()
        {
            IWebElement fundingAmt = approvepublishfundingpage.approvePublishFundingFirstProviderSpecFundingAmt;
            fundingAmt.Should().NotBeNull();
            string specFundingAmt = fundingAmt.Text;
            Console.WriteLine("First Specification Funding Amount Displayed is: " + specFundingAmt);
        }

        [Then(@"an option to expand the Provider Information is displayed")]
        public void ThenAnOptionToExpandTheProviderInformationIsDisplayed()
        {
            approvepublishfundingpage.approvePublishFundingFirstProviderExpansionOption.Should().NotBeNull();
        }

        [When(@"I choose to expand the Provider information")]
        public void WhenIChooseToExpandTheProviderInformation()
        {
            approvepublishfundingpage.approvePublishFundingFirstProviderExpansionOption.Click();
            Thread.Sleep(10000);
        }

        [Then(@"the QA Test Coverage information is displayed")]
        public void ThenTheQATestCoverageInformationIsDisplayed()
        {
            IWebElement qaTestInfo = approvepublishfundingpage.approvePublishFundingFirstProviderQATestInfo;
            qaTestInfo.Should().NotBeNull();
            string qaTestResults = qaTestInfo.Text;
            Console.WriteLine("The First Provder QA Test Coverage results are: " + qaTestResults);
        }

        [Given(@"I choose a Choosen Specification from the dropdown")]
        public void GivenIChooseAChoosenSpecificationFromTheDropdown()
        {
            var containerElements = approvepublishfundingpage.approvePublishFundingSpecDropdown;
            IWebElement SelectFirstSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("High Needs"))
                        {

                            SelectFirstSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstSpec != null)
                {
                    string specSelected = SelectFirstSpec.Text;
                    Console.WriteLine("Specification Selected: " + specSelected);
                    SelectFirstSpec.Click();
                    Thread.Sleep(5000);
                }
                else
                {
                    SelectFirstSpec.Should().NotBeNull("No Specification could be successfully selected");
                }
            }
            else
            {
                SelectFirstSpec.Should().NotBeNull("No Specification was available to select");
            }
        }

        [Given(@"the Provider list updates to display all the provider information for the selected specification")]
        public void GivenTheProviderListUpdatesToDisplayAllTheProviderInformationForTheSelectedSpecification()
        {
            approvepublishfundingpage.approvePublishFundingFirstProviderRow.Should().NotBeNull();
        }

        [When(@"I check the Select All tick box option")]
        public void WhenICheckTheSelectAllTickBoxOption()
        {
            approvepublishfundingpage.approvePublishFundingSelectAll.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Approve Button becomes enabled")]
        public void ThenTheApproveButtonBecomesEnabled()
        {
            IWebElement approveButton = approvepublishfundingpage.approvePublishFundingApprove;
            approveButton.Should().NotBeNull();
            approveButton.Enabled.Should().BeTrue();
        }

        [Then(@"the Publish Button becomes Enabled")]
        public void ThenThePublishButtonBecomesEnabled()
        {
            IWebElement publishButton = approvepublishfundingpage.approvePublishFundingPublish;
            publishButton.Should().NotBeNull();
            publishButton.Enabled.Should().BeTrue();
        }



        [AfterScenario()]
        public void FixtureTearDown()
        {
            if (Driver._driver != null)
            {
                Driver._driver.Quit();
                Driver._driver.Dispose();
            }

        }

    }
}
