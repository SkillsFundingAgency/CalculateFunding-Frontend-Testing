using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Helpers;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Frontend.IntegrationTests.Pages.Quality_Assurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class QualityAssuranceTestsSteps
    {
        TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
        CreateQATestPage createqatestpage = new CreateQATestPage();
        EditQATestPage editqatestpage = new EditQATestPage();

        public string qatestname = "QA Test RW ";
        public string qatestdescription = "This is a QA Test Description";
        public string testgherkingiven = "Given the field 'UPIN' in the dataset 'AB Test Dataset 2403-01-001' is equal to 12";
        public string testgherkinand = "And the provider is '105154'";
        public string testgherkinthen = "Then the result for 'AB High Needs Calc 002' is greater than the field 'UPIN' in the dataset 'AB Test Dataset 2403-01-001'";


        [Then(@"a Search Tests funciton is displayed")]
        public void ThenASearchTestsFuncitonIsDisplayed()
        {
            testscenariolistpage.testScenarioPageSearchField.Displayed.Should().BeTrue();
            testscenariolistpage.testScenarioPageSearchButton.Should().NotBeNull();
            testscenariolistpage.testScenarioPageSearchButton.Displayed.Should().BeTrue();

        }
        
        [Then(@"an option to create a new QA Test is displayed")]
        public void ThenAnOptionToCreateANewQATestIsDisplayed()
        {
            testscenariolistpage.testScenarioPageCreateQATestButton.Should().NotBeNull();
            testscenariolistpage.testScenarioPageCreateQATestButton.Displayed.Should().BeTrue();
        }

        [Then(@"the list shows up to (.*) Test Scenarios")]
        public void ThenTheListShowsUpToTestScenarios(int totalpagecount)
        {
            IWebElement testscenarioLastResultCount = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenarioLastResult = testscenarioLastResultCount.Text;
            int totalpagescenariocount = int.Parse(testscenarioLastResult);
            totalpagescenariocount.Should().BeLessOrEqualTo(totalpagecount, "More than 50 Scenarios are displayed");
            Console.WriteLine("Test Scenario Page List Count is " + totalpagescenariocount);
        }

        [Then(@"the total Test Scenario Count is displayed")]
        public void ThenTheTotalTestScenarioCountIsDisplayed()
        {
            IWebElement testscenariototalresult = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenariototal = testscenariototalresult.Text;
            int totalscenariocount = int.Parse(testscenariototal);
            Console.WriteLine("Total Test Scenario Results is " + totalscenariocount);
        }


        [When(@"I have over (.*) Test Scenarios listed")]
        public void WhenIHaveOverTestScenariosListed(int totalItemCount)
        {
            IWebElement testscenarioLastResultCount = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenarioLastResult = testscenarioLastResultCount.Text;
            int totalPageCount = int.Parse(testscenarioLastResult);

            if (totalPageCount < totalItemCount)
            {
                Assert.Inconclusive("Only 1 page of results is displayed as the Total results returned is less than " + totalItemCount);

            }
            else
            {
                Console.WriteLine("The Total results returned is " + totalPageCount);
            }

        }

        [When(@"I click to navigate to the next page of (.*) test scenarios")]
        public void WhenIClickToNavigateToTheNextPageOfTestScenarios(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my test scenarios list view displays the next (.*) results")]
        public void ThenMyTestScenariosListViewDisplaysTheNextResults(int firstpagecount)
        {
            IWebElement testscenarioFirstResultCount = testscenariolistpage.testScenarioPageFirstResultCount;
            string testscenarioFirstResult = testscenarioFirstResultCount.Text;
            int firstpagescenariocount = int.Parse(testscenarioFirstResult);
            firstpagescenariocount.Should().BeGreaterThan(firstpagecount, "The Next list of Test Scenarios have not been are displayed correctly");
        }

        [Then(@"I am able to navigate to the previous page of (.*) test scenarios")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfTestScenarios(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }


        [Then(@"the name of test scenario is displayed")]
        public void ThenTheNameOfTestScenarioIsDisplayed()
        {
            IWebElement testscenarioname = testscenariolistpage.testScenarioPageFirstTestScenarioName;
            string scenarioname = testscenarioname.Text;
            scenarioname.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Name displayed is " + scenarioname);
        }

        [Then(@"the description of the test scenario is displayed")]
        public void ThenTheDescriptionOfTheTestScenarioIsDisplayed()
        {
            IWebElement testscenariodescription = testscenariolistpage.testScenarioPageFirstTestScenarioDescription;
            string scenariodescription = testscenariodescription.Text;
            Console.WriteLine("First Test Scenario Description displayed is " + scenariodescription);
        }


        [Then(@"the specification that the test is associated with is displayed")]
        public void ThenTheSpecificationThatTheTestIsAssociatedWithIsDisplayed()
        {
            IWebElement testscenariospec = testscenariolistpage.testScenarioPageFirstTestScenarioSpecification;
            string scenariospec = testscenariospec.Text;
            scenariospec.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Status displayed is " + scenariospec);
        }

        [Then(@"the date time the test scenario was last updated is displayed")]
        public void ThenTheDateTimeTheTestScenarioWasLastUpdatedIsDisplayed()
        {
            IWebElement testscenariolastupdated = testscenariolistpage.testScenarioPageFirstTestScenarioLastUpdated;
            string scenariolastupdated = testscenariolastupdated.Text;
            scenariolastupdated.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Updated Date is " + scenariolastupdated);
        }

        [Given(@"I have successfully navigated to the Quality Assurance Test Scenario List Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheQualityAssuranceTestScenarioListPage()
        {
            NavigateTo.TestScenarioListPage();
            testscenariolistpage.testScenarioPageCreateQATestButton.Should().NotBeNull();
            testscenariolistpage.testScenarioPageCreateQATestButton.Displayed.Should().BeTrue();
        }

        [When(@"I click the Create QA Test Button")]
        public void WhenIClickTheCreateQATestButton()
        {
            testscenariolistpage.testScenarioPageCreateQATestButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Create quality assurance test page")]
        public void ThenIAmRedirectedToTheCreateQualityAssuranceTestPage()
        {
            createqatestpage.createQATestName.Should().NotBeNull();
        }


        [Given(@"I have successfully navigated to the Create quality assurance test page")]
        public void GivenIHaveSuccessfullyNavigatedToTheCreateQualityAssuranceTestPage()
        {
            NavigateTo.CreateQATestPage();
            Thread.Sleep(2000);
        }

        [Then(@"there is a field displayed where I can name my test scenario")]
        public void ThenThereIsAFieldDisplayedWhereICanNameMyTestScenario()
        {
            createqatestpage.createQATestName.Should().NotBeNull();
        }

        [Then(@"there is a field displayed where I can describe my test scenario")]
        public void ThenThereIsAFieldDisplayedWhereICanDescribeMyTestScenario()
        {
            createqatestpage.createQATestDescription.Should().NotBeNull();
        }

        [Then(@"there is an option to select the specification my test is linked to")]
        public void ThenThereIsAnOptionToSelectTheSpecificationMyTestIsLinkedTo()
        {
            createqatestpage.createQATestSelectSpecification.Should().NotBeNull();
        }

        [Then(@"there is a monaco text editor field displayed")]
        public void ThenThereIsAMonacoTextEditorFieldDisplayed()
        {
            createqatestpage.createQATestScenario.Should().NotBeNull();
        }

        [When(@"I have choosen a specification from the drop down to link my test to")]
        public void WhenIHaveChoosenASpecificationFromTheDropDownToLinkMyTestTo()
        {
            Actions.SelectSpecificationCreateQATestPage();
        }

        [When(@"I have entered a Test Name for my QA Test")]
        public void WhenIHaveEnteredATestNameForMyQATest()
        {
            var randomQATestName = qatestname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["QATestName"] = randomQATestName;
            createqatestpage.createQATestName.Click();
            createqatestpage.createQATestName.SendKeys(randomQATestName);
        }

        [When(@"I have entered a description for my QA Test")]
        public void WhenIHaveEnteredADescriptionForMyQATest()
        {
            createqatestpage.createQATestDescription.Click();
            createqatestpage.createQATestDescription.SendKeys(qatestdescription);
            Thread.Sleep(2000);
        }

        [When(@"I have entered a text in the Test Scenario editor for my QA Test")]
        public void WhenIHaveEnteredATextInTheTestScenarioEditorForMyQATest()
        {
            createqatestpage.createQATestBuildMonacoEditorTextbox.Should().NotBeNull();
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("This is Test Code");
            Thread.Sleep(4000);
        }

        [Then(@"the Valiadate QA Test Button should be Enabled")]
        public void ThenTheValiadateQATestButtonShouldBeEnabled()
        {
            createqatestpage.createQATestValidateQATestButton.Should().NotBeNull();
            createqatestpage.createQATestValidateQATestButton.Enabled.Should().BeTrue();

        }

        [When(@"I click the Validate QA Test Button")]
        public void WhenIClickTheValidateQATestButton()
        {
            createqatestpage.createQATestValidateQATestButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am notified that the code being verified is in progress")]
        public void ThenIAmNotifiedThatTheCodeBeingVerifiedIsInProgress()
        {
            IWebElement validatingtext = createqatestpage.createQATestBuildBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            Console.WriteLine("The Build Output validating in progress message shows is " + validatingtextmessage);
        }

        [Then(@"I am notified that the code being verified is complete")]
        public void ThenIAmNotifiedThatTheCodeBeingVerifiedIsComplete()
        {
            Thread.Sleep(5000);
            IWebElement validatingtext = createqatestpage.createQATestBuildBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            Console.WriteLine("The Build Output validation completed message shows is " + validatingtextmessage);
        }

        [Given(@"I have completed the required QA Test Scenario fields")]
        public void GivenIHaveCompletedTheRequiredQATestScenarioFields()
        {
            Actions.SelectSpecificationCreateQATestPage();
            createqatestpage.createQATestName.Click();
            createqatestpage.createQATestName.SendKeys(qatestname + TestDataUtils.RandomString(6));
            createqatestpage.createQATestDescription.Click();
            createqatestpage.createQATestDescription.SendKeys(qatestdescription);
            Thread.Sleep(2000);

        }

        [When(@"I enter incorrect text in to the Test Scenario editor")]
        public void WhenIEnterIncorrectTextInToTheTestScenarioEditor()
        {
            createqatestpage.createQATestBuildMonacoEditorTextbox.Should().NotBeNull();
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("This is Incorrect Test Code");
            Thread.Sleep(2000);
        }

        [Then(@"I am notified that the Test has not validated successfully")]
        public void ThenIAmNotifiedThatTheTestHasNotValidatedSuccessfully()
        {
            Thread.Sleep(10000);
            IWebElement validatingtext = createqatestpage.createQATestBuildBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            validatingtextmessage.Should().NotBeNullOrWhiteSpace();
            validatingtextmessage.Should().Contain("Test validated successfully: false");

        }

        [Then(@"an appropriate error message is displayed")]
        public void ThenAnAppropriateErrorMessageIsDisplayed()
        {
            IWebElement validatingtext = createqatestpage.createQATestBuildBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            Console.WriteLine("The Build Output failed validation message is " + validatingtextmessage);
        }

        [Then(@"the save option remains disabled")]
        public void ThenTheSaveOptionRemainsDisabled()
        {
            createqatestpage.createQATestCreateQATestButton.Enabled.Should().BeFalse();
        }

        [Then(@"the Validate QA Test Button remains disabled")]
        public void ThenTheValidateQATestButtonRemainsDisabled()
        {
            createqatestpage.createQATestValidateQATestButton.Should().NotBeNull();
            createqatestpage.createQATestValidateQATestButton.Enabled.Should().BeFalse();
        }


        [When(@"I have choosen a specific specification my code will validate against")]
        public void WhenIHaveChoosenASpecificSpecificationMyCodeWillValidateAgainst()
        {
            Actions.SelectQATestSpecificationDropdownOption();
            createqatestpage.createQATestDescription.Click();
            Thread.Sleep(2000);
        }

        [When(@"I have entered a valid test text in the Test Scenario editor for my QA Test")]
        public void WhenIHaveEnteredAValidTestTextInTheTestScenarioEditorForMyQATest()
        {
            createqatestpage.createQATestBuildMonacoEditorTextbox.Should().NotBeNull();
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(testgherkingiven);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Enter);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(testgherkinand);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Enter);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(testgherkinthen);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(4000);
        }

        [When(@"I have created a Test for the Specified Specification")]
        public void WhenIHaveCreatedATestForTheSpecifiedSpecification()
        {
            ValidateNewQATest.ValidateANewQATest();
        }


        [Then(@"I am notified my test scenario has validated successfully")]
        public void ThenIAmNotifiedMyTestScenarioHasValidatedSuccessfully()
        {
            //Thread.Sleep(5000);
            string validatedmessagetext = "Test validated successfully: true";
            WebDriverWait wait = new WebDriverWait(Driver._driver, TimeSpan.FromSeconds(60));
            wait.Until(d => createqatestpage.createQATestBuildBuildOutputText.Text.Contains(validatedmessagetext));

            IWebElement validatingtext = createqatestpage.createQATestBuildBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            validatingtextmessage.Should().NotBeNullOrWhiteSpace();
            validatingtextmessage.Should().Contain(validatedmessagetext);
            Console.WriteLine("The Build Output Sucess validation message is " + validatingtextmessage);
        }

        [When(@"I click the Enabled Save Button")]
        public void WhenIClickTheEnabledSaveButton()
        {
            createqatestpage.createQATestCreateQATestButton.Click();
            Thread.Sleep(2000);
        }

        [When(@"I have created a Test for the Specified Specification missing a Name and Description")]
        public void WhenIHaveCreatedATestForTheSpecifiedSpecificationMissingANameAndDescription()
        {
            ValidateQATestMissingFields.ValidateANewQATestMissingFields();
        }


        [Then(@"an error message is displayed to to notify that a Test Name has not been entered")]
        public void ThenAnErrorMessageIsDisplayedToToNotifyThatATestNameHasNotBeenEntered()
        {
            IWebElement missingnameerror = createqatestpage.createQATestMissingNameError;
            missingnameerror.Displayed.Should().BeTrue();
            string missingnametext = missingnameerror.Text;
            Console.WriteLine("Missing Name Error displayed is " + missingnametext);
            
        }

        [Then(@"an error message is displayed to to notify that a Test Description has not been entered")]
        public void ThenAnErrorMessageIsDisplayedToToNotifyThatATestDescriptionHasNotBeenEntered()
        {
            IWebElement missingdescriptionerror = createqatestpage.createQATestMissingDescriptionError;
            missingdescriptionerror.Displayed.Should().BeTrue();
            string missingdescriptiontext = missingdescriptionerror.Text;
            Console.WriteLine("Missing Description Error displayed is " + missingdescriptiontext);
        }

        [When(@"I choose to select an Existing QA Test from the list displayed")]
        public void WhenIChooseToSelectAnExistingQATestFromTheListDisplayed()
        {
            IWebElement testscenarioname = testscenariolistpage.testScenarioPageFirstTestScenarioName;
            string scenarioname = testscenarioname.Text;
            scenarioname.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Name selected to edit is " + scenarioname);

            testscenarioname.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Edit quality assurance test page")]
        public void ThenIAmRedirectedToTheEditQualityAssuranceTestPage()
        {
            editqatestpage.editQATestName.Should().NotBeNull();
        }

        [Then(@"the associated Specification name is displayed")]
        public void ThenTheAssociatedSpecificationNameIsDisplayed()
        {
            IWebElement editQATestAssocSpec = editqatestpage.editQATestAssocSpecification;
            editQATestAssocSpec.Should().NotBeNull();
            string editQATestSpecText = editQATestAssocSpec.Text;
            Console.WriteLine("The Specification Associated to this QA Test is: " + editQATestSpecText);
        }

        [Then(@"the Edit QA Test Name field is displayed")]
        public void ThenTheEditQATestNameFieldIsDisplayed()
        {
            editqatestpage.editQATestName.Should().NotBeNull();
        }

        [Then(@"the Edit Description field is displayed")]
        public void ThenTheEditDescriptionFieldIsDisplayed()
        {
            editqatestpage.editQATestDescription.Should().NotBeNull();
        }

        [Then(@"the existing QA Test code is displayed in the Monaco Text Editor")]
        public void ThenTheExistingQATestCodeIsDisplayedInTheMonacoTextEditor()
        {
            editqatestpage.editQATestMonacoEditorConatiner.Should().NotBeNull();
        }


        [Given(@"I have successfully navigated to the Edit quality assurance test page")]
        public void GivenIHaveSuccessfullyNavigatedToTheEditQualityAssuranceTestPage()
        {
            NavigateTo.EditQATestPage();
            Thread.Sleep(4000);
        }

        [When(@"I update the existing Test Name")]
        public void WhenIUpdateTheExistingTestName()
        {
            string editedname = "QA Test Name ";

            var randomQAEditName = editedname + TestDataUtils.RandomString(6);
            ScenarioContext.Current["QAEditedName"] = randomQAEditName;

            IWebElement testName = editqatestpage.editQATestName;
            testName.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            testName.SendKeys(randomQAEditName + " Edited");
            Thread.Sleep(2000);
        }

        [When(@"select to Save the change")]
        public void WhenSelectToSaveTheChange()
        {
            editqatestpage.editQATestSaveButton.Click();
            Thread.Sleep(4000);
        }

        [Then(@"the Test Name is updated")]
        public void ThenTheTestNameIsUpdated()
        {
            var newTestName = ScenarioContext.Current["QAEditedName"];
            string newTestNameText = newTestName.ToString();
            Console.WriteLine("Updated Test Name for this QA Test is: " + newTestNameText);
            Thread.Sleep(4000);
        }

        [Then(@"I am presented with confirmation of the change")]
        public void ThenIAmPresentedWithConfirmationOfTheChange()
        {
            IWebElement savedAlert = editqatestpage.editQATestSavedAlert;
            savedAlert.Should().NotBeNull();
            var savedMessage = savedAlert.FindElement(By.CssSelector("p"));
            string saveMessageText = savedMessage.Text;
            Console.WriteLine("Confirmation Message displayed: " + saveMessageText);
        }

        [When(@"I update the existing Test Description")]
        public void WhenIUpdateTheExistingTestDescription()
        {
            string editeddesc = "This is an Updated Test Description ";

            var randomQAEditDesc = editeddesc + TestDataUtils.RandomString(6);
            ScenarioContext.Current["QAEditedDesc"] = randomQAEditDesc;

            IWebElement testName = editqatestpage.editQATestDescription;
            testName.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            testName.SendKeys(randomQAEditDesc + " Edited");
            Thread.Sleep(2000);
        }

        [Then(@"the Test Description is updated")]
        public void ThenTheTestDescriptionIsUpdated()
        {
            var newTestDesc = ScenarioContext.Current["QAEditedDesc"];
            string newTestDescText = newTestDesc.ToString();
            Console.WriteLine("Updated Test Name for this QA Test is: " + newTestDescText);
        }

        [When(@"I Update the existing Test")]
        public void WhenIUpdateTheExistingTest()
        {
            var randomnumerics = TestDataNumericUtils.RandomNumerics(2);
            string testUpdate = randomnumerics + "'";

            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            Thread.Sleep(1000);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.End);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Backspace);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Backspace);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Backspace);
            Thread.Sleep(1000);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(testUpdate);
        }

        [When(@"I Validate the Test")]
        public void WhenIValidateTheTest()
        {
            editqatestpage.editQATestValidateButton.Click();
            Thread.Sleep(4000);

            string validatedmessagetext = "Test validated successfully: true";
            WebDriverWait wait = new WebDriverWait(Driver._driver, TimeSpan.FromSeconds(60));
            wait.Until(d => editqatestpage.editQATestBuildOutputText.Text.Contains(validatedmessagetext));

            IWebElement validatingtext = editqatestpage.editQATestBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            validatingtextmessage.Should().NotBeNullOrWhiteSpace();
            validatingtextmessage.Should().Contain(validatedmessagetext);
            Console.WriteLine("The Build Output Sucess validation message is " + validatingtextmessage);

        }

        [When(@"I Update the existing Test Incorrectly")]
        public void WhenIUpdateTheExistingTestIncorrectly()
        {
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            Thread.Sleep(1000);
            createqatestpage.createQATestBuildMonacoEditorTextbox.SendKeys("This is Not Valid Gherkin Test Script");


        }

        [When(@"I Validate the Incorrect Test")]
        public void WhenIValidateTheIncorrectTest()
        {
            editqatestpage.editQATestValidateButton.Click();
            Thread.Sleep(4000);

        }

        [Then(@"I am presented with a failed validation message")]
        public void ThenIAmPresentedWithAFailedValidationMessage()
        {
            string invalidatedmessagetext = "Test validated successfully: false";
            WebDriverWait wait = new WebDriverWait(Driver._driver, TimeSpan.FromSeconds(60));
            wait.Until(d => editqatestpage.editQATestBuildOutputText.Text.Contains(invalidatedmessagetext));
            IWebElement validatingtext = editqatestpage.editQATestBuildOutputText;
            string validatingtextmessage = validatingtext.Text;
            validatingtextmessage.Should().NotBeNullOrWhiteSpace();
            validatingtextmessage.Should().Contain(invalidatedmessagetext);
            Console.WriteLine("The Build Output Sucess validation message is " + invalidatedmessagetext);
        }


        [When(@"I Incorrectly update the existing Test Name")]
        public void WhenIIncorrectlyUpdateTheExistingTestName()
        {
            editqatestpage.editQATestName.Clear();
        }

        [Then(@"An Enter a unique name Error is displayed")]
        public void ThenAnEnterAUniqueNameErrorIsDisplayed()
        {
            IWebElement errorName = editqatestpage.editQATestNameError;
            errorName.Should().NotBeNull();
            string errorNameText = errorName.Text;
            Console.WriteLine("Error Message Displayed: " + errorNameText);

        }

        [When(@"I Incorrectly update the existing Test Description")]
        public void WhenIIncorrectlyUpdateTheExistingTestDescription()
        {
            editqatestpage.editQATestDescription.Clear();
        }

        [Then(@"An Enter a description Error is displayed")]
        public void ThenAnEnterADescriptionErrorIsDisplayed()
        {
            IWebElement errorDesc = editqatestpage.editQATestDescriptionError;
            errorDesc.Should().NotBeNull();
            string errorDescText = errorDesc.Text;
            Console.WriteLine("Error Message Displayed: " + errorDescText);
        }

        [When(@"I click on the Back link")]
        public void WhenIClickOnTheBackLink()
        {
            editqatestpage.editQATestBackLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected back to the Quality Assurance Test Scenario List Page")]
        public void ThenIAmRedirectedBackToTheQualityAssuranceTestScenarioListPage()
        {
            testscenariolistpage.testScenarioPageCreateQATestButton.Should().NotBeNull();
        }

        [When(@"I have specified a data Source Relationship for the Specification")]
        public void WhenIHaveSpecifiedADataSourceRelationshipForTheSpecification()
        {
            CreateDataSourceMapping.CreateADataSourceMapping();
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
