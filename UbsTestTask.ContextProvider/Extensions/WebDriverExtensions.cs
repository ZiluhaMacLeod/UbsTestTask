using System;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UbsTestTask.Constants.Constants;

namespace UbsTestTask.Core.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement GetElementWhenExists(this IWebDriver driver, By locator)
        {
            IWebElement element;

            try
            {
                var wait = driver.GetWait(
                    exceptionTypes: new[]
                    {
                        typeof(NoSuchElementException),
                        typeof(TargetInvocationException),
                        typeof(InvalidOperationException),
                        typeof(StaleElementReferenceException)
                    });
                wait.IgnoreExceptionTypes();

                wait.Until(drv =>
                {
                    if (drv.FindElements(locator).Count == 0)
                    {
                        return false;
                    }

                    var previousElementState = drv.FindElements(locator).FirstOrDefault();
                    var nextElementState = drv.FindElements(locator).FirstOrDefault();

                    return previousElementState != null && nextElementState != null && previousElementState.Equals(nextElementState);
                });

                element = driver.FindElement(locator);
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new WebDriverTimeoutException(
                    $"The element with '{locator}' locator was not found during '{ExplicitWaitConstants.DefaultTimeout}' seconds. \n {exception.InnerException?.Message ?? exception.Message}",
                    exception.InnerException ?? exception);
            }

            return element;
        }

        public static WebDriverWait GetWait(
            this IWebDriver driver,
            TimeSpan timeout = default,
            TimeSpan pollingInterval = default,
            Type[] exceptionTypes = null)
        {
            var wait = new WebDriverWait(driver, timeout.Ticks == 0 ? ExplicitWaitConstants.DefaultTimeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? ExplicitWaitConstants.DefaultPollingInterval : pollingInterval
            };

            wait.IgnoreExceptionTypes(exceptionTypes ?? new[] { typeof(StaleElementReferenceException) });

            return wait;
        }
    }
}
