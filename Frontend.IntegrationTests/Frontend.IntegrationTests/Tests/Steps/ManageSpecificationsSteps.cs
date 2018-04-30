using System;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Frontend.IntegrationTests.Create;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using System.Collections.Generic;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ManageSpecificationsSteps
    {
        ManageSpecificationPage managespecficationpage = new ManageSpecificationPage();
        CreateCalculationPage createcalculationpage = new CreateCalculationPage();
        CreatePolicyPage createpolicypage = new CreatePolicyPage();
        CreateSpecificationPage createspecificationpage = new CreateSpecificationPage();
        CreateSubPolicyPage createsubpolicypage = new CreateSubPolicyPage();
        ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
        public string newname = "Test Name ";
        public string descriptiontext = "This is a Description";


        [Then(@"The Default Specification Year is displayed correctly")]
        public void ThenTheDefaultSpecificationYearIsDisplayedCorrectly()
        {
            Assert.IsNotNull(managespecficationpage.SelectYear);
            Assert.IsNotNull(managespecficationpage.DefaultYear);
            Thread.Sleep(2000);
        }

        [Then(@"A list of Specifications is displayed for the default year")]
        public void ThenAListOfSpecificationsIsDisplayedForTheDefaultYear()
        {
            Assert.IsNotNull(managespecficationpage.SpecificationList);
            Thread.Sleep(2000);

        }

        [Given(@"I have successfully navigated to the Manage Specification Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheManageSpecificationPage()
        {
            NavigateTo.ManagetheSpecfication();
            Thread.Sleep(2000);
        }

        [When(@"I change the Select A Year drop down to a different year")]
        public void WhenIChangeTheSelectAYearDropDownToADifferentYear()
        {
            var selectYear = managespecficationpage.SelectYear;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1718");
            Thread.Sleep(2000);
        }

        [Then(@"the list of specifications refreshes to display the selected years specifications")]
        public void ThenTheListOfSpecificationsRefreshesToDisplayTheSelectedYearsSpecifications()
        {
            Assert.IsNotNull(managespecficationpage.SpecificationList);
            Thread.Sleep(2000);
        }

        [When(@"The selected Year has no specifications")]
        public void WhenTheSelectedYearHasNoSpecifications()
        {
            Assert.IsNotNull(managespecficationpage.SelectYear);
            Assert.IsNotNull(managespecficationpage.DefaultYear);
            Thread.Sleep(2000);
        }

        [Then(@"the list of specifications refreshes to display no visable specifications")]
        public void ThenTheListOfSpecificationsRefreshesToDisplayNoVisableSpecifications()
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(managespecficationpage.NoSpecificationsToDisplay);
            Thread.Sleep(2000);
        }

        [Given(@"I have selected an academic year")]
        public void GivenIHaveSelectedAnAcademicYear()
        {
            var selectYear = managespecficationpage.SelectYear;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1819");
        }

        [When(@"I click on the Create a Specification Button")]
        public void WhenIClickOnTheCreateASpecificationButton()
        {
            managespecficationpage.CreateSpecification.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create Specification Page")]
        public void ThenIAmRedirectedToTheCreateSpecificationPage()
        {
            Assert.IsNotNull(createcalculationpage.CalculationName);
            Thread.Sleep(2000);
        }

        [Given(@"I have successfully navigated to the Create Specification Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateSpecificationPage()
        {
            NavigateTo.CreatetheSpecfication();
            Assert.IsNotNull(createcalculationpage.CalculationName);
            Thread.Sleep(2000);
        }

        [When(@"I enter a Name")]
        public void WhenIEnterAName()
        {
            var randomSpecName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecificationName"] = randomSpecName;
            createspecificationpage.SpecName.SendKeys(randomSpecName);
        }

        [When(@"I enter a Description")]
        public void WhenIEnterADescription()
        {
            createspecificationpage.SpecDescription.SendKeys(descriptiontext);
        }

        [When(@"I choose a specification Funding Stream")]
        public void WhenIChooseASpecificationFundingStream()
        {
            var Funding = createspecificationpage.FundingStream;
            var selectElement = new SelectElement(Funding);
            selectElement.SelectByText("DSG");
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            Thread.Sleep(2000);
            createspecificationpage.SaveSpecification.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Manage Specification Page")]
        public void ThenIAmRedirectedToTheManageSpecificationPage()
        {
            Assert.IsNotNull(managespecficationpage.SelectYear);
            Thread.Sleep(2000);
        }

        [Then(@"My new specification is correctly listed")]
        public void ThenMyNewSpecificationIsCorrectlyListed()
        {
            Thread.Sleep(2000);
            var specificationName = ScenarioContext.Current["SpecificationName"];
            string specificationCreated = specificationName.ToString();
            Driver._driver.FindElement(By.LinkText(specificationCreated));
            Thread.Sleep(1000);
        }


        [Then(@"A Full Audit record is created")]
        public void ThenAFullAuditRecordIsCreated()
        {

        }

        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            Thread.Sleep(2000);
            createspecificationpage.CancelSpecification.Click();
            Thread.Sleep(2000);


        }

        [When(@"I enter an Existing Specification Name")]
        public void WhenIEnterAnExistingSpecificationName()
        {
            createspecificationpage.SpecName.SendKeys("Test");
            Thread.Sleep(2000);
        }

        [Then(@"A Unique Specification Name Error is Displayed")]
        public void ThenAUniqueSpecificationNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createspecificationpage.SpecNameError);
            Assert.IsNotNull(createspecificationpage.SpecNameErrorText.Text);
            Thread.Sleep(2000);
        }

        [Given(@"I have missed the field (.*) and (.*) and (.*)")]
        public void GivenIHaveMissedTheField(String name, String funding, String description)
        {
            createspecificationpage.SpecName.SendKeys(name);
            var Funding = createspecificationpage.FundingStream;
            var selectElement = new SelectElement(Funding);
            selectElement.SelectByText(funding);
            createspecificationpage.SpecDescription.SendKeys(description);
            Thread.Sleep(2000);
        }

        [Then(@"the following Specification Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingSpecificationErrorShouldBeDisplayedForFieldNameAnd(string SpecFieldName, string error)
        {
            Thread.Sleep(1000);
            if (SpecFieldName == "Missing Spec Name")
                Assert.AreEqual(error, createspecificationpage.SpecNameErrorText.Text);

            else if (SpecFieldName == "Missing Spec Funding")
                Assert.AreEqual(error, createspecificationpage.SpecFundingErrorText.Text);

            else if (SpecFieldName == "Missing Spec Description")
                Assert.AreEqual(error, createspecificationpage.SpecDescriptionErrorText.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);

        }

        [When(@"I click to view an existing Specification")]
        public void WhenIClickToViewAnExistingSpecification()
        {
            Thread.Sleep(2000);
            Actions.SelectExistingSpecificationManageSpecificationPage();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Manage Policies Page")]
        public void ThenIAmRedirectedToTheManagePoliciesPage()
        {
            Assert.IsNotNull(managepoliciespage.CreatePolicyButton);
            Thread.Sleep(2000);
        }

        [Then(@"A list of Policies is displayed")]
        public void ThenAListOfPoliciesIsDisplayed()
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(managepoliciespage.PolicyList);
            Thread.Sleep(2000);
        }

        [Given(@"I have successfully navigated to the Manage Policies Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheManagePoliciesPage()
        {
            NavigateTo.ManagePolicies();
            Thread.Sleep(2000);
            Assert.IsNotNull(managepoliciespage.CreatePolicyButton);
            Thread.Sleep(2000);
        }

        [When(@"I click on the Create Policy Button")]
        public void WhenIClickOnTheCreatePolicyButton()
        {
            managepoliciespage.CreatePolicyButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create Policy Page")]
        public void ThenIAmRedirectedToTheCreatePolicyPage()
        {
            Assert.IsNotNull(createpolicypage.PolicyName);
            Thread.Sleep(1000);
        }

        [Given(@"I have successfully navigated to the Create Policy Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreatePolicyPage()
        {
            NavigateTo.CreatePolicy();
            Assert.IsNotNull(createpolicypage.PolicyName);
            Thread.Sleep(2000);
        }

        [When(@"I enter a Policy Name")]
        public void WhenIEnterAPolicyName()
        {
            var randomPolicyName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["PolicyName"] = randomPolicyName;
            createpolicypage.PolicyName.SendKeys(randomPolicyName);
        }

        [When(@"I enter a Policy Description")]
        public void WhenIEnterAPolicyDescription()
        {
            createpolicypage.PolicyDescription.SendKeys(descriptiontext);
        }

        [When(@"I click the Save Policy button")]
        public void WhenIClickTheSavePolicyButton()
        {
            Thread.Sleep(2000);
            createpolicypage.SavePolicy.Click();
            Thread.Sleep(2000);
        }


        [Then(@"My new policy is correctly listed")]
        public void ThenMyNewPolicyIsCorrectlyListed()
        {
            Thread.Sleep(2000);
            var polcyNameName = ScenarioContext.Current["PolicyName"];
            string policyCreated = polcyNameName.ToString();
            Driver._driver.FindElement(By.LinkText(policyCreated));
            Thread.Sleep(1000);
        }

        [When(@"I click the Cancel Policy Button")]
        public void WhenIClickTheCancelPolicyButton()
        {
            Thread.Sleep(2000);
            createpolicypage.CancelPolicy.Click();
            Thread.Sleep(1000);
        }

        [When(@"I enter an existing Policy Name")]
        public void WhenIEnterAnExistingPolicyName()
        {
            createpolicypage.PolicyName.SendKeys("Test");
        }


        [Then(@"A Unique Policy Name Error is Displayed")]
        public void ThenAUniquePolicyNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createpolicypage.PolicyNameErrorText.Text);
            Thread.Sleep(2000);
        }


        [Given(@"I have missed the policy field (.*) and (.*)")]
        public void GivenIHaveMissedThePolicyFieldThisIsADescription(string name, string description)
        {
            createpolicypage.PolicyName.SendKeys(name);
            createpolicypage.PolicyDescription.SendKeys(description);
        }

        [Then(@"the following Policy Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingPolicyErrorShouldBeDisplayedForFieldNameAnd(string policyfieldname, string policyerror)
        {
            Thread.Sleep(1000);
            if (policyfieldname == "Missing Name")
                Assert.AreEqual(policyerror, createpolicypage.PolicyNameErrorText.Text);

            else if (policyfieldname == "Missing Description")
                Assert.AreEqual(policyerror, createpolicypage.PolicyDescriptionErrorText.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);
        }

        [When(@"I click the Create calculation specification")]
        public void WhenIClickTheCreateCalculationSpecification()
        {
            managepoliciespage.CreateCalculation.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create Calculation Specification for Policy Page")]
        public void ThenIAmRedirectedToTheCreateCalculationSpecificationForPolicyPage()
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(createcalculationpage.CalculationName);
            Thread.Sleep(2000);
        }

        [Given(@"I have successfully navigated to the Create Calculation Specification for Policy Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateCalculationSpecificationForPolicyPage()
        {
            NavigateTo.CreateCalculation();
            Thread.Sleep(2000);
        }

        [When(@"I enter a Calculation Name")]
        public void WhenIEnterACalculationName()
        {
            var randomCalculationName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["CalculationName"] = randomCalculationName;
            createcalculationpage.CalculationName.SendKeys(randomCalculationName);
        }

        [When(@"I choose a Policy or sub policy")]
        public void WhenIChooseAPolicyOrSubPolicy()
        {
            Actions.CreateCalculationSpecificationpageSelectPolicyOrSubpolicyDropDown();
        }

        [When(@"I choose funding calculation type")]
        public void WhenIChooseFundingCalculationType()
        {
            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selectElement = new SelectElement(calctype);
            selectElement.SelectByValue("Funding");
        }

        [When(@"I choose Number calculation type")]
        public void WhenIChooseNumberCalculationType()
        {
            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selectElement = new SelectElement(calctype);
            selectElement.SelectByValue("Number");
        }

        [When(@"I choose an Allocation Line")]
        public void WhenIChooseAnAllocationLine()
        {
            var allocation = createcalculationpage.CalculationAllocationLine;
            var selectElement = new SelectElement(allocation);
            selectElement.SelectByText("DSG Allocations");
        }

        [When(@"I enter a Calculation Description")]
        public void WhenIEnterACalculationDescription()
        {
            createcalculationpage.CalculationDescription.SendKeys(descriptiontext);
        }

        [When(@"I click the Save Calculation button")]
        public void WhenIClickTheSaveCalculationButton()
        {
            Thread.Sleep(2000);
            createcalculationpage.SaveCalculation.Click();
            Thread.Sleep(2000);
        }

        [Then(@"My new Calculation is correctly listed")]
        public void ThenMyNewCalculationIsCorrectlyListed()
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(managepoliciespage.CalculationList);
            var calculationName = ScenarioContext.Current["CalculationName"];
            string calculationCreated = calculationName.ToString();
            var calcelements = Driver._driver.FindElements(By.CssSelector(".policy-list"));
            IWebElement createdcalculation = null;
            foreach (var element in calcelements)
            {
                if (element.Text.Contains(calculationCreated))
                {
                    {
                        createdcalculation = element;
                        break;
                    }
                }

            }

            Thread.Sleep(1000);
            if (createdcalculation != null)
            {
                Console.WriteLine("The New Calculation " + calculationCreated + " was Saved correctly");
            }
            else
            {
                createdcalculation.Should().NotBeNull("Unable to find dataset " + calculationCreated + " within the list view");
            }
            Thread.Sleep(2000);
        }

        [When(@"I click the Cancel Calculation button")]
        public void WhenIClickTheCancelCalculationButton()
        {
            createcalculationpage.CancelCalculation.Click();
            Thread.Sleep(2000);
        }

        [When(@"I enter an Existing Calculation Name")]
        public void WhenIEnterAnExistingCalculationName()
        {
            createcalculationpage.CalculationName.SendKeys("Test");
        }


        [Then(@"A Unique Calculation Name Error is Displayed")]
        public void ThenAUniqueCalculationNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createcalculationpage.CalculationNameError.Text);
            Thread.Sleep(2000);
        }

        [Then(@"A Calculation Type Error is Displayed")]
        public void ThenACalculationTypeErrorIsDisplayed()
        {
            createcalculationpage.CalculationTypeError.Should().NotBeNull();
            Thread.Sleep(2000);
        }



        [Given(@"I have missed the calculation field (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void GivenIHaveMissedTheCalculationField(string name, string policy, string type, string allocation, string description)
        {
            createcalculationpage.CalculationName.SendKeys(name);

            var policydropdown = createcalculationpage.SelectPolicy_SubPolicy;
            var selectElement = new SelectElement(policydropdown);
            selectElement.SelectByText(policy);

            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selecttypeElement = new SelectElement(calctype);
            selecttypeElement.SelectByValue(type);

            var allocationdropdown = createcalculationpage.CalculationAllocationLine;
            var selectElement01 = new SelectElement(allocationdropdown);
            selectElement01.SelectByText(allocation);

            createcalculationpage.CalculationDescription.SendKeys(description);
            Thread.Sleep(2000);

        }

        [Then(@"the following Calculation Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingCalculationErrorShouldBeDisplayedForFieldNameAnd(string CalculationFieldname, string calcerror)
        {
            Thread.Sleep(1000);
            if (CalculationFieldname == "MissingCalcName")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationNameError.Text);

            else if (CalculationFieldname == "MissingCalcPolicy")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationPolicyError.Text);

            else if (CalculationFieldname == "MissingCalcAllocation")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationAllocationError.Text);

            else if (CalculationFieldname == "MissingCalcDescription")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationDescriptionError.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);

        }

        [When(@"I click the select Create sub policy")]
        public void WhenIClickTheSelectCreateSubPolicy()
        {
            managepoliciespage.CreateSubPolicy.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create a Sub Policy Page")]
        public void ThenIAmRedirectedToTheCreateASubPolicyPage()
        {
            Assert.IsNotNull(createsubpolicypage.SubPolicyName);
            Thread.Sleep(2000);
        }

        [Given(@"I have successfully navigated to the Create Sub Policy Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateSubPolicyPage()
        {
            NavigateTo.CreateSubPolicy();
            Assert.IsNotNull(createsubpolicypage.SubPolicyName);
            Thread.Sleep(2000);
        }

        [When(@"I enter a Sub Policy Name")]
        public void WhenIEnterASubPolicyName()
        {
            var randomSubPolicyName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SubPolicyName"] = randomSubPolicyName;
            createsubpolicypage.SubPolicyName.SendKeys(randomSubPolicyName);
        }

        [When(@"I choose a Policy from the dropdown")]
        public void WhenIChooseAPolicyFromTheDropdown()
        {
            Actions.SelectPolicyForSubPolicyCreationDropdownOption();
            createsubpolicypage.SubPolicyDescription.Click();
            Thread.Sleep(2000);
        }

        [When(@"I enter a Sub Policy Description")]
        public void WhenIEnterASubPolicyDescription()
        {
            createsubpolicypage.SubPolicyDescription.SendKeys(descriptiontext);
        }

        [When(@"I click the Save Sub Policy button")]
        public void WhenIClickTheSaveSubPolicyButton()
        {
            Thread.Sleep(2000);
            createsubpolicypage.SaveSubPolicy.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the new Sub Policy is correctly listed")]
        public void ThentheNewSubPolicyIsCorrectlyListed()
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(managepoliciespage.SubPolicyList);
            var subPolicyName = ScenarioContext.Current["SubPolicyName"];
            string subPolicyCreated = subPolicyName.ToString();
            var subpolicyelements = Driver._driver.FindElements(By.CssSelector(".policy-list"));
            IWebElement createdsubpolicy = null;
            foreach (var element in subpolicyelements)
            {
                if (element.Text.Contains(subPolicyCreated))
                {
                    {
                        createdsubpolicy = element;
                        break;
                    }
                }

            }

            Thread.Sleep(1000);
            if (createdsubpolicy != null)
            {
                Console.WriteLine("The New Sub Policy " + subPolicyCreated + " was Saved correctly");
            }
            else
            {
                createdsubpolicy.Should().NotBeNull("Unable to find Sub Policy " + subPolicyCreated + " within the list view");
            }

            Thread.Sleep(2000);
        }

        [When(@"I click the Cancel Sub Policy button")]
        public void WhenIClickTheCancelSubPolicyButton()
        {
            createsubpolicypage.CancelSubPolicy.Click();
            Thread.Sleep(2000);
        }

        [When(@"I enter a Sub Policy Name that already exists")]
        public void WhenIEnterASubPolicyNameThatAlreadyExists()
        {
            createsubpolicypage.SubPolicyName.SendKeys("test");
        }


        [Then(@"A Unique Sub Policy Name Error is Displayed")]
        public void ThenAUniqueSubPolicyNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createsubpolicypage.SubPolicyMissingNameErrorText.Text);
            Thread.Sleep(2000);
        }


        [Given(@"And I have missed the Sub Policy field (.*) and (.*)")]
        public void GivenAndIHaveMissedTheSubPolicyFieldAndTestSpecAndDescription(string name, string description)
        {
            createsubpolicypage.SubPolicyName.SendKeys(name);
            createsubpolicypage.SubPolicyDescription.SendKeys(description);
            Thread.Sleep(2000);

        }

        [Given(@"I choose a Policy from the dropdown")]
        public void GivenIChooseAPolicyFromTheDropdown()
        {
            Actions.SelectPolicyForSubPolicyCreationDropdownOption();
            createsubpolicypage.SubPolicyDescription.Click();
            Thread.Sleep(2000);
        }


        [Then(@"the following Sub Policy Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingSubPolicyErrorShouldBeDisplayedForFieldNameAnd(string SubPolicyFieldname, string subpolicyerror)
        {
            Thread.Sleep(1000);
            if (SubPolicyFieldname == "SubPolicyNameMissing")
                Assert.AreEqual(subpolicyerror, createsubpolicypage.SubPolicyMissingNameErrorText.Text);

            else if (SubPolicyFieldname == "SubPolicyDescriptionMissing")
                Assert.AreEqual(subpolicyerror, createsubpolicypage.SubPolicyMissingDescriptionErrorText.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);
        }

        [Then(@"a Sub Policy Missing Policy Error should be displayed")]
        public void ThenASubPolicyMissingPolicyErrorShouldBeDisplayed()
        {
            Assert.IsNotNull(createsubpolicypage.SubPolicyMissingPolicyErrorText.Text);
            Thread.Sleep(2000);
        }

        [Given(@"I have created a new specification")]
        public void GivenIHaveCreatedANewSpecification()
        {
            CreateNewSpecification.CreateANewSpecification();
            Thread.Sleep(2000);
        }

        [Given(@"redirected to the Manage Specificaiton Page")]
        public void GivenRedirectedToTheManageSpecificaitonPage()
        {
            managepoliciespage.datasetsTab.Should().NotBeNull();
            managepoliciespage.datasetsTab.Displayed.Should().BeTrue();
        }

        [When(@"I choose to view the datasets tab")]
        public void WhenIChooseToViewTheDatasetsTab()
        {
            managepoliciespage.datasetsTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"No alert about provider datasets is displayed")]
        public void ThenNoAlertAboutProviderDatasetsIsDisplayed()
        {
            var providerwarning = Driver._driver.FindElements(By.CssSelector(".provider-datasets-warning-container"));

            if (providerwarning.Count > 0)
            {
                Console.WriteLine("Provider Data Warning Message is Displayed in Error");
            }
            else
            {
                Console.WriteLine("Provider Data Warning Message is Not Displayed");
            }
        }


        [When(@"I choose to create a new dataset without setting as Provider Data")]
        public void WhenIChooseToCreateANewDatasetWithoutSettingAsProviderData()
        {
            ManageSpecificationCreateNewDataset.CreateANewDataset();
        }

        [When(@"I am redirected to the DataSet page")]
        public void WhenIAmRedirectedToTheDataSetPage()
        {
            managepoliciespage.datasetsTab.Should().NotBeNull();
        }

        [Then(@"the new dataset has been saved and displayed correctly")]
        public void ThenTheNewDatasetHasBeenSavedAndDisplayedCorrectly()
        {
            var datasetName = ScenarioContext.Current["DatasetSchemaName"];
            string datasetCreated = datasetName.ToString();
            var datasetelements = Driver._driver.FindElements(By.CssSelector(".view-dataset .datasetschemaassigned-list-title-container span"));
            IWebElement createddataset = null;
            foreach (var element in datasetelements)
            {
                if (element.Text.Contains(datasetCreated))
                {
                    {
                        createddataset = element;
                        break;
                    }
                }

            }

            Thread.Sleep(1000);
            if (createddataset != null)
            {
                Console.WriteLine("The New Dataset " + datasetCreated + " was Saved correctly");
            }
            else
            {
                createddataset.Should().NotBeNull("Unable to find dataset " + datasetCreated + " within the list view");
            }

            Thread.Sleep(1000);

        }


        [Then(@"An Alert that No dataset has been set as provider data should be displayed")]
        public void ThenAnAlertThatNoDatasetHasBeenSetAsProviderDataShouldBeDisplayed()
        {
            IWebElement datasetwarning = managepoliciespage.providerdatasetswarningcontainer;
            datasetwarning.Should().NotBeNull();
            string datasetwraningtext = datasetwarning.Text;
            Console.WriteLine("The following Dataset Warning Message was displayed " + datasetwraningtext);

        }

        [When(@"I choose to create a new dataset set as Provider Data")]
        public void WhenIChooseToCreateANewDatasetSetAsProviderData()
        {
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
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


