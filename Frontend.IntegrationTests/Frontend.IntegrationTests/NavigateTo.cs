﻿using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using OpenQA.Selenium;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using Frontend.IntegrationTests.Pages.View_Results;
using Frontend.IntegrationTests.Pages.Quality_Assurance;
using System;
using TechTalk.SpecFlow;
using Frontend.IntegrationTests.Pages.Home_Page;
using Frontend.IntegrationTests.Pages.Approve_funding;

namespace Frontend.IntegrationTests
{
    public static class NavigateTo
    {
        public static void ManagetheSpecfication()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();

            homepage.ManagetheSpecification.Click();

        }

        public static void ManagetheCalculation()
        {
            HomePage homepage = new HomePage();
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            homepage.ManagetheCalculations.Click();
            Thread.Sleep(6000);

        }

        public static void CreatetheSpecfication()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();
            CreateSpecificationPage createspecificationpage = new CreateSpecificationPage();

            homepage.ManagetheSpecification.Click();
            managepecificationpage.CreateSpecification.Click();

        }

        public static void ManagePolicies()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();

            homepage.ManagetheSpecification.Click();
            managepecificationpage.SelectSpecification.Click();

        }

        public static void CreatePolicy()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();

            homepage.ManagetheSpecification.Click();
            managepecificationpage.SelectSpecification.Click();
            managepoliciespage.CreatePolicyButton.Click();

        }

        public static void CreateCalculation()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            CreateCalculationPage createcalculationpage = new CreateCalculationPage();

            CreateNewPESportSpecification.CreateANewPESportSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            managepoliciespage.CreateCalculation.Click();

        }

        public static void CreateSubPolicy()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            CreateSubPolicyPage createsubpolicypage = new CreateSubPolicyPage();

            homepage.ManagetheSpecification.Click();
            managepecificationpage.SelectSpecification.Click();
            managepoliciespage.CreateSubPolicy.Click();

        }

        public static void ComparePreviousCalculationVersions()
        {
            HomePage homepage = new HomePage();
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();
            EditCalculationsPage editcalculationspage = new EditCalculationsPage();

            homepage.ManagetheCalculations.Click();
            Thread.Sleep(5000);
            managecalculationpage.FirstCalculationListed.Click();
            Thread.Sleep(2000);
            editcalculationspage.PreviousCalculationVersionsLink.Click();


        }

        public static void CalculationComparisonPage()
        {
            HomePage homepage = new HomePage();
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();
            EditCalculationsPage editcalculationspage = new EditCalculationsPage();
            ViewPreviousCalculationsPage viewpreviouscalculationpage = new ViewPreviousCalculationsPage();

            homepage.ManagetheCalculations.Click();
            Thread.Sleep(5000);
            managecalculationpage.FirstCalculationListed.Click();
            Thread.Sleep(2000);
            editcalculationspage.PreviousCalculationVersionsLink.Click();
            Thread.Sleep(2000);
            viewpreviouscalculationpage.CompareFirstCheckBox.Click();
            viewpreviouscalculationpage.CompareSecondCheckBox.Click();
            viewpreviouscalculationpage.ComparePreviousCalculationsButton.Click();

        }

        public static void ManageTheDataPage()
        {
            HomePage homepage = new HomePage();

            homepage.ManagetheData.Click();

        }

        public static void ManageDatasetsPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();

            homepage.ManagetheData.Click();
            managethedatapage.manageDataSetsLink.Click();

        }

        public static void MapDataSourcesToDatasetsPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();

            homepage.ManagetheData.Click();
            managethedatapage.specifyDataSetRelationshipLink.Click();

        }

        public static void CreateDatasetPage()
        {
            HomePage homepage = new HomePage();
            ManageSpecificationPage managepecificationpage = new ManageSpecificationPage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();

            homepage.ManagetheSpecification.Click();
            managepecificationpage.SelectSpecification.Click();
            managepoliciespage.Createdatatyperelationship.Click();

        }

        public static void DownloadDataSchemasPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();

            homepage.ManagetheData.Click();
            managethedatapage.downloadDataSchemasLink.Click();
            Thread.Sleep(2000);

        }

        public static void ViewResultsPage()
        {
            HomePage homepage = new HomePage();
            ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();
            ViewProviderAllocationsPage viewproviderallocationspage = new ViewProviderAllocationsPage();
            ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();

            homepage.ViewtheResults.Click();
            viewresultsoptionspage.viewResultsOptionsViewProviderResults.Click();
            Thread.Sleep(2000);
        }

        public static void ViewProviderAllocationsPage()
        {
            HomePage homepage = new HomePage();
            ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();
            ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();

            homepage.ViewtheResults.Click();
            viewresultsoptionspage.viewResultsOptionsViewProviderResults.Click();
            Thread.Sleep(2000);
            IWebElement providerresultslistcontainer = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement providernamelink = providerresultslistcontainer.FindElement(By.TagName("a"));
            providernamelink.Should().NotBeNull();
            providernamelink.Click();


        }

        public static void SpecificationRelationshipsPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();
            MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();

            homepage.ManagetheData.Click();
            managethedatapage.specifyDataSetRelationshipLink.Click();
            Thread.Sleep(2000);
            mapdatasourcestodatasetspage.mapDataSourcesFirstSpecificationName.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.LinkText("Map data source file")).Click();
            Thread.Sleep(2000);

        }


        public static void SpecificationDataNoRelationshipsPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();
            MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();

            homepage.ManagetheData.Click();
            managethedatapage.specifyDataSetRelationshipLink.Click();
            var containerElements = Driver._driver.FindElements(By.CssSelector("#dynamic-results-container .specs-relationship-searchresult-container-item"));
            IWebElement firstAnchorLink = null;
            foreach (var element in containerElements)
            {
                var pElement = element.FindElement(By.CssSelector("p"));
                if (pElement != null)
                {
                    if (pElement.Text.Contains("No data sources mapped to datasets"))
                    {
                        var anchorLink = element.FindElement(By.CssSelector("h2 > a"));
                        if (anchorLink != null)
                        {
                            firstAnchorLink = anchorLink;
                            break;
                        }
                    }
                }

            }
            Thread.Sleep(1000);
            if (firstAnchorLink != null)
            {
                firstAnchorLink.Click();
            }
            else
            {
                firstAnchorLink.Should().NotBeNull("unable to find an item with no relationships");
            }
        }

        public static void SpecificationDataRelationshipsExistPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();
            MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();
            
            homepage.ManagetheData.Click();
            managethedatapage.specifyDataSetRelationshipLink.Click();
            Thread.Sleep(5000);

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();
            string specCreatedID = specName.ToString().Replace("Test Spec Name ", "");

            mapdatasourcestodatasetspage.mapDataSourcesSearchTermField.SendKeys(specCreatedID);
            mapdatasourcestodatasetspage.mapDataSourcesSearchTermButton.Click();
            Thread.Sleep(2000);
            
            var containerElements = Driver._driver.FindElements(By.CssSelector("#dynamic-results-container .specs-relationship-searchresult-container-item"));
            IWebElement firstAnchorLink = null;
            foreach (var element in containerElements)
            {
                var pElement = element.FindElement(By.CssSelector("p"));
                if (pElement != null)
                {
                    if (Regex.IsMatch(pElement.Text, "\\d data source mapped to dataset"))
                    {
                        var anchorLink = element.FindElement(By.CssSelector("h2 > a"));
                        if (anchorLink != null)
                        {
                            firstAnchorLink = anchorLink;
                            break;
                        }
                    }
                }

            }
            Thread.Sleep(1000);
            if (firstAnchorLink != null)
            {
                firstAnchorLink.Click();
            }
            else
            {
                firstAnchorLink.Should().NotBeNull("unable to find an item with relationships");
            }
        }


        public static void SelectSourceDatasetPage()
        {
            SelectedSpecificationDataSourcePage selectspecificationdatasourcepage = new SelectedSpecificationDataSourcePage();

            SpecificationDataRelationshipsExistPage();
            selectspecificationdatasourcepage.specificationDataSourceMissing.Click();
            Thread.Sleep(2000);


        }

        public static void ChangeSourceDatasetPage()
        {
            SelectedSpecificationDataSourcePage selectspecificationdatasourcepage = new SelectedSpecificationDataSourcePage();

            SpecificationDataRelationshipsExistPage();
            selectspecificationdatasourcepage.specificationDataSourceDatasetTableExpandInfo.Click();
            selectspecificationdatasourcepage.specificationChangeDataSource.Click();
            Thread.Sleep(2000);
        }

        public static void TestScenarioListPage()
        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();

            homepage.ManagetheTests.Click();
            Thread.Sleep(2000);
        }

        public static void CreateQATestPage()
        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();

            homepage.ManagetheTests.Click();
            Thread.Sleep(2000);
            testscenariolistpage.testScenarioPageCreateQATestButton.Click();
            Thread.Sleep(2000);
        }

        public static void ViewQATestResults()
        {
            HomePage homepage = new HomePage();
            ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();

            homepage.ViewtheResults.Click();
            viewresultsoptionspage.viewResultsOptionsViewQATestResults.Click();
            Thread.Sleep(30000);
        }


        public static void ViewCalculationResultsPage()
        {
            HomePage homepage = new HomePage();
            ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();

            homepage.ViewtheResults.Click();
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Click();
            Thread.Sleep(5000);
        }

        public static void EditQATestPage()
        {
            HomePage homepage = new HomePage();
            TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
            EditQATestPage editqatestpage = new EditQATestPage();

            homepage.ManagetheTests.Click();
            Thread.Sleep(4000);

            IWebElement testscenarioname = testscenariolistpage.testScenarioPageFirstTestScenarioName;
            string scenarioname = testscenarioname.Text;
            scenarioname.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Name selected to edit is " + scenarioname);

            testscenarioname.Click();
            Thread.Sleep(2000);

        }

        public static void EditSpecificationPolicyPage()
        {
            HomePage homepage = new HomePage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            EditPolicyPage editpolicypage = new EditPolicyPage();

            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();

            Thread.Sleep(2000);

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

            Thread.Sleep(2000);

        }

        public static void EditSpecificationSubPolicyPage()
        {
            HomePage homepage = new HomePage();
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();
            EditSubPolicyPage editsubpolicypage = new EditSubPolicyPage();

            CreateNewSpecification.CreateANewSpecification();
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
            ManageSpecificationCreateNewSubPolicy.CreateANewSpecificationSubPolicy();

            Thread.Sleep(2000);
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

        public static void EditSpecificationPage()
        {
            ManagePoliciesPage managepoliciespage = new ManagePoliciesPage();

            CreateNewPESportSpecification.CreateANewPESportSpecification();
            managepoliciespage.editSpecification.Should().NotBeNull();
            managepoliciespage.editSpecification.Click();
            Thread.Sleep(2000);

        }

        public static void ChooseFundingSpecPage()
        {
            ApprovalOptionsPage approvaloptionspage = new ApprovalOptionsPage();
            HomePage homepage = new HomePage();
            ChooseFundingSpecificationPage choosefunidngspecificationpage = new ChooseFundingSpecificationPage();

            homepage.Publishtheresults.Click();
            Thread.Sleep(2000);
            approvaloptionspage.ChooseFundingSpecification.Click();
            Thread.Sleep(2000);
        }

        public static void ApprovePublishFundingSelectionPage()
        {
            ApprovalOptionsPage approvaloptionspage = new ApprovalOptionsPage();
            HomePage homepage = new HomePage();
            ApprovePublishFundingPage approvepublishfundingpage = new ApprovePublishFundingPage();

            homepage.Publishtheresults.Click();
            Thread.Sleep(2000);
            approvaloptionspage.ApprovePublishFunding.Click();
            Thread.Sleep(2000);
        }

        public static void ApprovePublishFundingage()
        {
            ApprovalOptionsPage approvaloptionspage = new ApprovalOptionsPage();
            HomePage homepage = new HomePage();
            ApprovePublishSelectorPage approvepublishselectorpage = new ApprovePublishSelectorPage();
            ApprovePublishFundingPage approvepublishfundingpage = new ApprovePublishFundingPage();

            homepage.Publishtheresults.Click();
            Thread.Sleep(2000);
            approvaloptionspage.ApprovePublishFunding.Click();
            Thread.Sleep(2000);
            Actions.SelectSpecificationToApprovePublish();
            approvepublishselectorpage.approvePublishSelectorViewFundingButton.Click();
            Thread.Sleep(20000);
        }

        public static void DataSourceHistorygage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();
            ManageDatasetsPage managedatasetpage = new ManageDatasetsPage();
            DatasetHistoryPage datahistorypage = new DatasetHistoryPage();

            homepage.ManagetheData.Click();
            managethedatapage.manageDataSetsLink.Click();
            managedatasetpage.firstDatasourceExpandOption.Click();
            Thread.Sleep(2000);
            IWebElement viewDataSourceVersionLink = managedatasetpage.viewDataSourceHistoryLink;
            viewDataSourceVersionLink.Click();
            Thread.Sleep(2000);
        }


    }
}

