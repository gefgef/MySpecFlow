using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace MySpecFlow.Pages
{
    class DashboardPage : Page
    {
        private IWebDriver drv;
        private WebDriverWait wait;

        public DashboardPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            drv = driver;
            this.wait = wait;
            PageFactory.InitElements(drv, this);
        }

        //PAGE ELEMENTS

        public By ACCOUNT_BLOCK = By.XPath("//div[@class='account']");
        public By DEPARTMENT_DROPDOWN = By.XPath("//div[@class='select-simple']/select");
        public By LOGOUT_ICON = By.XPath("//div[@id='menu-down-icon']");
        public By LOGOUT_LINK = By.XPath("//a[text()='Uitloggen']");



        //PAGE METHODS

        public bool isDepartmentDropdownPresentOnPage()
        {
            return (drv.FindElements(DEPARTMENT_DROPDOWN).Count > 0);
        }

        public void LogOut()
        {
            WaitUntilElementIsClickable(LOGOUT_ICON);
            Click(LOGOUT_ICON);
            WaitUntilElementIsVisible(LOGOUT_LINK);
            Click(LOGOUT_LINK);
        }

        public void SelectDepartmentByDepartmentName(string departmentName)
        {
            SelectByNameInDropDown(DEPARTMENT_DROPDOWN, departmentName);
            Wait(2);
        }
    }
}
