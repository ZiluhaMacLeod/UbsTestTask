using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UbsTestTask.Core.WebDriverFactory
{
    public class WebDriverFactory
    {
        public static T GetWebDriver<T>() where T : IWebDriver, new()
        {
            object[] parameters;

            if (typeof(T) == typeof(ChromeDriver))
            {
                var chromeOptions = GetDefaultChromeOptions();
                parameters = new object[] { chromeOptions };
            }
            else if (typeof(T) == typeof(FirefoxDriver))
            {
                FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                geckoService.Host = "::1";
                parameters = new object[] { geckoService };
            }
            else
            {
                throw new NotSupportedException($"Unsupported type of web driver: {typeof(T).Name}.");
            }

            return (T)Activator.CreateInstance(typeof(T), parameters);
        }

        private static ChromeOptions GetDefaultChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);

            return chromeOptions;
        }
    }
}
