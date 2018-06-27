using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using MySpecFlow.Pages;
using MySpecFlow.Helpers;

namespace MySpecFlow.StepDefinitions
{
    class GenericStepDefs
    {
        //WebDriver support class "MySpecFlow.Helpers"
        private WebDriver _webDriver;
        
        public IWebDriver driver;
        public WebDriverWait wait;

        public GenericStepDefs (WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [BeforeScenario()]
        public void SetUp()
        {
            driver = _webDriver.driver;
            wait = _webDriver.wait;
        }

        [AfterScenario()]
        public void Quit()
        {
            _webDriver.TearDown();
        }
        

        //PAGES
        public Page page;
        public LoginPage loginPage;
        public DashboardPage dashboardpage;
        
        
        // GET PAGE METHODS
        public Page Support()
        {
            if (page == null)
                page = new Page(driver, wait);
            return page;
        }

        public LoginPage GetLoginPage()
        {
            if (loginPage == null)
                loginPage = new LoginPage(driver, wait);
            return loginPage;
        }

        public DashboardPage GetDashboardPage()
        {
            if (dashboardpage == null)
                dashboardpage = new DashboardPage(driver, wait);
            return dashboardpage;
        }
    }
}
