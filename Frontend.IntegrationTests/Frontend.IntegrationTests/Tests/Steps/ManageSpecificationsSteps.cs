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
using System.Globalization;

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
        EditPolicyPage editpolicypage = new EditPolicyPage();
        EditSubPolicyPage editsubpolicypage = new EditSubPolicyPage();
        EditSpecificationPage editspecificationpage = new EditSpecificationPage();
        HomePage homepage = new HomePage();
        EditCalculationPage editcalculationpage = new EditCalculationPage();

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
            IWebElement filtercontainer = managespecficationpage.SpecificationFilterContainer;
            IWebElement fundingperiodfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingperiodfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingperiodselected = selectfilteroption.Text;
            Console.WriteLine("Funding Period Filter Option selected = " + fundingperiodselected);
            selectfilteroption.Click();
            managespecficationpage.SearchSpecification.Click();
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
            selectElement.SelectByValue("FY2017181");
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

        [Given(@"A Specification has been previously created with a Unique Name")]
        public void GivenASpecificationHasBeenPreviouslyCreatedWithAUniqueName()
        {
            CreateNewSpecification.CreateANewSpecification();
            homepage.Header.Click();
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
            createspecificationpage.FundingStream.Click();
            createspecificationpage.FundingStream.SendKeys(OpenQA.Selenium.Keys.Enter);
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
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            createspecificationpage.SpecName.SendKeys(specCreated);
            Console.WriteLine("The Existing Specification Name entered was: " + specCreated);
        }

        [Then(@"A Unique Specification Name Error is Displayed")]
        public void ThenAUniqueSpecificationNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createspecificationpage.SpecNameError);
            string specNameError = createspecificationpage.SpecNameError.Text;
            Console.WriteLine("The following error message was correctly displayed: " + specNameError);
            Thread.Sleep(2000);
        }

        [Given(@"I have missed the field (.*) and (.*)")]
        public void GivenIHaveMissedTheField(String name, String description)
        {
            createspecificationpage.SpecName.SendKeys(name);
            createspecificationpage.SpecDescription.SendKeys(description);
            Thread.Sleep(2000);
        }

        [Then(@"the following Specification Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingSpecificationErrorShouldBeDisplayedForFieldNameAnd(string SpecFieldName, string error)
        {
            Thread.Sleep(1000);
            if (SpecFieldName == "Missing Spec Name")
                Assert.AreEqual(error, createspecificationpage.SpecNameError.Text);

            else if (SpecFieldName == "Missing Spec Description")
                Assert.AreEqual(error, createspecificationpage.SpecDescriptionError.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);

        }

        [Given(@"I have previously created a new specification")]
        public void GivenIHavePreviouslyCreatedANewSpecification()
        {
            CreateNewSpecification.CreateANewSpecification();
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

        [Given(@"I have successfully navigated to the Manage Policies Page for the new specification")]
        public void GivenIHaveSuccessfullyNavigatedToTheManagePoliciesPageForTheNewSpecification()
        {
            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            homepage.Header.Click();
            Thread.Sleep(2000);
            homepage.ManagetheSpecification.Click();
            Thread.Sleep(2000);

            Driver._driver.FindElement(By.LinkText(specCreated)).Click();
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

        [Given(@"A Policy has been previously created with a Unique Policy Name")]
        public void GivenAPolicyHasBeenPreviouslyCreatedWithAUniquePolicyName()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            Thread.Sleep(2000);
        }

        [Given(@"I have successfully navigated to the Create Policy Page for the previously created specification")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreatePolicyPageForThePreviouslyCreatedSpecification()
        {
            managepoliciespage.CreatePolicyButton.Click();
            Thread.Sleep(2000);
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
            var specPolicyName = ScenarioContext.Current["SpecPolicyName"];
            string specPolicyCreated = specPolicyName.ToString();

            createpolicypage.PolicyName.SendKeys(specPolicyCreated);
            Console.WriteLine("The Existing Policy Name entered was: " + specPolicyCreated);
        }


        [Then(@"A Unique Policy Name Error is Displayed")]
        public void ThenAUniquePolicyNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createpolicypage.PolicyNameErrorText.Text);
            string policyNameError = createpolicypage.PolicyNameErrorText.Text;
            Console.WriteLine("The following Error message was displayed: " + policyNameError);
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
            selectElement.SelectByText("16-19 high level learners programme Funding");
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

            var calcelements = Driver._driver.FindElements(By.CssSelector(".cf"));
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

        [Given(@"A Calculation Specification has been previously created with a Unique Name")]
        public void GivenACalculationSpecificationHasBeenPreviouslyCreatedWithAUniqueName()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
        }

        [Given(@"I have successfully navigated to the Create Calculation Specification Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateCalculationSpecificationPage()
        {
            managepoliciespage.CreateCalculation.Click();
            Thread.Sleep(2000);
        }

        [When(@"I enter an Existing Calculation Name")]
        public void WhenIEnterAnExistingCalculationName()
        {
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();

            createcalculationpage.CalculationName.SendKeys(specCalcCreated);
            Console.WriteLine("The Existing Calculation Name entered was: " + specCalcCreated);
        }


        [Then(@"A Unique Calculation Name Error is Displayed")]
        public void ThenAUniqueCalculationNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createcalculationpage.CalculationNameError.Text);
            string calcSpecificationNameError = createcalculationpage.CalculationNameError.Text;
            Console.WriteLine("The Following Error Message was displayed: " + calcSpecificationNameError);
            Thread.Sleep(2000);
        }

        [Then(@"A Calculation Type Error is Displayed")]
        public void ThenACalculationTypeErrorIsDisplayed()
        {
            createcalculationpage.CalculationTypeError.Should().NotBeNull();
            Thread.Sleep(2000);
        }



        [Given(@"I have missed the calculation field (.*) and (.*) and (.*) and (.*)")]
        public void GivenIHaveMissedTheCalculationField(string name, string type, string allocation, string description)
        {
            createcalculationpage.CalculationName.SendKeys(name);

            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selecttypeElement = new SelectElement(calctype);
            selecttypeElement.SelectByValue(type);

            var allocationdropdown = createcalculationpage.CalculationAllocationLine;
            var selectElement01 = new SelectElement(allocationdropdown);
            selectElement01.SelectByText(allocation);

            createcalculationpage.CalculationDescription.SendKeys(description);
            Thread.Sleep(2000);

        }

        [Given(@"I have correctly selected a Policy")]
        public void GivenIHaveCorrectlySelectedAPolicy()
        {
            Actions.CreateCalculationSpecificationpageSelectPolicyOrSubpolicyDropDown();
        }


        [Given(@"I click the Create calculation specification")]
        public void GivenIClickTheCreateCalculationSpecification()
        {
            managepoliciespage.CreateCalculation.Click();
            Thread.Sleep(2000);
        }


        [Given(@"I have not completed the following calculation fields (.*) and (.*) and (.*)")]
        public void GivenIHaveNotCompletedTheFollowingCalculationFields(string name, string type, string description)
        {
            createcalculationpage.CalculationName.SendKeys(name);

            var calctype = createcalculationpage.CalculationTypeDropDown;
            var selecttypeElement = new SelectElement(calctype);
            selecttypeElement.SelectByValue(type);

            createcalculationpage.CalculationDescription.SendKeys(description);
            Thread.Sleep(2000);
        }


        [Then(@"the following Calculation Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingCalculationErrorShouldBeDisplayedForFieldNameAnd(string CalculationFieldname, string calcerror)
        {
            Thread.Sleep(1000);
            if (CalculationFieldname == "MissingCalcFundingName")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationNameError.Text);

            else if (CalculationFieldname == "MissingCalcFundingAllocation")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationAllocationError.Text);

            else if (CalculationFieldname == "MissingCalcFundingDescription")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationDescriptionError.Text);

            else throw new InvalidOperationException("Unknown Field");
            Thread.Sleep(2000);

        }

        [Then(@"the following Number Calculation Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingNumberCalculationErrorShouldBeDisplayedForFieldNameAnd(string CalculationFieldname, string calcerror)
        {
            Thread.Sleep(1000);
            if (CalculationFieldname == "MissingCalcNumberName")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationNameError.Text);

            else if (CalculationFieldname == "MissingCalcNumberPolicy")
                Assert.AreEqual(calcerror, createcalculationpage.CalculationPolicyError.Text);

            else if (CalculationFieldname == "MissingCalcNumberDescription")
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

            var subpolicyelements = Driver._driver.FindElements(By.CssSelector(".cf"));
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

        [Given(@"A Sub Policy has been previously created with a Unique Name")]
        public void GivenASubPolicyHasBeenPreviouslyCreatedWithAUniqueName()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewSubPolicy.CreateANewSpecificationSubPolicy();
        }

        [Given(@"I have successfully navigated to the Create Sub Policy Page for the same Specification")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateSubPolicyPageForTheSameSpecification()
        {
            managepoliciespage.CreateSubPolicy.Click();
            Thread.Sleep(2000);
        }



        [When(@"I enter a Sub Policy Name that already exists")]
        public void WhenIEnterASubPolicyNameThatAlreadyExists()
        {
            var specPolicyName = ScenarioContext.Current["SpecSubPolicyName"];
            string specSubPolicyCreated = specPolicyName.ToString();

            createsubpolicypage.SubPolicyName.SendKeys(specSubPolicyCreated);
            Console.WriteLine("The Existing Sub Policy Name entered was: " + specSubPolicyCreated);
        }


        [Then(@"A Unique Sub Policy Name Error is Displayed")]
        public void ThenAUniqueSubPolicyNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createsubpolicypage.SubPolicyMissingNameErrorText.Text);
            string subPolicyNameError = createsubpolicypage.SubPolicyMissingNameErrorText.Text;
            Console.WriteLine("THe following error was displayed: " + subPolicyNameError);
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

        [Then(@"A Unique Allocation Error is Displayed")]
        public void ThenAUniqueAllocationErrorIsDisplayed()
        {
            IWebElement allocationError = createcalculationpage.CalculationAllocationError;
            allocationError.Should().NotBeNull();
            string allocationErrorText = allocationError.Text;
            allocationError.Text.Should().Be("Select an allocation line", "Error Message is Incorrect");
            Console.WriteLine("The following Allocation Warning Message was displayed " + allocationErrorText);
        }

        [When(@"I choose a specification Funding Period")]
        public void WhenIChooseASpecificationFundingPeriod()
        {
            var selectYear = createspecificationpage.SpecFundingPeriod;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("AY2017181");
            Thread.Sleep(2000);
        }

        [When(@"I choose a different specification Funding Period")]
        public void WhenIChooseADifferentSpecificationFundingPeriod()
        {
            var selectYear = createspecificationpage.SpecFundingPeriod;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("FY2017181");
            Thread.Sleep(2000);
        }


        [Then(@"A Unique Funding Stream Error is Displayed")]
        public void ThenAUniqueFundingStreamErrorIsDisplayed()
        {
            IWebElement noFundingStream = createspecificationpage.SpecFundingStreamError;
            noFundingStream.Should().NotBeNull();
            string noFundingStreamError = noFundingStream.Text;
            noFundingStream.Text.Should().Be("Select at least one funding stream", "Correct Error Message is not displayed");
            Console.WriteLine("The following Funding Stream Warning Message was displayed " + noFundingStreamError);
        }

        [Given(@"I choose a specification Funding Period")]
        public void GivenIChooseASpecificationFundingPeriod()
        {
            var selectYear = createspecificationpage.SpecFundingPeriod;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("AY2017181");
            Thread.Sleep(2000);
        }

        [Given(@"I choose a specification Funding Stream")]
        public void GivenIChooseASpecificationFundingStream()
        {
            createspecificationpage.FundingStream.Click();
            createspecificationpage.FundingStream.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        [When(@"I choose (.*) specification Funding Streams")]
        public void WhenIChooseSpecificationFundingStreams(string p0)
        {
            SelectElement selectElement = new SelectElement(createspecificationpage.SpecFundingStreamOptionContainer);
            var options = selectElement.Options;

            int? maximumItems = null;
            int parsedInt;
            if (int.TryParse(p0, out parsedInt))
            {
                if (parsedInt > 0)
                {
                    maximumItems = parsedInt;
                }
            }

            for (int i = 0; i < options.Count; i++)
            {
                if (maximumItems != null && maximumItems.HasValue && i >= maximumItems.Value)
                {
                    break;
                }

                IWebElement optionElement = options[i];
                string optionElementText = optionElement.Text;
                Console.WriteLine(optionElementText);

                createspecificationpage.FundingStream.Click();
                createspecificationpage.SpecFundingStreamTextField.SendKeys(OpenQA.Selenium.Keys.Shift + optionElementText);
                Thread.Sleep(2000);
                createspecificationpage.FundingStream.SendKeys(OpenQA.Selenium.Keys.Enter);


            }

        }


        [When(@"I then select to remove a Funding Stream")]
        public void WhenIThenSelectToRemoveAFundingStream()
        {
            createspecificationpage.SpecFundingStreamRemoveOption.Click();
            Thread.Sleep(2000);
            createspecificationpage.FundingStream.Click();
        }

        [Then(@"the selected funding stream is removed from the new Specification")]
        public void ThenTheSelectedFundingStreamIsRemovedFromTheNewSpecification()
        {
            IWebElement fundingStream = createspecificationpage.SpecFundingStreamFirstSelected;
            string remainingFundingStream = fundingStream.Text;
            Console.WriteLine("The remaining Funding Stream is: " + remainingFundingStream);
        }

        [Then(@"the Manage Policies Policy List displays the Edit Policy option")]
        public void ThenTheManagePoliciesPolicyListDisplaysTheEditPolicyOption()
        {
            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("i"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        firstSelectEditPolicy = optionelement;

                        break;


                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditPolicy != null)
                {
                    firstSelectEditPolicy.Click();
                    Thread.Sleep(2000);
                    editpolicypage.editPolicyName.Should().NotBeNull();
                }
                else
                {
                    firstSelectEditPolicy.Should().NotBeNull("No Edit Policy Option exist for the Policy selected");
                }
            }
            else
            {
                firstSelectEditPolicy.Should().NotBeNull("No Edit Policy Option exists");
            }
        }


        [Given(@"I have created a New Sub Policy for that Specification")]
        public void GivenIHaveCreatedANewSubPolicyForThatSpecification()
        {
            ManageSpecificationCreateNewSubPolicy.CreateANewSpecificationSubPolicy();
            Thread.Sleep(2000);
        }

        [Then(@"the Manage Policies Policy List displays the Edit Sub Policy option")]
        public void ThenTheManagePoliciesPolicyListDisplaysTheEditSubPolicyOption()
        {
            IWebElement editSubPolicy = Driver._driver.FindElement(By.CssSelector(".data-subpolicy-editlink-icon > i:nth-child(1)"));
            editSubPolicy.Should().NotBeNull();
            editSubPolicy.Click();
            Thread.Sleep(2000);

            /*
            IWebElement subpolicyList = managepoliciespage.SubPolicyList;
            subpolicyList.Should().NotBeNull();

            var containerElements = subpolicyList;
            IWebElement firstSelectEditSubPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("i"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        firstSelectEditSubPolicy = optionelement;

                        break;


                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditSubPolicy != null)
                {
                    firstSelectEditSubPolicy.Click();
                    Thread.Sleep(2000);
                    editsubpolicypage.editSubPolicyName.Should().NotBeNull();
                }
                else
                {
                    firstSelectEditSubPolicy.Should().NotBeNull("No Edit Sub Policy Option exist for the Policy selected");
                }
            }
            else
            {
                firstSelectEditSubPolicy.Should().NotBeNull("No Edit Sub Policy Option exists");
            }
            */
        }

        [Given(@"I have navigated to the Edit Policy Page")]
        public void GivenIHaveNavigatedToTheEditPolicyPage()
        {
            NavigateTo.EditSpecificationPolicyPage();

            editpolicypage.editPolicyDescription.Should().NotBeNull();
            editpolicypage.editPolicyUpdateButton.Should().NotBeNull();
            editpolicypage.editPolicyBackLink.Should().NotBeNull();
        }

        [When(@"I update the Policy Name")]
        public void WhenIUpdateThePolicyName()
        {
            string editedname = "Test Policy Edited Name ";

            var randomEditPolicyName = editedname + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditPolicyName"] = randomEditPolicyName;

            editpolicypage.editPolicyName.Clear();
            editpolicypage.editPolicyName.SendKeys(randomEditPolicyName);

        }

        [When(@"click the Update Button")]
        public void WhenClickTheUpdateButton()
        {
            editpolicypage.editPolicyUpdateButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected back to the Manage Polices Page")]
        public void ThenIAmRedirectedBackToTheManagePolicesPage()
        {
            managepoliciespage.CreatePolicyButton.Should().NotBeNull();
        }

        [Then(@"the Policy Name is correctly updated")]
        public void ThenThePolicyNameIsCorrectlyUpdated()
        {
            var editedPolicyName = ScenarioContext.Current["EditPolicyName"];
            string editedPolicyCreated = editedPolicyName.ToString();

            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("span"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        if (optionelement.Text.Contains(editedPolicyCreated))
                        {
                            {
                                firstSelectEditPolicy = optionelement;

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditPolicy != null)
                {
                    string updatedPolicyName = firstSelectEditPolicy.Text;
                    Console.WriteLine("The Specification Policy name has been updated to: " + updatedPolicyName);

                }
                else
                {
                    firstSelectEditPolicy.Should().NotBeNull("Edit Policy Name has is not displayed correctly");
                }
            }
            else
            {
                firstSelectEditPolicy.Should().NotBeNull("Edit Policy Name has Failed");
            }
        }


        [When(@"I update the Policy Description")]
        public void WhenIUpdateThePolicyDescription()
        {
            string editdescription = "This is an Edited Description ";

            var randomEditPolicyDesc = editdescription + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditPolicyDesc"] = randomEditPolicyDesc;

            editpolicypage.editPolicyDescription.Clear();
            editpolicypage.editPolicyDescription.SendKeys(randomEditPolicyDesc);
        }

        [Then(@"the Policy Description is correctly updated")]
        public void ThenThePolicyDescriptionIsCorrectlyUpdated()
        {
            var editedPolicyDesc = ScenarioContext.Current["EditPolicyDesc"];
            string updatedPolicyDesc = editedPolicyDesc.ToString();

            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("td"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        if (optionelement.Text.Contains(updatedPolicyDesc))
                        {
                            {
                                firstSelectEditPolicy = optionelement;

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditPolicy != null)
                {
                    string updatedDescription = firstSelectEditPolicy.Text;
                    Console.WriteLine("The Specification Policy Description has been updated to: " + updatedDescription);

                }
                else
                {
                    firstSelectEditPolicy.Should().NotBeNull("Edit Policy Name has is not displayed correctly");
                }
            }
            else
            {
                firstSelectEditPolicy.Should().NotBeNull("Edit Policy Name has Failed");
            }
        }


        [When(@"I choose to click the Back Link")]
        public void WhenIChooseToClickTheBackLink()
        {
            editpolicypage.editPolicyBackLink.Click();
            Thread.Sleep(2000);
        }


        [Given(@"I have navigated to the Edit Sub Policy Page")]
        public void GivenIHaveNavigatedToTheEditSubPolicyPage()
        {
            NavigateTo.EditSpecificationSubPolicyPage();
        }

        [When(@"I update the Sub Policy Name")]
        public void WhenIUpdateTheSubPolicyName()
        {
            string editsubpolicyname = "Test Sub Policy Edited Name ";

            var randomEditSubPolicyName = editsubpolicyname + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditSubPolicyName"] = randomEditSubPolicyName;

            editsubpolicypage.editSubPolicyName.Clear();
            editsubpolicypage.editSubPolicyName.SendKeys(randomEditSubPolicyName);
        }

        [Then(@"the Sub Policy Name is correctly updated")]
        public void ThenTheSubPolicyNameIsCorrectlyUpdated()
        {
            var editedSubPolicyName = ScenarioContext.Current["EditSubPolicyName"];
            string editedSubPolicyCreated = editedSubPolicyName.ToString();

            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditSubPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("span"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        if (optionelement.Text.Contains(editedSubPolicyCreated))
                        {
                            {
                                firstSelectEditSubPolicy = optionelement;

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditSubPolicy != null)
                {
                    string updatedSubPolicyName = firstSelectEditSubPolicy.Text;
                    Console.WriteLine("The Specification Sub Policy name has been updated to: " + updatedSubPolicyName);

                }
                else
                {
                    firstSelectEditSubPolicy.Should().NotBeNull("Edit Sub Policy Name has is not displayed correctly");
                }
            }
            else
            {
                firstSelectEditSubPolicy.Should().NotBeNull("Edit Sub Policy Name has Failed");
            }
        }


        [When(@"I update the Sub Policy Description")]
        public void WhenIUpdateTheSubPolicyDescription()
        {
            string editdescription = "This is an Edited Description ";

            var randomEditSubPolicyDesc = editdescription + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditSubPolicyDesc"] = randomEditSubPolicyDesc;

            editsubpolicypage.editSubPolicyDesc.Clear();
            editsubpolicypage.editSubPolicyDesc.SendKeys(randomEditSubPolicyDesc);
        }

        [Then(@"the Sub Policy Description is correctly updated")]
        public void ThenTheSubPolicyDescriptionIsCorrectlyUpdated()
        {
            var editedSubPolicyDesc = ScenarioContext.Current["EditSubPolicyDesc"];
            string updatedSubPolicyDesc = editedSubPolicyDesc.ToString();

            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("td"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        if (optionelement.Text.Contains(updatedSubPolicyDesc))
                        {
                            {
                                firstSelectEditPolicy = optionelement;

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditPolicy != null)
                {
                    string updatedDescription = firstSelectEditPolicy.Text;
                    Console.WriteLine("The Specification Sub Policy Description has been updated to: " + updatedDescription);

                }
                else
                {
                    firstSelectEditPolicy.Should().NotBeNull("Edit Sub Policy Description has is not displayed correctly");
                }
            }
            else
            {
                firstSelectEditPolicy.Should().NotBeNull("Edit Sub Policy Description has Failed");
            }
        }


        [Given(@"I then create an additional Policy for the Specification")]
        public void GivenIThenCreateAnAdditionalPolicyForTheSpecification()
        {
            ManageSpecificationCreateNewAddPolicy.CreateAddNewSpecificationPolicy();
        }

        [Given(@"I have selected to Edit the Sub Policy")]
        public void GivenIHaveSelectedToEditTheSubPolicy()
        {
            IWebElement subpolicyList = managepoliciespage.SubPolicyList;
            subpolicyList.Should().NotBeNull();

            IWebElement editSubPolicy = Driver._driver.FindElement(By.CssSelector(".data-subpolicy-editlink-icon > i:nth-child(1)"));
            editSubPolicy.Should().NotBeNull();
            editSubPolicy.Click();
            Thread.Sleep(2000);

            /*
            var containerElements = subpolicyList;
            IWebElement firstSelectEditSubPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        firstSelectEditSubPolicy = optionelement;

                        break;


                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditSubPolicy != null)
                {
                    firstSelectEditSubPolicy.Click();
                    Thread.Sleep(2000);
                    editsubpolicypage.editSubPolicyName.Should().NotBeNull();
                }
                else
                {
                    firstSelectEditSubPolicy.Should().NotBeNull("No Edit Sub Policy Option exist for the Policy selected");
                }
            }
            else
            {
                firstSelectEditSubPolicy.Should().NotBeNull("No Edit Sub Policy Option exists");
            }
            */
        }


        [When(@"I update the Sub Policies associated Policy")]
        public void WhenIUpdateTheSubPoliciesAssociatedPolicy()
        {
            var addSpecPolicyName = ScenarioContext.Current["AddSpecPolicyName"];
            string addSpecPolicyCreated = addSpecPolicyName.ToString();

            var containerElements = Driver._driver.FindElement(By.Id("EditSubPolicyViewModel-ParentPolicyId"));
            IWebElement firstSelectPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains(addSpecPolicyCreated))
                        {
                            {
                                firstSelectPolicy = optionelement;
                                break;
                            }
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectPolicy != null)
                {
                    firstSelectPolicy.Click();
                }
                else
                {
                    firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        [Then(@"the Sub Policy is shown as associated to the selected Policy")]
        public void ThenTheSubPolicyIsShownAsAssociatedToTheSelectedPolicy()
        {
            var addSpecPolicyName = ScenarioContext.Current["AddSpecPolicyName"];
            string addSpecPolicyCreated = addSpecPolicyName.ToString();

            Console.WriteLine("The Sub Policy has been successfully associated to Policy " + addSpecPolicyCreated);
        }

        [Given(@"I have navigated to the Manage Policies Page")]
        public void GivenIHaveNavigatedToTheManagePoliciesPage()
        {
            managepoliciespage.CreatePolicyButton.Should().NotBeNull();
        }

        [Then(@"the Manage Policies Policy List displays the Edit Specification option")]
        public void ThenTheManagePoliciesPolicyListDisplaysTheEditSpecificationOption()
        {
            managepoliciespage.editSpecification.Should().NotBeNull();
        }


        [Given(@"I have navigated to the Edit Specification Page")]
        public void GivenIHaveNavigatedToTheEditSpecificationPage()
        {
            NavigateTo.EditSpecificationPage();
        }

        [When(@"I update the Specification Name")]
        public void WhenIUpdateTheSpecificationName()
        {
            string editspecificationname = "Test Specification Edited Name ";

            var randomEditSpecificationName = editspecificationname + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditSpecificationName"] = randomEditSpecificationName;

            editspecificationpage.editSpecificationName.Clear();
            editspecificationpage.editSpecificationName.SendKeys(randomEditSpecificationName);
        }

        [When(@"click the Update Specification Button")]
        public void WhenClickTheUpdateSpecificationButton()
        {
            editspecificationpage.editSpecificationSaveButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Specification is correctly updated")]
        public void ThenTheSpecificationIsCorrectlyUpdated()
        {
            var editSpecName = ScenarioContext.Current["EditSpecificationName"];
            string editSpecNameCreated = editSpecName.ToString();

            IWebElement specTitleName = managepoliciespage.specificationName;
            string specName = specTitleName.Text;

            specName.Contains(editSpecNameCreated);
            specTitleName.Text.Should().Be(editSpecNameCreated, "Edit Spec Name has not been saved correctly");
            Console.WriteLine("The Edits Specification Name is: " + specName);

        }

        [When(@"I update the Specification Description")]
        public void WhenIUpdateTheSpecificationDescription()
        {
            string editspecificationdescription = "Test Specification Edited Description ";

            var randomEditSpecificationDesc = editspecificationdescription + TestDataNumericUtils.RandomNumerics(6);
            ScenarioContext.Current["EditSpecificationName"] = randomEditSpecificationDesc;

            editspecificationpage.editSpecificationName.Clear();
            editspecificationpage.editSpecificationName.SendKeys(randomEditSpecificationDesc);
        }

        [When(@"I update the Specification Funding period")]
        public void WhenIUpdateTheSpecificationFundingPeriod()
        {
            var selectYear = editspecificationpage.editSpecificationFundingPeriodDropdown;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("FY2017181");
            Thread.Sleep(2000);
        }

        [Then(@"the Specification Funding Period has correctly updated")]
        public void ThenTheSpecificationFundingPeriodHasCorrectlyUpdated()
        {
            IWebElement managePolicyFundingPeriod = managepoliciespage.specificationFundingPeriod;
            managePolicyFundingPeriod.Should().NotBeNull();
            string updatedFundingPeriod = managePolicyFundingPeriod.Text;
            Console.WriteLine("The Funding Period was successfully updated to: " + updatedFundingPeriod);

        }


        [When(@"I delete the existing Specification Funding stream")]
        public void WhenIDeleteTheExistingSpecificationFundingStream()
        {
            editspecificationpage.editSpecificationFundingStreamRemove.Click();
            Thread.Sleep(2000);
        }

        [Then(@"an Alert is displayed warning that no Funding Streams are associated to the specification")]
        public void ThenAnAlertIsDisplayedWarningThatNoFundingStreamsAreAssociatedToTheSpecification()
        {
            IWebElement noFundingStreamAlert = editspecificationpage.editSpecificationFundingStreamRemovedAlert;
            noFundingStreamAlert.Should().NotBeNull();
            string noFundingStreamAlertText = noFundingStreamAlert.Text;
            Console.WriteLine(noFundingStreamAlertText);
        }

        [When(@"I choose (.*) New Funding Streams")]
        public void WhenIChooseNewFundingStreams(string p0)
        {
            SelectElement selectElement = new SelectElement(editspecificationpage.editSpecificationFundingStreamContainer);
            var options = selectElement.Options;

            int? maximumItems = null;
            int parsedInt;
            if (int.TryParse(p0, out parsedInt))
            {
                if (parsedInt > 0)
                {
                    maximumItems = parsedInt;
                }
            }

            for (int i = 0; i < options.Count; i++)
            {
                if (maximumItems != null && maximumItems.HasValue && i >= maximumItems.Value)
                {
                    break;
                }

                IWebElement optionElement = options[i];
                string optionElementText = optionElement.Text;
                Console.WriteLine(optionElementText);

                editspecificationpage.editSpecificationFundingStream.Click();
                editspecificationpage.editSpecFundingStreamTextField.SendKeys(OpenQA.Selenium.Keys.Shift + optionElementText);
                Thread.Sleep(2000);
                editspecificationpage.editSpecificationFundingStream.SendKeys(OpenQA.Selenium.Keys.Enter);


            }

        }


        [When(@"I click the Cancel option")]
        public void WhenIClickTheCancelOption()
        {
            editspecificationpage.editSpecificationCancelLink.Click();
            Thread.Sleep(2000);
        }

        [Given(@"I have created a new policy")]
        public void GivenIHaveCreatedANewPolicy()
        {
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
        }

        [Given(@"I have created a new calculation specification")]
        public void GivenIHaveCreatedANewCalculationSpecification()
        {
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
        }

        [When(@"I click on the calculation specifcation within the Manage Policies Page")]
        public void WhenIClickOnTheCalculationSpecifcationWithinTheManagePoliciesPage()
        {
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();

            IWebElement calcSpecCreated = Driver._driver.FindElement(By.LinkText(specCalcCreated));
            calcSpecCreated.Should().NotBeNull();
            string calcSpecText = calcSpecCreated.Text;
            Console.WriteLine("Calculation Specification Selected to Edit: " + calcSpecText);
            calcSpecCreated.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected successfully to the Edit Calculation Specifcation Page")]
        public void ThenIAmRedirectedSuccessfullyToTheEditCalculationSpecifcationPage()
        {
            editcalculationpage.editCalculationName.Should().NotBeNull();
        }

        [Given(@"I have successfully created a new Calculation Specification")]
        public void GivenIHaveSuccessfullyCreatedANewCalculationSpecification()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();

        }

        [Given(@"I have successfully created a new Calculation Specification with Calculation Type of Number")]
        public void GivenIHaveSuccessfullyCreatedANewCalculationSpecificationWithCalculationTypeOfNumber()
        {
            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewCalculationSpecification_Number.CreateANewSpecificationPolicy_Number();
        }


        [Given(@"I have navigated to the Edit Calculation Page")]
        public void GivenIHaveNavigatedToTheEditCalculationPage()
        {
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();

            IWebElement calcSpecCreated = Driver._driver.FindElement(By.LinkText(specCalcCreated));
            calcSpecCreated.Should().NotBeNull();
            string calcSpecText = calcSpecCreated.Text;
            Console.WriteLine("Calculation Specification Selected to Edit: " + calcSpecText);
            calcSpecCreated.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the option to edit the Calculation Specification Name is displayed")]
        public void ThenTheOptionToEditTheCalculationSpecificationNameIsDisplayed()
        {
            editcalculationpage.editCalculationName.Should().NotBeNull();
        }

        [Then(@"the option to edit the Calculation Specification Description is displayed")]
        public void ThenTheOptionToEditTheCalculationSpecificationDescriptionIsDisplayed()
        {
            editcalculationpage.editCalculationDescription.Should().NotBeNull();
        }

        [Then(@"the option to edit the Calculation Specification Policy or Sub Policy is displayed")]
        public void ThenTheOptionToEditTheCalculationSpecificationPolicyOrSubPolicyIsDisplayed()
        {
            editcalculationpage.editCalculationPolicy.Should().NotBeNull();
        }

        [Then(@"the option to edit the Calculation Specification Calculation Type is displayed")]
        public void ThenTheOptionToEditTheCalculationSpecificationCalculationTypeIsDisplayed()
        {
            editcalculationpage.editCalculationCalculationType.Should().NotBeNull();
        }

        [Then(@"the option to edit the Calculation Specification Allocation Line is displayed")]
        public void ThenTheOptionToEditTheCalculationSpecificationAllocationLineIsDisplayed()
        {
            editcalculationpage.editCalculationAllocationLine.Should().NotBeNull();
        }

        [Then(@"an option to Save the Changes is displayed")]
        public void ThenAnOptionToSaveTheChangesIsDisplayed()
        {
            editcalculationpage.editCalculationSave.Should().NotBeNull();
        }

        [Then(@"an option to cancel the changes is displayed")]
        public void ThenAnOptionToCancelTheChangesIsDisplayed()
        {
            editcalculationpage.editCalculationCancel.Should().NotBeNull();
        }

        [When(@"I update the existing Calculation Specificaton Name")]
        public void WhenIUpdateTheExistingCalculationSpecificatonName()
        {
            string newname = "Test Calculation Name Edit ";
            var editSpecCalcName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecCalcName"] = editSpecCalcName;

            editcalculationpage.editCalculationName.Clear();
            editcalculationpage.editCalculationName.SendKeys(editSpecCalcName);

            editcalculationpage.editCalculationSave.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Calculation Specification Name has been successfully updated")]
        public void ThenTheCalculationSpecificationNameHasBeenSuccessfullyUpdated()
        {
            var newspecCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcEdited = newspecCalcName.ToString();

            IWebElement calcSpecCreated = Driver._driver.FindElement(By.LinkText(specCalcEdited));
            calcSpecCreated.Should().NotBeNull();
            string calcSpecText = calcSpecCreated.Text;
            Console.WriteLine("The Calculation Specification has been successully updated to: " + calcSpecText);

            managepoliciespage.editNotificationPanel.Should().NotBeNull();
            string editnotification = managepoliciespage.editNotificationPanel.Text;
            Console.WriteLine("Notification was displayed correctly to confirm the Edit with the message: " + editnotification);

        }

        [When(@"I update the existing Calculation Specificaton Description")]
        public void WhenIUpdateTheExistingCalculationSpecificatonDescription()
        {
            string descriptiontext = "This is an Edited Description for: ";
            var specCalcName = ScenarioContext.Current["SpecCalcName"];
            string specCalcCreated = specCalcName.ToString();
            string newdescription = descriptiontext + specCalcCreated;
            ScenarioContext.Current["EditSpecCalcDesc"] = newdescription;

            editcalculationpage.editCalculationDescription.Clear();
            editcalculationpage.editCalculationDescription.SendKeys(newdescription);

            editcalculationpage.editCalculationSave.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Calculation Specification Description has been successfully updated")]
        public void ThenTheCalculationSpecificationDescriptionHasBeenSuccessfullyUpdated()
        {
            var newspecCalcDesc = ScenarioContext.Current["EditSpecCalcDesc"];
            string specCalcDescEdited = newspecCalcDesc.ToString();

            IWebElement policyList = managepoliciespage.PolicyList;
            policyList.Should().NotBeNull();

            var containerElements = policyList;
            IWebElement firstSelectEditCalc = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("td"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        if (optionelement.Text.Contains(specCalcDescEdited))
                        {
                            {
                                firstSelectEditCalc = optionelement;

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                if (firstSelectEditCalc != null)
                {
                    string updatedDescription = firstSelectEditCalc.Text;
                    Console.WriteLine("The Specification Calculation Description has been updated to: " + updatedDescription);

                    managepoliciespage.editNotificationPanel.Should().NotBeNull();
                    string editnotification = managepoliciespage.editNotificationPanel.Text;
                    Console.WriteLine("Notification was displayed correctly to confirm the Edit with the message: " + editnotification);
                }
                else
                {
                    firstSelectEditCalc.Should().NotBeNull("Edit Specification Calculation Description has is not displayed correctly");
                }
            }
            else
            {
                firstSelectEditCalc.Should().NotBeNull("Edit Specification Calculation Description has Failed");
            }
        }

        [When(@"I update the existing Calculation Specificaton Allocation Line")]
        public void WhenIUpdateTheExistingCalculationSpecificatonAllocationLine()
        {
            var allocation = editcalculationpage.editCalculationAllocationLine;
            var selectElement01 = new SelectElement(allocation);
            selectElement01.SelectByValue("YPA07");

            editcalculationpage.editCalculationSave.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Calculation Specification has been successfully updated")]
        public void ThenTheCalculationSpecificationHasBeenSuccessfullyUpdated()
        {
            managepoliciespage.editNotificationPanel.Should().NotBeNull();
            string editnotification = managepoliciespage.editNotificationPanel.Text;
            Console.WriteLine("Notification was displayed correctly to confirm the Edit with the message: " + editnotification);
        }

        [When(@"I update the existing Calculation Specificaton Calculation Type")]
        public void WhenIUpdateTheExistingCalculationSpecificatonCalculationType()
        {
            var calctype = editcalculationpage.editCalculationCalculationType;
            var selectElement = new SelectElement(calctype);
            selectElement.SelectByValue("Number");

            editcalculationpage.editCalculationSave.Click();
            Thread.Sleep(2000);
        }

        [When(@"I update the existing Calculation Specificaton Associated Policy")]
        public void WhenIUpdateTheExistingCalculationSpecificatonAssociatedPolicy()
        {
            var addSpecPolicyName = ScenarioContext.Current["AddSpecPolicyName"];
            string addSpecPolicyCreated = addSpecPolicyName.ToString();

            var containerElements = Driver._driver.FindElement(By.Id("EditCalculationViewModel-PolicyId"));
            IWebElement firstSelectPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains(addSpecPolicyCreated))
                        {
                            {
                                firstSelectPolicy = optionelement;
                                break;
                            }
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectPolicy != null)
                {
                    firstSelectPolicy.Click();
                    string selectedPolicy = firstSelectPolicy.Text;
                    Console.WriteLine("New Policy selected to Associate the Calculation to is: " + selectedPolicy);
                    editcalculationpage.editCalculationSave.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        [Then(@"the Calculation Specification associated policy has been successfully updated")]
        public void ThenTheCalculationSpecificationAssociatedPolicyHasBeenSuccessfullyUpdated()
        {
            managepoliciespage.editNotificationPanel.Should().NotBeNull();
            string editnotification = managepoliciespage.editNotificationPanel.Text;
            Console.WriteLine("Notification was displayed correctly to confirm the Edit with the message: " + editnotification);
        }

        [When(@"I update the existing Calculation Specificaton")]
        public void WhenIUpdateTheExistingCalculationSpecificaton()
        {
            string newname = "Test Calculation Name Edit ";
            var editSpecCalcName = newname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["SpecCalcName"] = editSpecCalcName;

            editcalculationpage.editCalculationName.Clear();
            editcalculationpage.editCalculationName.SendKeys(editSpecCalcName);
        }

        [When(@"select to Cancel the edit")]
        public void WhenSelectToCancelTheEdit()
        {
            editcalculationpage.editCalculationCancel.Click();
            Thread.Sleep(2000);
        }

        [When(@"I choose to filter the list by Funding Stream")]
        public void WhenIChooseToFilterTheListByFundingStream()
        {
            IWebElement totalListCount = managespecficationpage.SpecificationListTotalResultCount;
            string totalCount = totalListCount.Text;
            Console.WriteLine("The unfiltered total count of specifications is: " + totalCount);

            IWebElement filtercontainer = managespecficationpage.SpecificationFundingStreamsFilter;
            IWebElement fundingsteamfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingsteamfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingstreamselected = selectfilteroption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + fundingstreamselected);
            selectfilteroption.Click();
            managespecficationpage.SearchSpecification.Click();
            Thread.Sleep(2000);
        }

        [When(@"I choose to filter the list by Status")]
        public void WhenIChooseToFilterTheListByStatus()
        {
            IWebElement totalListCount = managespecficationpage.SpecificationListTotalResultCount;
            string totalCount = totalListCount.Text;
            Console.WriteLine("The unfiltered total count of specifications is: " + totalCount);

            IWebElement filtercontainer = managespecficationpage.SpecificationStatusFilter;
            IWebElement statusfilter = filtercontainer.FindElement(By.CssSelector("button"));
            statusfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string statusselected = selectfilteroption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + statusselected);
            selectfilteroption.Click();
            managespecficationpage.SearchSpecification.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list of specifications refreshes to display the filtered selection")]
        public void ThenTheListOfSpecificationsRefreshesToDisplayTheFilteredSelection()
        {
            IWebElement totalListCount = managespecficationpage.SpecificationListTotalResultCount;
            string totalCount = totalListCount.Text;
            Console.WriteLine("The filtered total count of specifications now is: " + totalCount);
        }

        [Given(@"I choose to filter the list")]
        public void GivenIChooseToFilterTheList()
        {
            IWebElement filterstatuscontainer = managespecficationpage.SpecificationStatusFilter;
            IWebElement statusfilter = filterstatuscontainer.FindElement(By.CssSelector("button"));
            statusfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectstatusfilteroption = filterstatuscontainer.FindElement(By.CssSelector("label"));
            string statusselected = selectstatusfilteroption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + statusselected);
            selectstatusfilteroption.Click();
            managespecficationpage.SearchSpecification.Click();
            Thread.Sleep(2000);

            IWebElement filterfundingstreamcontainer = managespecficationpage.SpecificationFundingStreamsFilter;
            IWebElement fundingsteamfilter = filterfundingstreamcontainer.FindElement(By.CssSelector("button"));
            fundingsteamfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilterstreamoption = filterfundingstreamcontainer.FindElement(By.CssSelector("label"));
            string fundingstreamselected = selectfilterstreamoption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + fundingstreamselected);
            selectfilterstreamoption.Click();
            managespecficationpage.SearchSpecification.Click();
            Thread.Sleep(2000);

            IWebElement filterfundingperiodcontainer = managespecficationpage.SpecificationFilterContainer;
            IWebElement fundingperiodfilter = filterfundingperiodcontainer.FindElement(By.CssSelector("button"));
            fundingperiodfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filterfundingperiodcontainer.FindElement(By.CssSelector("label"));
            string fundingperiodselected = selectfilteroption.Text;
            Console.WriteLine("Funding Period Filter Option selected = " + fundingperiodselected);
            selectfilteroption.Click();
            managespecficationpage.SearchSpecification.Click();
            Thread.Sleep(2000);

            IWebElement totalListCount = managespecficationpage.SpecificationListTotalResultCount;
            string totalCount = totalListCount.Text;
            Console.WriteLine("The filtered total count of specifications is: " + totalCount);

        }

        [When(@"I choose the Clear Filter option")]
        public void WhenIChooseTheClearFilterOption()
        {
            managespecficationpage.SpecificationClearFilter.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list of specifications refreshes to display all the specifications available")]
        public void ThenTheListOfSpecificationsRefreshesToDisplayAllTheSpecificationsAvailable()
        {
            IWebElement totalListCount = managespecficationpage.SpecificationListTotalResultCount;
            string totalCount = totalListCount.Text;
            Console.WriteLine("The unfiltered total count of specifications is: " + totalCount);
        }

        [Then(@"the list of specifications is displayed")]
        public void ThenTheListOfSpecificationsIsDisplayed()
        {
            managespecficationpage.SpecificationList.Should().NotBeNull();
        }

        [Then(@"the following Headers are correctly displayed")]
        public void ThenTheFollowingHeadersAreCorrectlyDisplayed()
        {
            IWebElement specificationlistContainer = managespecficationpage.SpecificationList;
            var propertyElements = specificationlistContainer.FindElements(By.CssSelector("th"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"the displayed in descending order by Last Edit Date")]
        public void ThenTheDisplayedInDescendingOrderByLastEditDate()
        {
            IWebElement firstResultLastUpdated = managespecficationpage.SpecificationListFirstEditDate;
            string firstResultUpdatedDate = firstResultLastUpdated.Text;
            Console.WriteLine(firstResultUpdatedDate);
            DateTime firstUpdatedDate = DateTime.ParseExact(firstResultUpdatedDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            IWebElement secondResultLastUpdated = managespecficationpage.SpecificationListSecondEditDate;
            string secondResultUpdatedDate = secondResultLastUpdated.Text;
            Console.WriteLine(secondResultUpdatedDate);
            DateTime secondUpdatedDate = DateTime.ParseExact(secondResultUpdatedDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            firstUpdatedDate.Should().BeAfter(secondUpdatedDate, "Dataset List is Ordered Incorrectly");

        }

        [Then(@"the Information in each column is displayed correctly")]
        public void ThenTheInformationInEachColumnIsDisplayedCorrectly()
        {
            IWebElement specificationlistContainer = managespecficationpage.SpecificationList;
            //IWebElement specificationDetails = specificationlistContainer.FindElement(By.CssSelector("tr"));
            var propertyElements = specificationlistContainer.FindElements(By.CssSelector("td"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                //currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [When(@"I click on the More Option in for a specific Specification")]
        public void WhenIClickOnTheMoreOptionInForASpecificSpecification()
        {
            managespecficationpage.SpecificationListMoreOption.Click();
            Thread.Sleep(1000);
        }

        [Then(@"the description of that specification is displayed")]
        public void ThenTheDescriptionOfThatSpecificationIsDisplayed()
        {
            IWebElement specificationMoreContainer = managespecficationpage.SpecificationListExpandContainer;
            //IWebElement specificationDetails = specificationlistContainer.FindElement(By.CssSelector("tr"));
            var propertyElements = specificationMoreContainer.FindElements(By.CssSelector("div"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }

        }

        [Then(@"the funding stream associated with the specification is displayed")]
        public void ThenTheFundingStreamAssociatedWithTheSpecificationIsDisplayed()
        {
            //Information is written to the Console Output as part of step definition "the description of that specification is displayed"
        }

        [Then(@"the funding period associated with the specification is displayed")]
        public void ThenTheFundingPeriodAssociatedWithTheSpecificationIsDisplayed()
        {
            //Information is written to the Console Output as part of step definition "the description of that specification is displayed"
        }

        [Then(@"there is an option to edit the specification displayed")]
        public void ThenThereIsAnOptionToEditTheSpecificationDisplayed()
        {
            //Information is written to the Console Output as part of step definition "the description of that specification is displayed"
        }

        [Then(@"the list of associated Polcies and Calculations are displayed")]
        public void ThenTheListOfAssociatedPolciesAndCalculationsAreDisplayed()
        {
            managepoliciespage.PolicyList.Should().NotBeNull();
        }

        [Then(@"the following Specification related Headers are correctly displayed")]
        public void ThenTheFollowingSpecificationRelatedHeadersAreCorrectlyDisplayed()
        {
            IWebElement specificationheaderlist = Driver._driver.FindElement(By.CssSelector("thead.table-primary-border"));
            string headers = specificationheaderlist.Text;
            Console.WriteLine("The Manage Policy List Headers Displayed are: " + headers);
        }

        [Then(@"the associated policies are displayed as rows in my table")]
        public void ThenTheAssociatedPoliciesAreDisplayedAsRowsInMyTable()
        {
            IWebElement policycontainer = managepoliciespage.PolicyList;
            var propertyElements = policycontainer.FindElements(By.CssSelector("tr.data-policy-container"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }

        }

        [Then(@"the name of the policy is displayed")]
        public void ThenTheNameOfThePolicyIsDisplayed()
        {

        }

        [Then(@"the description of the policy is displayed")]
        public void ThenTheDescriptionOfThePolicyIsDisplayed()
        {

        }

        [Then(@"the last edited date time for the policy is displayed")]
        public void ThenTheLastEditedDateTimeForThePolicyIsDisplayed()
        {

        }

        [Then(@"there is the ability to view more information about the policy")]
        public void ThenThereIsTheAbilityToViewMoreInformationAboutThePolicy()
        {

        }

        [Then(@"the associated calculations are displayed as rows in my table")]
        public void ThenTheAssociatedCalculationsAreDisplayedAsRowsInMyTable()
        {
            IWebElement policycontainer = managepoliciespage.PolicyList;
            var propertyElements = policycontainer.FindElements(By.CssSelector("tr.cr-table-primary-highlight:nth-child(3)"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                //currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"I am able to see the name of the calculation specifications")]
        public void ThenIAmAbleToSeeTheNameOfTheCalculationSpecifications()
        {

        }

        [Then(@"the description of the calculation specification is displayed")]
        public void ThenTheDescriptionOfTheCalculationSpecificationIsDisplayed()
        {

        }

        [Then(@"I am able to select to view more details about the calculations specification")]
        public void ThenIAmAbleToSelectToViewMoreDetailsAboutTheCalculationsSpecification()
        {

        }

        [Then(@"the type of the calculation specification is displayed")]
        public void ThenTheTypeOfTheCalculationSpecificationIsDisplayed()
        {

        }

        [Given(@"the list of associated Polcies and Calculations are displayed")]
        public void GivenTheListOfAssociatedPolciesAndCalculationsAreDisplayed()
        {
            managepoliciespage.PolicyList.Should().NotBeNull();
        }

        [Given(@"the associated policies are displayed as rows in my table")]
        public void GivenTheAssociatedPoliciesAreDisplayedAsRowsInMyTable()
        {
            IWebElement policycontainer = managepoliciespage.PolicyList;
            var propertyElements = policycontainer.FindElements(By.CssSelector("tr.data-policy-container"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [When(@"I click on the More drop down option")]
        public void WhenIClickOnTheMoreDropDownOption()
        {
            managepoliciespage.firstMoreOption.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I can view the full policy description")]
        public void ThenICanViewTheFullPolicyDescription()
        {
            IWebElement fullDescription = managepoliciespage.firstFullDescription;
            string fullDescriptionText = fullDescription.Text;

            Console.WriteLine("The Full Epxpanded Description is: " + fullDescriptionText);

        }

        [Given(@"the associated calculations are displayed as rows in my table")]
        public void GivenTheAssociatedCalculationsAreDisplayedAsRowsInMyTable()
        {
            IWebElement policycontainer = managepoliciespage.PolicyList;
            var propertyElements = policycontainer.FindElements(By.CssSelector("tr.cr-table-primary-highlight:nth-child(3)"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);
                //currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [When(@"I click on the Calculation More drop down option")]
        public void WhenIClickOnTheCalculationMoreDropDownOption()
        {
            managepoliciespage.firstCalcMoreOption.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I can view the full Calculation description")]
        public void ThenICanViewTheFullCalculationDescription()
        {
            IWebElement fullCalcDescription = managepoliciespage.firstCalcFullDescription;
            string fullCalcDescText = fullCalcDescription.Text;
            Console.WriteLine("The Full Epxpanded Description is: " + fullCalcDescText);
        }

        [When(@"I click on the Jump To Drop down")]
        public void WhenIClickOnTheJumpToDropDown()
        {
            managepoliciespage.policyjump.Should().NotBeNull();
            managepoliciespage.policyjump.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am able to select from all the available policies")]
        public void ThenIAmAbleToSelectFromAllTheAvailablePolicies()
        {
            var addSpecPolicyName = ScenarioContext.Current["AddSpecPolicyName"];
            string addSpecPolicyCreated = addSpecPolicyName.ToString();

            var selectYear = managepoliciespage.policyjump;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByText(addSpecPolicyCreated);
            Thread.Sleep(2000);

        }

        [Then(@"jump to the displayed information for the selected policy")]
        public void ThenJumpToTheDisplayedInformationForTheSelectedPolicy()
        {
            IWebElement JumpedTo = managepoliciespage.policyjump;
            string selectedJumpto = JumpedTo.Text;

            Console.WriteLine("Policy selected to Jump To was: " + selectedJumpto);
        }

        [When(@"I click the Expand All Link")]
        public void WhenIClickTheExpandAllLink()
        {
            managepoliciespage.expandCollapseAll.Click();
        }

        [Then(@"All rows in the Policy List are expanded to display all additional information")]
        public void ThenAllRowsInThePolicyListAreExpandedToDisplayAllAdditionalInformation()
        {
            IWebElement dataAction = managepoliciespage.expandCollapseAll;
            string dataActionText = dataAction.Text;
            dataActionText.Should().Be("Collapse all", "Expand All within the policy List has not been actioned");
            Console.WriteLine("Option has updated correctly to " + dataActionText);
        }

        [Then(@"All rows in the Policy List are collapsed again")]
        public void ThenAllRowsInThePolicyListAreCollapsedAgain()
        {
            IWebElement dataAction = managepoliciespage.expandCollapseAll;
            string dataActionText = dataAction.Text;
            dataActionText.Should().Be("Expand all", "Collapse All within the policy List has not been actioned");
            Console.WriteLine("Option has updated correctly to " + dataActionText);
        }

        [Then(@"the Approve Specification option is correctly displayed")]
        public void ThenTheApproveSpecificationOptionIsCorrectlyDisplayed()
        {
            IWebElement approveButton = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1) > span:nth-child(1)"));
            approveButton.Should().NotBeNull();
            string approveStatus = approveButton.Text;
            approveStatus.Should().Be("Draft", "The Status of the Specification is not Draft");
            Console.WriteLine("The current Status of the selected Specification is: " + approveStatus);
        }


        [When(@"I choose to mark the associated Specification as Approved")]
        public void WhenIChooseToMarkTheAssociatedSpecificationAsApproved()
        {
            managepoliciespage.approveDropDown.Click();
            IWebElement publishoptions = managepoliciespage.publishMenu;
            publishoptions.Should().NotBeNull();

            Driver._driver.FindElement(By.CssSelector(".dropdown-menu")).Click();
            Thread.Sleep(2000);
            

        }

        [Then(@"the Specification should be marked as approved")]
        public void ThenTheSpecificationShouldBeMarkedAsApproved()
        {
            IWebElement approveButton = Driver._driver.FindElement(By.CssSelector("button.btn:nth-child(1)"));
            approveButton.Should().NotBeNull();
            string approveStatus = approveButton.Text;
            approveStatus.Should().Be("Approved", "The Status of the Specification is not Draft");
            Console.WriteLine("The New Status of the selected Specification is: " + approveStatus);
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


