using AutoFramework;
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

            homepage.ManagetheSpecification.Click();
            managepecificationpage.SelectSpecification.Click();
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



        public static void SpecificationDataNoRelationshipsPage()
        {
            HomePage homepage = new HomePage();
            ManageTheDataPage managethedatapage = new ManageTheDataPage();
            MapDataSourcesToDatasetsPage mapdatasourcestodatasetspage = new MapDataSourcesToDatasetsPage();

            homepage.ManagetheData.Click();
            managethedatapage.specifyDataSetRelationshipLink.Click();
            var containerElements = Driver._driver.FindElements(By.CssSelector("#dynamic-results-container > div.specs-relationship-searchresult-container-item"));
            IWebElement firstAnchorLink = null;
            foreach (var element in containerElements)
            {
                var pElement = element.FindElement(By.TagName("p"));
                if (pElement != null)
                {
                    if(pElement.Text.Contains("No data relationships exist"))
                    {
                        var anchorLink = element.FindElement(By.CssSelector("h2 > a"));
                        if(anchorLink != null)
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
            var containerElements = Driver._driver.FindElements(By.CssSelector("#dynamic-results-container > div.specs-relationship-searchresult-container-item"));
            IWebElement firstAnchorLink = null;
            foreach (var element in containerElements)
            {
                var pElement = element.FindElement(By.TagName("p"));
                if (pElement != null)
                { 
                    if (Regex.IsMatch(pElement.Text, "\\d data relationships exist"))
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
            Thread.Sleep(5000);
        }


        public static void ViewCalculationResultsPage()
        {
            HomePage homepage = new HomePage();
            ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();

            homepage.ViewtheResults.Click();
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Click();
            Thread.Sleep(5000);
        }
    }
}

