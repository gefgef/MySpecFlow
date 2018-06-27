using System;
using System.Configuration;
using TechTalk.SpecFlow;
using NUnit.Framework;

using MySpecFlow.Helpers;

namespace MySpecFlow.StepDefinitions
{
    [Binding]
    class NavigationStepDefs : GenericStepDefs
    {

        private WebDriver wbdrv;

        public NavigationStepDefs(WebDriver webDriver) : base(webDriver)
        {
            wbdrv = webDriver;
        }

        private string department;

        [Then(@"Another department is displayed")]
        public void ThenAnotherDepartmentIsDisplayed()
        {
            Assert.True(Support().isTextPresentOnPage(
                (string)ScenarioContext.Current["department"]), "DEPARTMENT WAS NOT CHANGED");
        }

        [StepDefinition(@"User choose department (.*) to display")]
        public void IChooseADepartmentToDisplay(string departmentNumber)
        {
            switch (departmentNumber)
            {
                case "department1":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department1");
                    break;
                case "department2":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department2");
                    break;
                case "department3":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department3");
                    break;
                case "department4":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department4");
                    break;
                case "department5":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department5");
                    break;
            }
            GetDashboardPage().SelectDepartmentByDepartmentName(department);
            ScenarioContext.Current.Add("department", department);
        }

        [Then(@"Department (.*) is displayed")]
        public void ThenDepartmentDepartmentIsDisplayed(string departmentNumber)
        {
            switch (departmentNumber)
            {
                case "department1":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department1");
                    break;
                case "department2":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department2");
                    break;
                case "department3":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department3");
                    break;
                case "department4":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department4");
                    break;
                case "department5":
                    department = ConfigurationManager.AppSettings.Get("multipleDepartmentUser.department5");
                    break;
            }
            Assert.True(Support().isTextPresentOnPage(department));
        }

    }
}
