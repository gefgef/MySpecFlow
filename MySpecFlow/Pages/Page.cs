using System.Collections.Generic;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MySpecFlow.Pages
{
    class Page
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public Page(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        //COMMON METHODS

        public void Click(By selector)
        {
            _driver.FindElement(selector).Click();
        }

        public void click(IWebElement element)
        {
            element.Click();
        }

        public void type(By selector, string text)
        {
            _driver.FindElement(selector).Clear();
            _driver.FindElement(selector).SendKeys(text);
        }

        public void type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public bool isTextPresentOnPage(string text)
        {
            IList<IWebElement> list = _driver.FindElements(By.XPath("//*[contains(text(),'" + text + "')]"));
            return (list.Count > 0);
        }

        public void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void WaitUntilElementIsVisible(By locator)
        {
            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void WaitUntilElementIsClickable(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void SelectValueInDropDown(By locator, string value)
        {
            SelectElement dropDown = new SelectElement(_driver.FindElement(locator));
            dropDown.SelectByValue(value);
        }

        public void SelectIndexInDropDown(By locator, int index)
        {
            SelectElement dropDown = new SelectElement(_driver.FindElement(locator));
            dropDown.SelectByIndex(index);
        }

        public void SelectIndexInDropDown(IWebElement element, int index)
        {
            SelectElement dropDown = new SelectElement(element);
            dropDown.SelectByIndex(index);
        }

        public void SelectByNameInDropDown(By locator, string name)
        {
            SelectElement dropDown = new SelectElement(_driver.FindElement(locator));
            dropDown.SelectByText(name);
        }

        public void SelectByNameInDropDown(IWebElement element, string name)
        {
            SelectElement dropDown = new SelectElement(element);
            dropDown.SelectByText(name);
        }

        public int GetRandomInt(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

    }
}