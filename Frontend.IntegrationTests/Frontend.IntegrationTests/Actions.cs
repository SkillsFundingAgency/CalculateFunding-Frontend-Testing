namespace AutoFramework
{
    using FluentAssertions;
    using Frontend.IntegrationTests.Pages.Manage_Calculation;
    using Frontend.IntegrationTests.Pages.Manage_Datasets;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Drawing.Imaging;
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

        }
    }
