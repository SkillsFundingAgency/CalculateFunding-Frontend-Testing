using System;
using System.Threading;
using AutoFramework;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

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
        public string nametext = "Test Spec03";
        public string newname = "Test Name 004";
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
            var selectYear = Driver._driver.FindElement(By.Id("select-spec-year"));
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue("1718");
            Thread.Sleep(2000);
        }

        [Then(@"the list of specifications refreshes to display the selected years specifications")]
        public void ThenTheListOfSpecificationsRefreshesToDisplayTheSelectedYearsSpecifications()
        {
            Assert.IsNotNull(managespecficationpage.SpecificationList);
            ((ITakesScreenshot)Driver._driver).GetScreenshot().SaveAsFile(@"C:\Users\Richard\Documents\Work\ESFA Allocations\ESFA Selenium Screenshots\Manage Spec Screenshot.jpg", ScreenshotImageFormat.Jpeg);
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
            var selectYear = Driver._driver.FindElement(By.Id("select-spec-year"));
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
            createspecificationpage.SpecName.SendKeys(newname);
        }

        [When(@"I enter a Description")]
        public void WhenIEnterADescription()
        {
            createspecificationpage.SpecDescription.SendKeys(descriptiontext);
        }

        [When(@"I choose a specification Funding Stream")]
        public void WhenIChooseASpecificationFundingStream()
        {
            var Funding = Driver._driver.FindElement(By.Id("CreateSpecificationViewModel-FundingStreamId"));
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
            Driver._driver.FindElement(By.LinkText(newname));
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
            createspecificationpage.SpecName.SendKeys(nametext);
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
            var Funding = Driver._driver.FindElement(By.Id("CreateSpecificationViewModel-FundingStreamId"));
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
            Driver._driver.FindElement(By.LinkText(nametext)).Click();
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
            createpolicypage.PolicyName.SendKeys(newname);
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
            Driver._driver.FindElement(By.LinkText(newname));
            Thread.Sleep(1000);
        }

        [When(@"I click the Cancel Policy Button")]
        public void WhenIClickTheCancelPolicyButton()
        {
            Thread.Sleep(2000);
            createpolicypage.CancelPolicy.Click();
            Thread.Sleep(1000);
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
            createcalculationpage.CalculationName.SendKeys(newname);
        }

        [When(@"I choose a Policy or sub policy")]
        public void WhenIChooseAPolicyOrSubPolicy()
        {
            var policydropdown = Driver._driver.FindElement(By.Id("CreateCalculationViewModel-PolicyId"));
            var selectElement = new SelectElement(policydropdown);
            selectElement.SelectByText(nametext);
        }

        [When(@"I choose an Allocation Line")]
        public void WhenIChooseAnAllocationLine()
        {
            var allocation = Driver._driver.FindElement(By.Id("CreateCalculationViewModel-AllocationLineId"));
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
            Thread.Sleep(2000);
        }

        [When(@"I click the Cancel Calculation button")]
        public void WhenIClickTheCancelCalculationButton()
        {
            createcalculationpage.CancelCalculation.Click();
            Thread.Sleep(2000);
        }

        [Then(@"A Unique Calculation Name Error is Displayed")]
        public void ThenAUniqueCalculationNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createcalculationpage.CalculationNameError.Text);
            Thread.Sleep(2000);
        }


        [Given(@"I have missed the calculation field (.*) and (.*) and (.*) and (.*)")]
        public void GivenIHaveMissedTheCalculationField(string name, string policy, string allocation, string description)
        {
            createcalculationpage.CalculationName.SendKeys(name);

            var policydropdown = Driver._driver.FindElement(By.Id("CreateCalculationViewModel-PolicyId"));
            var selectElement = new SelectElement(policydropdown);
            selectElement.SelectByText(policy);

            var allocationdropdown = Driver._driver.FindElement(By.Id("CreateCalculationViewModel-AllocationLineId"));
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
            createsubpolicypage.SubPolicyName.SendKeys(newname);
        }

        [When(@"I choose a Policy from the dropdown")]
        public void WhenIChooseAPolicyFromTheDropdown()
        {
            var policydropdown = Driver._driver.FindElement(By.Id("CreateSubPolicyViewModel-ParentPolicyId"));
            var selectElement = new SelectElement(policydropdown);
            selectElement.SelectByText(nametext);
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
            Thread.Sleep(2000);
        }

        [When(@"I click the Cancel Sub Policy button")]
        public void WhenIClickTheCancelSubPolicyButton()
        {
            createsubpolicypage.CancelSubPolicy.Click();
            Thread.Sleep(2000);
        }

        [Then(@"A Unique Sub Policy Name Error is Displayed")]
        public void ThenAUniqueSubPolicyNameErrorIsDisplayed()
        {
            Assert.IsNotNull(createsubpolicypage.SubPolicyMissingNameErrorText.Text);
            Thread.Sleep(2000);
        }


        [Given(@"And I have missed the Sub Policy field (.*) and (.*) and (.*)")]
        public void GivenAndIHaveMissedTheSubPolicyFieldAndTestSpecAndDescription(string name, string policy, string description)
        {
            createsubpolicypage.SubPolicyName.SendKeys(name);
            var policydropdown = Driver._driver.FindElement(By.Id("CreateSubPolicyViewModel-ParentPolicyId"));
            var selectElement = new SelectElement(policydropdown);
            selectElement.SelectByText(policy);
            createsubpolicypage.SubPolicyDescription.SendKeys(description);
            Thread.Sleep(2000);

        }

        [Then(@"the following Sub Policy Error should be displayed for FieldName '(.*)' and '(.*)'")]
        public void ThenTheFollowingSubPolicyErrorShouldBeDisplayedForFieldNameAnd(string SubPolicyFieldname, string subpolicyerror)
        {
            Thread.Sleep(1000);
            if (SubPolicyFieldname == "SubPolicyNameMissing")
                Assert.AreEqual(subpolicyerror, createsubpolicypage.SubPolicyMissingNameErrorText.Text);

            else if (SubPolicyFieldname == "SubPolicyPolicyMissing")
                Assert.AreEqual(subpolicyerror, createsubpolicypage.SubPolicyMissingPolicyErrorText.Text);

            else if (SubPolicyFieldname == "SubPolicyDescriptionMissing")
                Assert.AreEqual(subpolicyerror, createsubpolicypage.SubPolicyMissingDescriptionErrorText.Text);

            else throw new InvalidOperationException("Unknown Field");
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


