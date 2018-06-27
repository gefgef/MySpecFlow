using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MySpecFlow.Helpers
{
    class WebDriver
    {
        private IWebDriver _driver;
        public IWebDriver driver
        {
            get
            {
                if (_driver != null)
                    return _driver;

                Console.WriteLine("Started at " + DateTime.Now.ToString("h:mm:ss"));
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                return _driver;
            }
        }

        private WebDriverWait _wait;
        public WebDriverWait wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                }
                return _wait;
            }
        }

        public void TearDown()
        {
            _driver.Quit();
            Console.WriteLine("Finished at " + DateTime.Now.ToString("h:mm:ss"));
        }
    }
}
