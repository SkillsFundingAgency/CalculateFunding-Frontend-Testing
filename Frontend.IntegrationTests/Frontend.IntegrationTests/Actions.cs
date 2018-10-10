namespace AutoFramework
{
    using FluentAssertions;
    using Frontend.IntegrationTests.Helpers;
    using Frontend.IntegrationTests.Pages;
    using Frontend.IntegrationTests.Pages.Approve_funding;
    using Frontend.IntegrationTests.Pages.Manage_Calculation;
    using Frontend.IntegrationTests.Pages.Manage_Datasets;
    using Frontend.IntegrationTests.Pages.Manage_Specification;
    using Frontend.IntegrationTests.Pages.Quality_Assurance;
    using Frontend.IntegrationTests.Pages.View_Results;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using TechTalk.SpecFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.PhantomJS;
    using Frontend.IntegrationTests.Pages.Home_Page;

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
        public static string TestUserMe = "richard.wilson@education.gov.uk";
        public static string TestPwMe = "Joanne1976$02";



        [BeforeScenario(new string[] { "Driver" })]
        public static void InitializeHomePage()
        {
            Driver._driver = new ChromeDriver();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);

            MSDfESignInPage msdfesigninpage = new MSDfESignInPage();
            DfESignInPage dfesigninpage = new DfESignInPage();

            msdfesigninpage.msUserInput.Should().NotBeNull();
            msdfesigninpage.msUserInput.SendKeys(TestUserMe);
            msdfesigninpage.msUserNext.Click();
            Thread.Sleep(6000);
            dfesigninpage.userNameInput.Should().NotBeNull();
            dfesigninpage.userNameInput.Clear();
            dfesigninpage.userNameInput.SendKeys(TestUserMe);
            dfesigninpage.passwordInput.SendKeys(TestPwMe);
            dfesigninpage.submitButton.Click();
            Thread.Sleep(6000);
        }

        [BeforeScenario(new string[] { "FFDriver" })]
        public static void InitializeFirefoxHomePage()
        {
            Driver._driver = new FirefoxDriver();
            Driver._driver.Manage().Window.Maximize();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);
            
        }

        [BeforeScenario(new string[] { "ChromeDriver" })]
        public static void InitializeChromeHomePage()
        {
            Driver._driver = new ChromeDriver();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);
        }

        [BeforeScenario(new string[] { "PhantomDriver" })]
        public static void InitializePhantomHomePage()
        {
            Driver._driver = new PhantomJSDriver();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);

        }

        [BeforeScenario(new string[] { "DfELogIn" })]
        public static void DfELogIn()
        {
            MSDfESignInPage msdfesigninpage = new MSDfESignInPage();
            DfESignInPage dfesigninpage = new DfESignInPage();

            msdfesigninpage.msUserInput.Should().NotBeNull();
            msdfesigninpage.msUserInput.SendKeys(TestUserMe);
            msdfesigninpage.msUserNext.Click();
            Thread.Sleep(6000);
            dfesigninpage.userNameInput.Should().NotBeNull();
            dfesigninpage.userNameInput.Clear();
            dfesigninpage.userNameInput.SendKeys(TestUserMe);
            dfesigninpage.passwordInput.SendKeys(TestPwMe);
            dfesigninpage.submitButton.Click();
            Thread.Sleep(6000);
        }

        public static void TakeScreenshot(this IWebDriver driver, string prefix)

        {
            var fileName = String.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("HHmmss"), ".png");
            var screenShot = ((ITakesScreenshot)Driver._driver).GetScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }

        public static void CalculationTotalResult()
        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            //IWebElement CalculationTotal = managecalculationpage.CalculationsTotalResults;
            CalculationTotalValue = CalculationTotal.Text;

        }

        public static void SelectCalculationYear()
        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            IWebElement filtercontainer = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(1)"));
            IWebElement fundingperiodfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingperiodfilter.Click();
            Thread.Sleep(4000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingperiodselected = selectfilteroption.Text;
            Console.WriteLine("Funding Period Filter Option selected = " + fundingperiodselected);
            selectfilteroption.Click();
            Thread.Sleep(6000);

        }

        public static void SelectCalculationFundingStream()
        {
            IWebElement filtercontainer = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(2)"));
            IWebElement fundingstreamfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingstreamfilter.Click();
            Thread.Sleep(4000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingstreamselected = selectfilteroption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + fundingstreamselected);
            selectfilteroption.Click();
            Thread.Sleep(6000);
        }

        public static void SelectCalculationSpecification()
        {
            IWebElement filtercontainer = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(3)"));
            IWebElement fundingspecfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingspecfilter.Click();
            Thread.Sleep(4000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingspecselected = selectfilteroption.Text;
            Console.WriteLine("Funding Specification Filter Option selected = " + fundingspecselected);
            selectfilteroption.Click();
            Thread.Sleep(6000);
        }

        public static void SelectCalculationAllocationLine()
        {
            IWebElement filtercontainer = Driver._driver.FindElement(By.CssSelector("#filter-container > div:nth-child(2) > div:nth-child(2)"));
            IWebElement fundingallocationfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingallocationfilter.Click();
            Thread.Sleep(4000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingallocationselected = selectfilteroption.Text;
            Console.WriteLine("Funding Specification Filter Option selected = " + fundingallocationselected);
            selectfilteroption.Click();
            Thread.Sleep(6000);
        }

        public static void SelectCalculationStatus()
        {
            IWebElement filtercontainer = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(4)"));
            IWebElement fundingstatusfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingstatusfilter.Click();
            Thread.Sleep(4000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string fundingstatusselected = selectfilteroption.Text;
            Console.WriteLine("Funding Specification Filter Option selected = " + fundingstatusselected);
            selectfilteroption.Click();
            Thread.Sleep(6000);
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
            Thread.Sleep(6000);

        }

        public static void SelectDatasetDataSchemaDropDown()
        {
            ChooseDatasetRelationshipPage choosedatasetrelationshippage = new ChooseDatasetRelationshipPage();

            choosedatasetrelationshippage.selectDatasetSchemaDropDown.Click();
            choosedatasetrelationshippage.selectDatasetSchemaDropDownTextSearch.SendKeys("High Needs Student Numbers");
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

            foreach (IWebElement pagingLink in pagingLinks)
            {
                if (pagingLink.GetCssValue("display") == "none")
                {
                    continue;
                }

                IWebElement spanTag = null;
                try
                {
                    spanTag = pagingLink.FindElement(By.TagName("span"));
                }
                catch (NoSuchElementException)
                {
                    continue;
                }

                if (spanTag == null)
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

        public static void SelectNewSourceDatasetsRadioOption()
        {
            SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();

            var containerElements = Driver._driver.FindElements(By.ClassName("selectdataset-item-name"));
            IWebElement firstSelectSourceDatasetRadio = containerElements.LastOrDefault();

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

        public static void SelectNewSourceDatasetVersionRadioOption()
        {
            SelectSourceDatasetsPage selectsourcedatasetspage = new SelectSourceDatasetsPage();

            var containerElements = Driver._driver.FindElements(By.ClassName("selectdataset-item-datasetversion"));
            IWebElement firstSelectSourceDatasetVersionRadio = containerElements.LastOrDefault();

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


        public static void SelectPolicyForSubPolicyCreationDropdownOption()
        {
            CreateSubPolicyPage createsubpolicypage = new CreateSubPolicyPage();

            var containerElements = Driver._driver.FindElement(By.Id("CreateSubPolicyViewModel-ParentPolicyId"));
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
                    firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectPolicy.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        public static void SelectQATestSpecificationDropdownOption()
        {
            CreateQATestPage createqatestpage = new CreateQATestPage();

            var containerElements = createqatestpage.createQATestSelectSpecification;
            IWebElement firstSelectSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (!string.IsNullOrWhiteSpace(optionelement.GetAttribute("value")))
                        {

                            firstSelectSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectSpec != null)
                {
                    firstSelectSpec.Click();
                }
                else
                {
                    firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        public static void SelectSpecificationCreateQATestPage()
        {
            CreateQATestPage createqatestpage = new CreateQATestPage();

            var containerElements = createqatestpage.createQATestSelectSpecification;
            IWebElement firstSelectSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("Test Spec Name"))
                        {

                            firstSelectSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectSpec != null)
                {
                    firstSelectSpec.Click();
                }
                else
                {
                    firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        public static void SelectSpecifiedSpecificationCreateQATestPage()
        {
            CreateQATestPage createqatestpage = new CreateQATestPage();

            var specName = ScenarioContext.Current["SpecificationName"];
            string specCreated = specName.ToString();

            var containerElements = createqatestpage.createQATestSelectSpecification;
            IWebElement firstSelectSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("option"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains(specCreated))
                        {

                            firstSelectSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (firstSelectSpec != null)
                {
                    firstSelectSpec.Click();
                }
                else
                {
                    firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
                }
            }
            else
            {
                firstSelectSpec.Should().NotBeNull("No Policy exists that can be selected");
            }
        }

        public static void SelectExistingSpecificationManageSpecificationPage()
        {
            ManageSpecificationPage manaespecficationpage = new ManageSpecificationPage();

            var containerElements = manaespecficationpage.SpecificationList;
            IWebElement SelectFirstSpec = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (!string.IsNullOrWhiteSpace(optionelement.GetAttribute("id")))
                        {

                            SelectFirstSpec = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstSpec != null)
                {
                    SelectFirstSpec.Click();
                }
                else
                {
                    SelectFirstSpec.Should().NotBeNull("No specification was successfully selected");
                }
            }
            else
            {
                SelectFirstSpec.Should().NotBeNull("No specification was successfully selected");
            }
        }

        public static void SelectManageDataPageDataSourceDownloadoption()
        {
            ManageDatasetsPage managedatasetpage = new ManageDatasetsPage();

            var containerElements = managedatasetpage.manageDatasetsListView;
            IWebElement SelectFirstDownloadlink = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("Download"))
                        {

                            SelectFirstDownloadlink = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstDownloadlink != null)
                {
                    var downloadurl = SelectFirstDownloadlink.GetAttribute("href");
                    downloadurl.Should().NotBeNullOrWhiteSpace();

                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.AllowAutoRedirect = false;
                    Uri redirectedBlobUrl;

                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        client.BaseAddress = new Uri(Config.BaseURL);

                        HttpResponseMessage response = client.GetAsync(downloadurl).Result;
                        response.Should().NotBeNull();
                        response.StatusCode.Should().Be(HttpStatusCode.Redirect);

                        redirectedBlobUrl = response.Headers.Location;
                        redirectedBlobUrl.AbsoluteUri.Should().NotBeNullOrWhiteSpace();
                        Console.WriteLine("Redirected blob URL: {0}", redirectedBlobUrl);
                    }

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage downloadFileResponse = client.GetAsync(redirectedBlobUrl.AbsoluteUri).Result;

                        downloadFileResponse.Should().NotBeNull();
                        downloadFileResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                        IEnumerable<string> filenameHeaders;
                        downloadFileResponse.Headers.TryGetValues("x-ms-meta-filename", out filenameHeaders);
                        string filename = filenameHeaders.FirstOrDefault();

                        Console.WriteLine("File downloaded successfully. Filename = {0}", filename);
                    }
                }
                else
                {
                    SelectFirstDownloadlink.Should().NotBeNull("No Download link could be successfully selected");
                }
            }
            else
            {
                SelectFirstDownloadlink.Should().NotBeNull("No Download link could be successfully selected");
            }
        }


        public static void SearchQATestResultsPageByQATestName()
        {
            ViewQATestResultsPage viewqatestresultspage = new ViewQATestResultsPage();

            var containerElements = viewqatestresultspage.viewQATestResultspageQATestResultTable;
            IWebElement SelectFirstTest = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.CssSelector("td a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        SelectFirstTest = optionelement;

                        break;


                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstTest != null)
                {
                    string firsttestname = SelectFirstTest.Text;
                    ScenarioContext.Current["QATestName"] = firsttestname;
                    firsttestname.Should().NotBeNullOrEmpty();
                    Console.WriteLine("QA Test searched for: " + firsttestname);

                    string testCreatedID = SelectFirstTest.Text.Replace("QA Test Name ", "");
                    viewqatestresultspage.viewQATestResultspageSearch.SendKeys(testCreatedID);
                    viewqatestresultspage.viewQATestResultspageSearchButton.Click();

                }
                else
                {
                    SelectFirstTest.Should().NotBeNull("No QA Test was successfully selected");
                }
            }
            else
            {
                SelectFirstTest.Should().NotBeNull("No QA Test was successfully found");
            }
        }


        public static void SelectQATestResultByQATestName()
        {
            ViewQATestResultsPage viewqatestresultspage = new ViewQATestResultsPage();

            var containerElements = viewqatestresultspage.viewQATestResultspageQATestResultTable;
            IWebElement SelectFirstTest = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.CssSelector("td a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {

                        SelectFirstTest = optionelement;

                        break;


                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstTest != null)
                {
                    string firsttestname = SelectFirstTest.Text;
                    firsttestname.Should().NotBeNullOrEmpty();
                    Console.WriteLine("QA Test selected: " + firsttestname);
                    SelectFirstTest.Click();

                }
                else
                {
                    SelectFirstTest.Should().NotBeNull("No QA Test was successfully selected");
                }
            }
            else
            {
                SelectFirstTest.Should().NotBeNull("No QA Test was successfully found");
            }
        }


        public static void MapDataSourcesToDatasetsForSpecification()
        {
            {
                MapDataSourcesToDatasetsPage mapdatasourcestodatasetpage = new MapDataSourcesToDatasetsPage();
                var specName = ScenarioContext.Current["SpecificationName"];
                string specCreated = specName.ToString();

                var containerElements = mapdatasourcestodatasetpage.mapDataSourcesResultListContainer;
                IWebElement SelectFirstSpec = null;
                if (containerElements != null)
                {
                    var options = containerElements.FindElements(By.CssSelector("h2 a"));
                    foreach (var optionelement in options)
                    {
                        if (optionelement != null)
                        {
                            SelectFirstSpec = optionelement;
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                    if (SelectFirstSpec != null)
                    {
                        string firstspecname = SelectFirstSpec.Text;
                        firstspecname.Should().NotBeNullOrEmpty();
                        firstspecname.Should().Be(specCreated, "Specification Selected does not match the specifically created Specification for this Test");
                        Console.WriteLine("Specification Selected selected: " + firstspecname);
                        SelectFirstSpec.Click();
                    }
                    else
                    {
                        SelectFirstSpec.Should().NotBeNull("No Specification was successfully selected");
                    }
                }
                else
                {
                    SelectFirstSpec.Should().NotBeNull("No Specification was successfully found");
                }
            }
        }

        public static void SelectProviderWhereQATestResultMarkedPassed()
        {
            ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();

            var containerElements = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement firstPassedProvider = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.CssSelector(".provider-item-header"));
                if (options != null)
                {
                    foreach (var headerelement in options)
                    {
                        IWebElement passedElement = null;
                        try
                        {
                            passedElement = headerelement.FindElement(By.CssSelector(".flag--success"));
                        }
                        catch (NoSuchElementException)
                        {
                        }

                        if (passedElement != null)
                        {
                            var anchorLink = headerelement.FindElement(By.CssSelector("h4 a"));
                            if (anchorLink != null)
                            {
                                firstPassedProvider = anchorLink;

                                break;

                            }

                        }

                    }
                    if (firstPassedProvider != null)
                    {
                        string firstPassedName = firstPassedProvider.Text;
                        firstPassedName.Should().NotBeNullOrEmpty();
                        Console.WriteLine("The Provider where the selected QA Test has Passed is: " + firstPassedName);
                        firstPassedProvider.Click();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        firstPassedProvider.Should().NotBeNull("No Provider has a result of Passed within this list of results");
                    }
                }
                else
                {
                    firstPassedProvider.Should().NotBeNull("No Provider exists that can be selected");
                }
            }
        }


        public static void SelectProviderWhereQATestResultMarkedFailed()
        {
            ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();

            var containerElements = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement firstFailedProvider = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.CssSelector(".provider-item-header"));
                if (options != null)
                {
                    foreach (var headerelement in options)
                    {
                        IWebElement passedElement = null;
                        try
                        {
                            passedElement = headerelement.FindElement(By.CssSelector(".flag--urgent"));
                        }
                        catch (NoSuchElementException)
                        {
                        }

                        if (passedElement != null)
                        {
                            var anchorLink = headerelement.FindElement(By.CssSelector("h4 a"));
                            if (anchorLink != null)
                            {
                                firstFailedProvider = anchorLink;

                                break;

                            }

                        }

                    }
                    if (firstFailedProvider != null)
                    {
                        string firstFailedName = firstFailedProvider.Text;
                        firstFailedName.Should().NotBeNullOrEmpty();
                        Console.WriteLine("The Provider where the selected QA Test has Failed is: " + firstFailedName);
                        firstFailedProvider.Click();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        firstFailedProvider.Should().NotBeNull("No Provider has a result of Failed within this list of results");
                    }
                }
                else
                {
                    firstFailedProvider.Should().NotBeNull("No Provider exists that can be selected");
                }
            }
        }

        public static void SelectManageDataPageDataSourceUpdateOption()
        {
            ManageDatasetsPage managedatasetpage = new ManageDatasetsPage();

            var containerElements = managedatasetpage.manageDatasetsListView;
            IWebElement SelectFirstUpdatelink = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("Update"))
                        {

                            SelectFirstUpdatelink = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstUpdatelink != null)
                {
                    SelectFirstUpdatelink.Click();
                    Thread.Sleep(2000);
                }
                else
                {
                    SelectFirstUpdatelink.Should().NotBeNull("No Update link could be successfully selected");
                }
            }
            else
            {
                SelectFirstUpdatelink.Should().NotBeNull("No Update link could be successfully selected");
            }
        }

        public static void ApproveFundingChooseProviderAllocationLineToApprove()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;
            IWebElement currentProvider = null;

            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    if (currentProvider != null)
                    {
                        var previoustriggerelement = currentProvider.FindElement(By.CssSelector(".expander-trigger-cell"));
                        if (previoustriggerelement != null)
                        {
                            previoustriggerelement.Click();
                        }

                    }

                    currentProvider = element;

                    var triggerelement = element.FindElement(By.CssSelector(".expander-trigger-cell"));
                    if (triggerelement == null)
                    {
                        continue;
                    }

                    triggerelement.Click();
                    Thread.Sleep(500);
                    continue;

                }

                if (currentProvider == null)
                {
                    continue;
                }


                if (element.GetAttribute("class").Contains("data-allocationline-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-held"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (aelement.Text.Contains("Held"))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-allocationline"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Held");
            }

        }

        public static void ApproveFundingChooseProviderAllocationLineToPublished()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;
            IWebElement currentProvider = null;

            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    if (currentProvider != null)
                    {
                        var previoustriggerelement = currentProvider.FindElement(By.CssSelector(".expander-trigger-cell"));
                        if (previoustriggerelement != null)
                        {
                            previoustriggerelement.Click();
                        }

                    }

                    currentProvider = element;

                    var triggerelement = element.FindElement(By.CssSelector(".expander-trigger-cell"));
                    if (triggerelement == null)
                    {
                        continue;
                    }

                    triggerelement.Click();
                    Thread.Sleep(500);
                    continue;

                }

                if (currentProvider == null)
                {
                    continue;
                }


                if (element.GetAttribute("class").Contains("data-allocationline-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-approved"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (aelement.Text.Contains("Approved"))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-allocationline"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Approved");
            }

        }


        public static void ApproveFundingChooseProviderFundingStreamToApprove()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;
            IWebElement currentProvider = null;

            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    if (currentProvider != null)
                    {
                        var previoustriggerelement = currentProvider.FindElement(By.CssSelector(".expander-trigger-cell"));
                        if (previoustriggerelement != null)
                        {
                            previoustriggerelement.Click();
                        }

                    }

                    currentProvider = element;

                    var triggerelement = element.FindElement(By.CssSelector(".expander-trigger-cell"));
                    if (triggerelement == null)
                    {
                        continue;
                    }

                    triggerelement.Click();
                    Thread.Sleep(500);
                    continue;

                }

                if (currentProvider == null)
                {
                    continue;
                }


                if (element.GetAttribute("class").Contains("data-fundingstream-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-held"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (TestRegexUtil.NumbersEqual(aelement.Text))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-fundingstream"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Held");
            }

        }

        public static void ApproveFundingChooseProviderFundingStreamToPublish()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;
            IWebElement currentProvider = null;

            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    if (currentProvider != null)
                    {
                        var previoustriggerelement = currentProvider.FindElement(By.CssSelector(".expander-trigger-cell"));
                        if (previoustriggerelement != null)
                        {
                            previoustriggerelement.Click();
                        }

                    }

                    currentProvider = element;

                    var triggerelement = element.FindElement(By.CssSelector(".expander-trigger-cell"));
                    if (triggerelement == null)
                    {
                        continue;
                    }

                    triggerelement.Click();
                    Thread.Sleep(500);
                    continue;

                }

                if (currentProvider == null)
                {
                    continue;
                }


                if (element.GetAttribute("class").Contains("data-fundingstream-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-approved"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (TestRegexUtil.NumbersEqual(aelement.Text))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-fundingstream"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Approved");
            }

        }


        public static void ApproveFundingChooseProviderToApprove()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;


            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-held"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (TestRegexUtil.NumbersEqual(aelement.Text))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-provider"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Held");
            }

        }

        public static void ApproveFundingChooseProviderToPublish()
        {
            var containerElements = Driver._driver.FindElements(By.CssSelector("table.cf tr"));
            IWebElement firstHeldProvider = null;


            foreach (var element in containerElements)
            {
                if (element.GetAttribute("class").Contains("data-provider-container"))
                {
                    IWebElement aelement = null;
                    try
                    {
                        aelement = element.FindElement(By.CssSelector(".status-approved"));
                    }
                    catch (NoSuchElementException)
                    {

                    }


                    if (aelement != null)
                    {
                        if (TestRegexUtil.NumbersEqual(aelement.Text))
                        {
                            var checkboxOption = element.FindElement(By.ClassName("target-checkbox-provider"));
                            if (checkboxOption != null)
                            {
                                firstHeldProvider = checkboxOption;
                                break;
                            }

                        }

                    }

                }
            }

            Thread.Sleep(1000);
            if (firstHeldProvider != null)
            {
                firstHeldProvider.Click();
                Thread.Sleep(2000);
            }
            else
            {
                firstHeldProvider.Should().NotBeNull("Unable to find a Provider with a Status of Approved");
            }

        }

        public static void CreateSpecificationChooseAllFundingStreams(string fundingStreams)
        {
            CreateSpecificationPage createspecificationpage = new CreateSpecificationPage();

            SelectElement selectElement = new SelectElement(createspecificationpage.SpecFundingStreamOptionContainer);
            var options = selectElement.Options;

            int? maximumItems = null;
            int parsedInt;
            if (int.TryParse(fundingStreams, out parsedInt))
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

        public static void FindAvailabeFundingStreamSpecificationToChoose()
        {
            ChooseFundingSpecificationPage choosefundingspecificationpage = new ChooseFundingSpecificationPage();

            string specificationId = null;
            string fundingPeriodId = null;
            string fundingStreamId = null;

            bool foundChooseableFund = false;

            IWebElement selectFundingPeriod = choosefundingspecificationpage.chooseFundingSpecFundingPeriodDropdown;
            var selectElement = new SelectElement(selectFundingPeriod);
            List<string> fundingPeriodValues = new List<string>();
            fundingPeriodValues.AddRange(selectElement.Options.Select(s => s.GetAttribute("value")));
            foreach (var optionValue in fundingPeriodValues)
            {
                //Console.WriteLine(optionValue);
                selectElement.Options.Where(s => s.GetAttribute("value") == optionValue).FirstOrDefault().Click();
                Thread.Sleep(20000);


                IWebElement selectFundingStream = Driver._driver.FindElement(By.Id("fundingStream"));
                List<string> propertyElementList = new List<string>();
                foreach (IWebElement options in selectFundingStream.FindElements(By.TagName("option")))
                {
                    string fundingStreamOptionValue = options.GetAttribute("value");
                    if (!string.IsNullOrWhiteSpace(fundingStreamOptionValue))
                    {
                        propertyElementList.Add(fundingStreamOptionValue);
                    }
                }

                propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

                foreach (var fundingStreamValue in propertyElementList)
                {
                    var fundingStreamElement = new SelectElement(choosefundingspecificationpage.chooseFundingSpecFundingStreamDropdown);
                    IWebElement currentElement = fundingStreamElement.Options.Where(s => s.GetAttribute("value") == fundingStreamValue).FirstOrDefault();

                    currentElement.Should().NotBeNull("element {0} is null", fundingStreamValue);

                    if (string.IsNullOrWhiteSpace(currentElement.Text))
                    {
                        continue;
                    }

                    //string fundingStreamName = currentElement.Text;
                    //Console.WriteLine(fundingStreamName);
                    currentElement.Click();
                    Thread.Sleep(20000);


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
                                        foundChooseableFund = true;
                                        fundingPeriodId = optionValue;
                                        fundingStreamId = fundingStreamValue;

                                        string selectedHrefValue = optionelement.GetAttribute("href");
                                        var queryString = HttpUtility.ParseQueryString(selectedHrefValue);
                                        specificationId = queryString["specificationId"];
                                        Console.WriteLine(specificationId);

                                        break;
                                    }

                                }


                            }


                        }
                    }

                    if (foundChooseableFund)
                    {
                        break;

                    }
                }

                if (foundChooseableFund)
                {
                    break;

                }

            }

            if (foundChooseableFund)
            {
                ScenarioContext.Current["specificationId"] = specificationId;
                ScenarioContext.Current["fundingPeriodId"] = fundingPeriodId;
                ScenarioContext.Current["fundingStreamId"] = fundingStreamId;
            }
            else
            {
                Assert.Inconclusive("No Option to Choose a Specification could be successfully selected");

            }
        }

        public static void FindAvailabeFundingStreamSpecificationToViewFunding()
        {
            ChooseFundingSpecificationPage choosefundingspecificationpage = new ChooseFundingSpecificationPage();

            string specificationId = null;
            string fundingPeriodId = null;
            string fundingStreamId = null;

            bool foundChooseableFund = false;

            IWebElement selectFundingPeriod = choosefundingspecificationpage.chooseFundingSpecFundingPeriodDropdown;
            var selectElement = new SelectElement(selectFundingPeriod);
            List<string> fundingPeriodValues = new List<string>();
            fundingPeriodValues.AddRange(selectElement.Options.Select(s => s.GetAttribute("value")));
            foreach (var optionValue in fundingPeriodValues)
            {
                //Console.WriteLine(optionValue);
                selectElement.Options.Where(s => s.GetAttribute("value") == optionValue).FirstOrDefault().Click();
                Thread.Sleep(20000);


                IWebElement selectFundingStream = Driver._driver.FindElement(By.Id("fundingStream"));
                List<string> propertyElementList = new List<string>();
                foreach (IWebElement options in selectFundingStream.FindElements(By.TagName("option")))
                {
                    string fundingStreamOptionValue = options.GetAttribute("value");
                    if (!string.IsNullOrWhiteSpace(fundingStreamOptionValue))
                    {
                        propertyElementList.Add(fundingStreamOptionValue);
                    }
                }

                propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

                foreach (var fundingStreamValue in propertyElementList)
                {
                    var fundingStreamElement = new SelectElement(choosefundingspecificationpage.chooseFundingSpecFundingStreamDropdown);
                    IWebElement currentElement = fundingStreamElement.Options.Where(s => s.GetAttribute("value") == fundingStreamValue).FirstOrDefault();

                    currentElement.Should().NotBeNull("element {0} is null", fundingStreamValue);

                    if (string.IsNullOrWhiteSpace(currentElement.Text))
                    {
                        continue;
                    }

                    //string fundingStreamName = currentElement.Text;
                    //Console.WriteLine(fundingStreamName);
                    currentElement.Click();
                    Thread.Sleep(20000);


                    var containerElements = choosefundingspecificationpage.chooseFundingSpecTableBody;
                    IWebElement SelectFirstViewFunding = null;
                    if (containerElements != null)
                    {
                        var options = containerElements.FindElements(By.TagName("td a"));
                        foreach (var optionelement in options)
                        {
                            if (optionelement != null)
                            {
                                {
                                    if (optionelement.Text.Contains("View funding"))
                                    {

                                        SelectFirstViewFunding = optionelement;
                                        foundChooseableFund = true;
                                        fundingPeriodId = optionValue;
                                        fundingStreamId = fundingStreamValue;

                                        string selectedHrefValue = optionelement.GetAttribute("href");
                                        var queryString = HttpUtility.ParseQueryString(selectedHrefValue);
                                        specificationId = queryString["specificationId"];
                                        Console.WriteLine(specificationId);

                                        break;
                                    }

                                }


                            }


                        }
                    }

                    if (foundChooseableFund)
                    {
                        break;

                    }
                }

                if (foundChooseableFund)
                {
                    break;

                }

            }

            if (foundChooseableFund)
            {
                ScenarioContext.Current["specificationId"] = specificationId;
                ScenarioContext.Current["fundingPeriodId"] = fundingPeriodId;
                ScenarioContext.Current["fundingStreamId"] = fundingStreamId;
            }
            else
            {
                Assert.Inconclusive("No Option to View Funding for a Specification could be successfully selected");

            }
        }


        public static void DownloadDataSchemaDownloadOption()
        {
            DownloadDataSchemasPage downloaddataschemapage = new DownloadDataSchemasPage();

            var containerElements = downloaddataschemapage.searchDataSchemaTemplateDatasetDefinitionsTableBody;
            IWebElement SelectFirstDownloadlink = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("cloud_download"))
                        {

                            SelectFirstDownloadlink = optionelement;

                            break;
                        }

                    }
                }
                Thread.Sleep(1000);
                if (SelectFirstDownloadlink != null)
                {
                    var downloadurl = SelectFirstDownloadlink.GetAttribute("href");
                    downloadurl.Should().NotBeNullOrWhiteSpace();

                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.AllowAutoRedirect = false;
                    Uri redirectedBlobUrl;

                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        client.BaseAddress = new Uri(Config.BaseURL);

                        HttpResponseMessage response = client.GetAsync(downloadurl).Result;
                        response.Should().NotBeNull();
                        response.StatusCode.Should().Be(HttpStatusCode.Redirect);

                        redirectedBlobUrl = response.Headers.Location;
                        redirectedBlobUrl.AbsoluteUri.Should().NotBeNullOrWhiteSpace();
                        Console.WriteLine("Redirected blob URL: {0}", redirectedBlobUrl);
                    }

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage downloadFileResponse = client.GetAsync(redirectedBlobUrl.AbsoluteUri).Result;

                        downloadFileResponse.Should().NotBeNull();
                        downloadFileResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                        IEnumerable<string> filenameHeaders;
                        downloadFileResponse.Headers.TryGetValues("x-ms-meta-filename", out filenameHeaders);
                        string filename = filenameHeaders.FirstOrDefault();

                        Console.WriteLine("File downloaded successfully. Filename = {0}", filename);
                    }
                }
                else
                {
                    Assert.Inconclusive("No Download link could be successfully selected");
                }
            }
            else
            {
                SelectFirstDownloadlink.Should().NotBeNull("No Download link could be successfully selected");
            }
        }


    }
}





