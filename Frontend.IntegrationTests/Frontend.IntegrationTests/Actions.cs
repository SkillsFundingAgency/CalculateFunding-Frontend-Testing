namespace AutoFramework
{
    using FluentAssertions;
    using Frontend.IntegrationTests.Pages.Manage_Calculation;
    using Frontend.IntegrationTests.Pages.Manage_Datasets;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public static class Actions

    {
        public static string PeriodTextValue { get; set; }
        public static string CalculationTotalValue { get; set; }
        public static string Fundingstreamvalue { get; set; }
        public static string Specificationvalue { get; set; }
        public static string Allocationlinevalue { get; set; }
        public static string Calculationstatusvalue { get; set; }
        public static string datasestinfo { get; set; }




        [BeforeScenario(new string[] { "Driver" })]
        public static void InitializeHomePage()
        {
            Driver._driver = new FirefoxDriver();
            Driver._driver.Manage().Window.Maximize();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);
        }

        public static void TakeScreenshot(this IWebDriver driver, string prefix)

        {
            var fileName = String.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("HHmmss"), ".png");
            var screenShot = ((ITakesScreenshot)Driver._driver).GetScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }

        public static void CalculationTotalResult()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            CalculationTotalValue = CalculationTotal.Text;

        }

        public static void SelectCalculationYear()
        {
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2)")).Click();
            Thread.Sleep(2000);
            IWebElement Period1819 = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > label:nth-child(1) > input:nth-child(1)"));
            PeriodTextValue = Period1819.Text;
            Period1819.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2)")).Click();

        }

        public static void SelectCalculationFundingStream()
        {
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")).Click();
            Thread.Sleep(2000);
            IWebElement fundingstream = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > label:nth-child(1) > input:nth-child(1)"));
            Fundingstreamvalue = fundingstream.Text;
            fundingstream.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")).Click();

        }

        public static void SelectCalculationSpecification()
        {
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)")).Click();
            Thread.Sleep(2000);
            IWebElement specification = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > label:nth-child(1) > input:nth-child(1)"));
            Specificationvalue = specification.Text;
            specification.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)")).Click();

        }

        public static void SelectCalculationAllocationLine()
        {
            Driver._driver.FindElement(By.CssSelector("#filter-container > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")).Click();
            Thread.Sleep(2000);
            IWebElement allocationline = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > label:nth-child(1) > input:nth-child(1)"));
            Allocationlinevalue = allocationline.Text;
            allocationline.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.CssSelector("#filter-container > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")).Click();

        }

        public static void SelectCalculationStatus()
        {
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(4) > div:nth-child(2) > button:nth-child(1)")).Click();
            Thread.Sleep(2000);
            IWebElement calculationstatus = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > label:nth-child(1) > input:nth-child(1)"));
            Calculationstatusvalue = calculationstatus.Text;
            calculationstatus.Click();
            Thread.Sleep(2000);
            Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(4) > div:nth-child(2) > button:nth-child(1)")).Click();

        }

        public static void ManageCalculationFiltersAreSetAsDefault()
        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            managecalculationpage.SpecNameDropDownDefault.Should().Equals("Select specification name");
            managecalculationpage.AllocationLineDropDownDefault.Should().Equals("Select Allocation Line");
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals("Select year");
            managecalculationpage.FundingStreamDropDownDefault.Should().Equals("Select funding stream");
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals("Show all status");
            Thread.Sleep(2000);

        }

        public static void SearchFilterForTestCalculations()
        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            managecalculationpage.CalculationSearchField.Clear();
            managecalculationpage.CalculationSearchField.SendKeys("Test");
            managecalculationpage.CalculationSearchButton.Click();
            Thread.Sleep(2000);

        }

        public static void SelectDatasetDataSchemaDropDown()
        {
            ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();

            choosedatasetrelationshippage.selectDatasetSchemaDropDown.Click();
            choosedatasetrelationshippage.selectDatasetSchemaDropDownTextSearch.SendKeys("High Needs");
            choosedatasetrelationshippage.selectDatasetSchemaDropDown.SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(2000);

        }

        public static void SelectSpecificationDataNoDataSchemaAssociated()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("#top > main:nth-child(4) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)"));
            IWebElement firstSelectSourceDatasetLink = null;
            foreach (var element in containerElements)
            {
                var aelement = element.FindElement(By.TagName("a"));
                if (aelement != null)
                {
                    if (aelement.Text.Contains("Select source dataset"))
                    {
                        {
                            firstSelectSourceDatasetLink = aelement;
                            break;
                        }
                    }

                }
                Thread.Sleep(1000);
                if (firstSelectSourceDatasetLink != null)
                {
                    firstSelectSourceDatasetLink.Click();
                }
                else
                {
                    firstSelectSourceDatasetLink.Should().NotBeNull("Unable to find an item with no source dataset");
                }
            }
        }

        public static void SelectSpecificationDataDataSchemaExists()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("#top > main:nth-child(4) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)"));
            IWebElement firstChangeSourceDatasetLink = null;
            foreach (var element in containerElements)
            {
                var aelement = element.FindElement(By.TagName("a"));
                if (aelement != null)
                {
                    if (aelement.Text.Contains("Change source dataset"))
                    {
                        var anchorLink = element.FindElement(By.CssSelector("p > a"));
                        if (anchorLink != null)
                        {
                            firstChangeSourceDatasetLink = anchorLink;
                            break;
                        }
                    }

                }
                Thread.Sleep(1000);
                if (firstChangeSourceDatasetLink != null)
                {
                    string datasestinfoline = firstChangeSourceDatasetLink.Text;
                    datasestinfo = datasestinfoline;
                }
                else
                {
                    firstChangeSourceDatasetLink.Should().NotBeNull("Unable to find an item with an existing source dataset");
                }
            }
        }

        public static void PaginationSelectPage()
        {
            var pagingLinks = Driver._driver.FindElements(By.CssSelector("#dynamic-paging-container a.paging-link"));
            IWebElement nextLink = null;

            foreach(IWebElement pagingLink in pagingLinks)
            {
                if(pagingLink.GetCssValue("display") == "none")
                {
                    continue;
                }

                IWebElement spanTag = null;
                try
                {
                    spanTag  = pagingLink.FindElement(By.TagName("span"));
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
               
                if(spanTag == null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(spanTag.Text))
                {
                    continue;
                }

                nextLink = pagingLink;
                break;
            }
            
            if (nextLink != null)
            {
                nextLink.Click();
                Thread.Sleep(2000);
            }
            else
            {
                pagingLinks.Should().NotBeNull("Cannot select additional pages as there is only one page of results");

            }

        }

        public static void SelectSourceDatasetsRadioOption()
        {
            SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();

            var containerElements = Driver._driver.FindElements(By.ClassName("selectdataset-item-name"));
            IWebElement firstSelectSourceDatasetRadio = containerElements.FirstOrDefault();
                
                if (firstSelectSourceDatasetRadio != null)
                {
                    firstSelectSourceDatasetRadio.Click();
                }
                else
                {
                    firstSelectSourceDatasetRadio.Should().NotBeNull("Unable to find source dataset option");
                }
        }

        public static void SelectSourceDatasetVersionRadioOption()
        {
            SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();

            var containerElements = Driver._driver.FindElements(By.ClassName("selectdataset-item-datasetversion"));
            IWebElement firstSelectSourceDatasetVersionRadio = containerElements.FirstOrDefault();

            if (firstSelectSourceDatasetVersionRadio != null)
            {
                firstSelectSourceDatasetVersionRadio.Click();
            }
            else
            {
                firstSelectSourceDatasetVersionRadio.Should().NotBeNull("Unable to find source dataset option");
            }
        }

        public static void SelectSpecificationProviderAllocationPage()
        {
            var containerElements = Driver._driver.FindElement(By.Id("SpecificationId"));
            IWebElement firstSelectSpecification = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (!string.IsNullOrWhiteSpace(optionelement.GetAttribute("value")))
                        {

                            firstSelectSpecification = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectSpecification != null)
                {
                    firstSelectSpecification.Click();
                }
                else
                {
                    firstSelectSpecification.Should().NotBeNull("No Specifications exist for the academic year selected");
                }
            }
            else
            {
                firstSelectSpecification.Should().NotBeNull("No Specifications exist for the academic year selected");
            }
        }

        public static void CreateCalculationSpecificationpageSelectPolicyOrSubpolicyDropDown()
        {
            var containerElements = Driver._driver.FindElement(By.Id("CreateCalculationViewModel-PolicyId"));
            IWebElement firstSelectPolicy = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (!string.IsNullOrWhiteSpace(optionelement.GetAttribute("value")))
                        {

                            firstSelectPolicy = optionelement;

                            break;
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
                    firstSelectPolicy.Should().NotBeNull("No Specifications exist for the academic year selected");
                }
            }
            else
            {
                firstSelectPolicy.Should().NotBeNull("No Specifications exist for the academic year selected");
            }
        }


    }
}
