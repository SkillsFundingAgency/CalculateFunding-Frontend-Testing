using Frontend.IntegrationTests.Pages.Approve_funding;
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
        ConfirmChoosenSpecificationPage confirmchoosenspecificationpage = new ConfirmChoosenSpecificationPage();



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
            selectElement.SelectByValue("YPLRA");
            Thread.Sleep(20000);
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
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
            CreateDataSourceMapping.CreateADataSourceMapping();

            homepage.Header.Click();
            Thread.Sleep(2000);
            homepage.ManagetheSpecification.Click();
            Thread.Sleep(2000);
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            Driver._driver.FindElement(By.LinkText(specCreated)).Click();

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
                    Console.WriteLine("The Following Approved Specification was correctly displayed: " + approvedSpec);
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
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
            CreateDataSourceMapping.CreateADataSourceMapping();

            homepage.Header.Click();
            Thread.Sleep(2000);
            homepage.ManagetheSpecification.Click();
            Thread.Sleep(2000);
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            Driver._driver.FindElement(By.LinkText(specCreated)).Click();

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
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
            CreateDataSourceMapping_VarYr.CreateADataSourceMapping_VarYr();

            homepage.Header.Click();
            Thread.Sleep(2000);
            homepage.ManagetheSpecification.Click();
            Thread.Sleep(2000);
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            Driver._driver.FindElement(By.LinkText(specCreated)).Click();

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
                        if (optionelement.Text.Contains("Test Spec Name"))
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
                        if (optionelement.Text.Contains("Test Spec Name"))
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

        [Then(@"the Funding Stream information is correctly displayed")]
        public void ThenTheFundingStreamInformationIsCorrectlyDisplayed()
        {
            approvepublishfundingpage.approvePublishFundingFirstProviderFundingStreamInfoLineOne.Should().NotBeNull();
            approvepublishfundingpage.approvePublishFundingFirstProviderFundingStreamInfoLineTwo.Should().NotBeNull();

            IWebElement FundingStreamInfoLineOne = approvepublishfundingpage.approvePublishFundingFirstProviderFundingStreamInfoLineOne;
            string FundingStreamInfoLineOneText = FundingStreamInfoLineOne.Text;
            Console.WriteLine(FundingStreamInfoLineOneText);

            IWebElement FundingStreamInfoLineTwo = approvepublishfundingpage.approvePublishFundingFirstProviderFundingStreamInfoLineTwo;
            string FundingStreamInfoLineTwoText = FundingStreamInfoLineTwo.Text;
            Console.WriteLine(FundingStreamInfoLineTwoText);

        }

        [When(@"I Choose a Provider Allocation Line with a status of Held")]
        public void WhenIChooseAProviderAllocationLineWithAStatusOfHeld()
        {
            Actions.ApproveFundingChooseProviderAllocationLineToApprove();
        }

        [When(@"I click on the Approve Button")]
        public void WhenIClickOnTheApproveButton()
        {
            approvepublishfundingpage.approvePublishFundingApprove.Click();
            Thread.Sleep(6000);
        }

        [Then(@"the Provider Allocation Line is successfully approved")]
        public void ThenTheProviderAllocationLineIsSuccessfullyApproved()
        {
            IWebElement approveNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            approveNotification.Should().NotBeNull();
            string approveSuccessfullyText = approveNotification.Text;

            Console.WriteLine(approveSuccessfullyText);
        }

        [When(@"I Choose a Provider Funding Stream with a status of Held")]
        public void WhenIChooseAProviderFundingStreamWithAStatusOfHeld()
        {
            Actions.ApproveFundingChooseProviderFundingStreamToApprove();
        }

        [Then(@"the Provider Funding Stream is successfully approved")]
        public void ThenTheProviderFundingStreamIsSuccessfullyApproved()
        {
            IWebElement approveNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            approveNotification.Should().NotBeNull();
            string approveSuccessfullyText = approveNotification.Text;

            Console.WriteLine(approveSuccessfullyText);
        }

        [When(@"I Choose a Provider with a status of Held")]
        public void WhenIChooseAProviderWithAStatusOfHeld()
        {
            Actions.ApproveFundingChooseProviderToApprove();
        }

        [Then(@"the Provider is successfully approved")]
        public void ThenTheProviderIsSuccessfullyApproved()
        {
            IWebElement approveNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            approveNotification.Should().NotBeNull();
            string approveSuccessfullyText = approveNotification.Text;

            Console.WriteLine(approveSuccessfullyText);
        }

        [When(@"I Choose a Provider Allocation Line with a status of Approved")]
        public void WhenIChooseAProviderAllocationLineWithAStatusOfApproved()
        {
            Actions.ApproveFundingChooseProviderAllocationLineToPublished();
        }

        [Then(@"the Publish Button becomes enabled")]
        public void ThenThePublishButtonBecomesEnabled()
        {
            IWebElement publishButton = approvepublishfundingpage.approvePublishFundingPublish;
            publishButton.Should().NotBeNull();
            publishButton.Enabled.Should().BeTrue();
        }

        [When(@"I click on the Publish Button")]
        public void WhenIClickOnThePublishButton()
        {
            approvepublishfundingpage.approvePublishFundingPublish.Click();
            Thread.Sleep(6000);
        }



        [Then(@"the Provider Allocation Line is successfully published")]
        public void ThenTheProviderAllocationLineIsSuccessfullyPublished()
        {
            IWebElement publishNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            publishNotification.Should().NotBeNull();
            string publishSuccessfullyText = publishNotification.Text;

            Console.WriteLine(publishSuccessfullyText);
        }

        [When(@"I Choose a Provider Funding Stream with a status of Approved")]
        public void WhenIChooseAProviderFundingStreamWithAStatusOfApproved()
        {
            Actions.ApproveFundingChooseProviderFundingStreamToPublish();
        }

        [Then(@"the Provider Funding Stream is successfully published")]
        public void ThenTheProviderFundingStreamIsSuccessfullyPublished()
        {
            IWebElement publishNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            publishNotification.Should().NotBeNull();
            string publishSuccessfullyText = publishNotification.Text;

            Console.WriteLine(publishSuccessfullyText);
        }

        [When(@"I Choose a Provider with a status of Approved")]
        public void WhenIChooseAProviderWithAStatusOfApproved()
        {
            Actions.ApproveFundingChooseProviderToPublish();
        }

        [Then(@"the Provider is successfully published")]
        public void ThenTheProviderIsSuccessfullyPublished()
        {
            IWebElement publishNotification = approvepublishfundingpage.approvePublishFundingNotificationPanel;
            publishNotification.Should().NotBeNull();
            string publishSuccessfullyText = publishNotification.Text;

            Console.WriteLine(publishSuccessfullyText);
        }

        [When(@"I choose a Funding Stream added to the Approved Specification")]
        public void WhenIChooseAFundingStreamAddedToTheApprovedSpecification()
        {
            var selectFundingStream = choosefundingspecificationpage.chooseFundingSpecFundingStreamDropdown;
            var selectElement = new SelectElement(selectFundingStream);
            selectElement.SelectByValue("YPLRP");

            Thread.Sleep(10000);
        }

        [When(@"I click on the Choose Option Button")]
        public void WhenIClickOnTheChooseOptionButton()
        {
            //choosefundingspecificationpage.chooseFundingSpecFirstActionButton.Click();
            //Thread.Sleep(4000);

            var containerElements = choosefundingspecificationpage.chooseFundingSpecTableBody;
            IWebElement SelectFirstChooseBtn = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("td a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        {
                            if (optionelement.Text.Contains("Choose"))
                            {

                                SelectFirstChooseBtn = optionelement;

                                break;
                            }

                        }


                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstChooseBtn != null)
                {
                    SelectFirstChooseBtn.Enabled.Should().BeTrue();
                    SelectFirstChooseBtn.Click();
                    Thread.Sleep(5000);
                }
                else
                {
                    Assert.Inconclusive("No Option to Choose a Specification could be successfully selected");
                }
            }
            else
            {
                SelectFirstChooseBtn.Should().NotBeNull("No Option to Choose a Specification was available to select");
            }

        }

        [Then(@"I am redirected to the Confirmation to chose a specification for a funding stream and period page")]
        public void ThenIAmRedirectedToTheConfirmationToChoseASpecificationForAFundingStreamAndPeriodPage()
        {
            confirmchoosenspecificationpage.confirmChoosenSpecConfirmButton.Should().NotBeNull();
        }

        [Then(@"I am presented with the name of the specification I have selected")]
        public void ThenIAmPresentedWithTheNameOfTheSpecificationIHaveSelected()
        {
            IWebElement specName = confirmchoosenspecificationpage.confirmChoosenSpecHeading;
            specName.Should().NotBeNull();
            string specNameText = specName.Text;
            Console.WriteLine("The specification name displayed is: " + specNameText);
        }

        [Then(@"I am presented with the funding period and the funding streams for the selected specification")]
        public void ThenIAmPresentedWithTheFundingPeriodAndTheFundingStreamsForTheSelectedSpecification()
        {
            IWebElement specFundingStreams = confirmchoosenspecificationpage.confirmChoosenSpecFundingStreams;
            specFundingStreams.Should().NotBeNull();
            string fundingStreamText = specFundingStreams.Text;
            Console.WriteLine("The Funding Stream information displayed is: " + fundingStreamText);
        }

        [Then(@"I am presented with a message explaining the consequences if were to choose the selected specification")]
        public void ThenIAmPresentedWithAMessageExplainingTheConsequencesIfWereToChooseTheSelectedSpecification()
        {
            IWebElement specWarning = confirmchoosenspecificationpage.confirmChoosenSpecWarningMessage;
            specWarning.Should().NotBeNull();
            string specWarningText = specWarning.Text;
            Console.WriteLine("The following Warning Message is displayed : " + specWarningText);
        }

        [Then(@"I am presented with an option choose the selected specification")]
        public void ThenIAmPresentedWithAnOptionChooseTheSelectedSpecification()
        {
            confirmchoosenspecificationpage.confirmChoosenSpecConfirmButton.Should().NotBeNull();
        }

        [Then(@"I am presented with an option to cancel choosing the selected specification")]
        public void ThenIAmPresentedWithAnOptionToCancelChoosingTheSelectedSpecification()
        {
            confirmchoosenspecificationpage.confirmChoosenSpecBackButton.Should().NotBeNull();
        }

        [When(@"I click on the Back do not choose option")]
        public void WhenIClickOnTheBackDoNotChooseOption()
        {
            confirmchoosenspecificationpage.confirmChoosenSpecBackButton.Click();
            Thread.Sleep(2000);
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
