using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class ManageTheDataPage
    {
        public ManageTheDataPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "manageDatasourcesLink")]
        public IWebElement manageDataSetsLink { get; set; }

        [FindsBy(How = How.Id, Using = "manageDatasourcesDescription")]
        public IWebElement manageDataSetsDescription { get; set; }

        [FindsBy(How = How.Id, Using = "mapDatasourcesToDatasetsLink")]
        public IWebElement specifyDataSetRelationshipLink { get; set; }

        [FindsBy(How = How.Id, Using = "mapDatasourcesToDatasetsDescription")]
        public IWebElement specifyDataSetRelationshipDescription { get; set; }

        [FindsBy(How = How.LinkText, Using = "Download data schemas")]
        public IWebElement downloadDataSchemasLink { get; set; }




    }
}
