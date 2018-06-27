using System;
using System.Configuration;
using TechTalk.SpecFlow;
using NUnit.Framework;

using MySpecFlow.Helpers;

namespace MySpecFlow.StepDefinitions
{
    [Binding]
    class LoginStepDefs : GenericStepDefs
    {

        private WebDriver wbdrv;

        public LoginStepDefs (WebDriver webDriver) : base (webDriver)
        {
            wbdrv = webDriver;
        }

        [Given(@"User connected to one department")]
        public void GivenUserConnectedToOneDepartment()
        {
            string login = ConfigurationManager.AppSettings.Get("defaultUser.login");
            string pass = ConfigurationManager.AppSettings.Get("defaultUser.pass");
            string name = ConfigurationManager.AppSettings.Get("defaultUser.name");
            ScenarioContext.Current.Add("login", login);
            ScenarioContext.Current.Add("pass", pass);
            ScenarioContext.Current.Add("name", name);
        }

        [Given(@"User connected to few departments")]
        public void GivenUserConnectedToFewDepartments()
        {
            string login = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.login");
            string pass = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.pass");
            string name = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.name");
            ScenarioContext.Current.Add("login", login);
            ScenarioContext.Current.Add("pass", pass);
            ScenarioContext.Current.Add("name", name);
        }

        [Given(@"User with invalid password")]
        public void GivenUserWithInvalidPassword()
        {
            ScenarioContext.Current.Add("login", ConfigurationManager.AppSettings.Get("defaultUser.login"));
            ScenarioContext.Current.Add("pass", "Invalidpass123");
            ScenarioContext.Current.Add("name", ConfigurationManager.AppSettings.Get("defaultUser.name"));
        }

        [Given(@"User with invalid username and password")]
        public void GivenUserWithInvalidUsernameAndPassword()
        {
            ScenarioContext.Current.Add("login", "InvalidUser123");
            ScenarioContext.Current.Add("pass", "Invalidpass123");
            ScenarioContext.Current.Add("name", ConfigurationManager.AppSettings.Get("defaultUser.name"));
        }


        [When(@"User connected to one department logs in")]
        public void WhenUserLogin()
        {
            GetLoginPage().open();
            GetLoginPage().login((string)ScenarioContext.Current["login"], (string)ScenarioContext.Current["pass"]);
            //Support().WaitUntilElementIsVisible(getDashboardPage().ACCOUNT_BLOCK);
        }

        [StepDefinition(@"User connected to few departments logs in")]
        public void WhenUserConnectedToFewDepartmentsLogin()
        {
            GetLoginPage().open();
            GetLoginPage().login((string)ScenarioContext.Current["login"], (string)ScenarioContext.Current["pass"]);
            Support().WaitUntilElementIsVisible(GetLoginPage().DEPARTMENT_DROPDOWN);
        }

        [StepDefinition(@"User choose first department on login page")]
        public void UserChooseFirstDepartment()
        {
            GetLoginPage().chooseFirstDepartment();
            Support().WaitUntilElementIsVisible(GetDashboardPage().ACCOUNT_BLOCK);
        }

        [StepDefinition(@"User choose a random department to display")]
        public void WhenUserChooseARandomDepartmentToDisplay()
        {
            string department = GetLoginPage().ChooseRandomDepartment();
            ScenarioContext.Current.Add("department", department);
        }

        [StepDefinition(@"User successfully logged in")]
        public void ThenUserSuccessfullyLoggedIn()
        {
            Support().WaitUntilElementIsVisible(GetDashboardPage().ACCOUNT_BLOCK);
            Assert.True(Support().isTextPresentOnPage(
                (string)ScenarioContext.Current["name"]), "USER WAS NOT LOGGED IN");
        }

        [StepDefinition(@"User is connected to only one department")]
        public void UserHasOnlyOneDepartmentWhichIsNotDisplayed()
        {
            bool temp = GetDashboardPage().isDepartmentDropdownPresentOnPage();
            Assert.False(GetDashboardPage().isDepartmentDropdownPresentOnPage(), "USER IS CONNECTED TO FEW DEPARTMENTS");
        }

        [StepDefinition(@"User is connected to few departments")]
        public void UserHasFewDepartments()
        {
            Assert.True(GetDashboardPage().isDepartmentDropdownPresentOnPage(), "USER IS CONNECTED TO FEW DEPARTMENTS");
        }

        [Then(@"User logs out")]
        public void UserLogsOut()
        {
            GetDashboardPage().LogOut();
        }

        [Then(@"User is not logged in")]
        public void UserIsNotLoggedIn()
        {
            Support().WaitUntilElementIsVisible(GetLoginPage().LOGIN_BUTTON_XPATH);
            Assert.True(driver.Url.Contains("login"));
            Assert.False(Support().isTextPresentOnPage(
                (string)ScenarioContext.Current["name"]), "USER WAS NOT LOGGED OUT");
        }

        [StepDefinition(@"User Dashboard page opened for selected department")]
        public void ThenUserDashboardPageOpenedForSelectedDepartment()
        {
            Assert.True(Support().isTextPresentOnPage(
                (string)ScenarioContext.Current["department"]), "DASHBOARD WAS OPENED FOR WRONG DEPARTMENT");
        }

        [Then(@"User see sign in error message")]
        public void ThenISeeSignInErrorMessage()
        {
            Assert.True(Support().isTextPresentOnPage(GetLoginPage().LOGIN_ERROR_MESSAGE), "NO ERROR MESSAGE ON PAGE");
        }

        [StepDefinition(@"User connected to one department logs in via API call")]
        public void UserConnectedToOneDepartmentLogsInViaAPICall()
        {
            string[] tokenAndSessionId = ApiSupport.LoginAndGetAccessTokenSessionId((string)ScenarioContext.Current["login"], (string)ScenarioContext.Current["pass"]);
            ScenarioContext.Current.Add("accessToken", tokenAndSessionId[0]);
            ScenarioContext.Current.Add("sessionId", tokenAndSessionId[1]);
        }

        [When(@"Test test test")]
        public void WhenTestTestTest()
        {
            string test = WebClientSupport.getPagesContent("https://tst-medischevoeding.mediq.nl/");
            Console.Write("");
        }


    }
}
