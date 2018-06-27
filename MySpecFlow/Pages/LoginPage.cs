using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace MySpecFlow.Pages
{
    class LoginPage : Page
    {
        private IWebDriver drv;
        private WebDriverWait wait;

        public LoginPage (IWebDriver driver, WebDriverWait wait) : base (driver, wait)
        {
            drv = driver;
            this.wait = wait;
            PageFactory.InitElements(drv, this);
        }

        //PAGE ELEMENTS

        private string URL = ConfigurationManager.AppSettings.Get("tst-frontent.url") + "login";
        private string TITLE = "Mediq - medische voeding voorschrijven";

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement USERNAME_FIELD;

        [FindsBy(How = How.Id, Using = "password")]
        public  IWebElement PASSWORD_FIELD;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn--secondary btn--lq']")]
        public IWebElement LOGIN_BUTTON;

        public By LOGIN_BUTTON_XPATH = By.XPath("//button[@class='btn btn--secondary btn--lq']");

        public By DEPARTMENT_DROPDOWN = By.Id("choose");

        [FindsBy(How = How.XPath, Using = "//button[text()='Selecteer']")]
        public IWebElement SELECT_DEPARTMENT_BUTTON;

        public string LOGIN_ERROR_MESSAGE = "Er is een fout opgetreden bij het inloggen. Controleer uw gebruikersnaam en wachtwoord";

        //PAGE METHODS

        public void open()
        {
            drv.Navigate().GoToUrl(URL);
            Assert.AreEqual(drv.Title, TITLE, "EXPECTED PAGE WAS NOT OPENED");
        }

        public void login(string login, string pass)
        {
            type(USERNAME_FIELD, login);
            type(PASSWORD_FIELD, pass);
            click(LOGIN_BUTTON);
        }

        public void chooseFirstDepartment()
        {
            WaitUntilElementIsVisible(DEPARTMENT_DROPDOWN);
            SelectIndexInDropDown(DEPARTMENT_DROPDOWN, 1);
            click(SELECT_DEPARTMENT_BUTTON);
        }

        public string ChooseRandomDepartment()
        {
            WaitUntilElementIsVisible(DEPARTMENT_DROPDOWN);
            int size = drv.FindElements(By.XPath("//select[@id='choose']/option")).Count;
            int elementIndex = GetRandomInt(2, size);
            string elementText = drv.FindElement(By.XPath("//select[@id='choose']/option[" + elementIndex + "]")).Text;
            SelectIndexInDropDown(DEPARTMENT_DROPDOWN, elementIndex - 1);
            click(SELECT_DEPARTMENT_BUTTON);
            return elementText;
        }

    }
}
