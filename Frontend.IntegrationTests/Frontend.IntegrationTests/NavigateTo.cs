using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using System.Threading;

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

    }
    }

