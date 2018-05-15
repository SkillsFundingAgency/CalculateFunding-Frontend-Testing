namespace AutoFramework
{
    using FluentAssertions;
    using Frontend.IntegrationTests.Pages;
    using Frontend.IntegrationTests.Pages.Manage_Calculation;
    using Frontend.IntegrationTests.Pages.Manage_Datasets;
    using Frontend.IntegrationTests.Pages.Manage_Specification;
    using Frontend.IntegrationTests.Pages.Quality_Assurance;
    using Frontend.IntegrationTests.Pages.View_Results;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
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
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            //IWebElement CalculationTotal = managecalculationpage.CalculationsTotalResults;
            CalculationTotalValue = CalculationTotal.Text;

        }

        public static void SelectCalculationYear()
        {
            ManageCalculationPage managecalculationpage = new ManageCalculationPage();

            IWebElement academicyeardropdown = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)"));
            academicyeardropdown.Click();
            Thread.Sleep(2000);
            IWebElement Period = Driver._driver.FindElement(By.CssSelector(".open > ul:nth-child(2)"));
            IWebElement Period1819 = Period.FindElement(By.TagName("input"));
            PeriodTextValue = Period1819.Text;
            Period1819.Click();
            Thread.Sleep(2000);
            managecalculationpage.CalculationSearchField.Click();

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
                    viewqatestresultspage.viewQATestResultspageSearch.SendKeys(firsttestname);
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
                        firstFailedProvider.Click();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        firstFailedProvider.Should().NotBeNull("No Provider has a result of Passed within this list of results");
                    }
                }
                else
                {
                    firstFailedProvider.Should().NotBeNull("No Provider exists that can be selected");
                }
            }
        }


    }
}

