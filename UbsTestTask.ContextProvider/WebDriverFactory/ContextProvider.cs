using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Constants.Enums;

namespace UbsTestTask.Core.WebDriverFactory
{
    public class ContextProvider
    {
        public static IWebDriver WebDriver { get; set; }

        public static void StartWebDriver(string url = default)
        {
            switch (TestSettings.Browser)
            {
                case Browsers.Chrome:
                    WebDriver = WebDriverFactory.GetWebDriver<ChromeDriver>();
                    break;

                case Browsers.FireFox:
                    WebDriver = WebDriverFactory.GetWebDriver<FirefoxDriver>();
                    break;

                default:
                    throw new WebDriverException("Web driver instance not initialized");
            }

            if (url == default)
            {
                url = TestSettings.UbsGlobalBaseUrl;
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(url);
        }

        public static void StopWebDriver()
        {
            WebDriver.Quit();
            WebDriver = null;
        }
    }
}
