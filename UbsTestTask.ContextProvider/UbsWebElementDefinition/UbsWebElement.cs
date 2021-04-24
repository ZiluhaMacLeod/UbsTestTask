using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Core.Extensions;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.Core.UbsWebElementDefinition
{
    public class UbsWebElement : IWebElement
    {
        private readonly By _by;
        private IWebElement WebElement => ContextProvider.WebDriver.GetElementWhenExists(_by);
        public string TagName => WebElement.TagName;
        public string Text => WebElement.Text;
        public bool Enabled => WebElement.Enabled;
        public bool Selected => WebElement.Selected;
        public Point Location => WebElement.Location;
        public Size Size => WebElement.Size;
        public bool Displayed => WebElement.Displayed;
        public By Selector => _by;

        public UbsWebElement(By by)
        {
            _by = by;
        }

        public IWebElement FindElement(By by) => GetElementWhenExists(by);

        public IWebElement GetIWebElement() => WebElement;

        public ReadOnlyCollection<IWebElement> FindElements(By by) => WebElement.FindElements(by);

        public void Clear() => WebElement.Clear();

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();

        public void Click() => ContextProvider.WebDriver
            .GetWait(exceptionTypes: new[] { typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException) })
            .Until(drv =>
            {
                WebElement.Click();

                return true;
            });

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetProperty(string propertyName) => WebElement.GetProperty(propertyName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public bool IsPresent(int timeout = 3000) => IsExists(timeout, true);

        public bool IsRemoved(int timeout = 3000) => IsExists(timeout, false);

        public void WaitForElementIsEnabled(int? timeout = null) => ContextProvider.WebDriver
            .GetWait(timeout == null ? ExplicitWaitConstants.DefaultTimeout : TimeSpan.FromMilliseconds((int)timeout))
            .Until(drv => IsPresent(1) && WebElement.Enabled);

        protected IWebElement GetElementWhenExists(By locator) => ContextProvider.WebDriver.GetElementWhenExists(locator);

        private bool IsExists(int timeout, bool shouldExist) => IsExists(TimeSpan.FromMilliseconds(timeout), shouldExist);

        private bool IsExists(TimeSpan timeout, bool shouldExist)
        {
            try
            {
                WaitForElementExistence(timeout, shouldExist: shouldExist);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void WaitForElementExistence(TimeSpan? timeout = null, TimeSpan? pollingInterval = null, bool shouldExist = true) =>
            ContextProvider.WebDriver.GetWait(timeout ?? ExplicitWaitConstants.DefaultTimeout, pollingInterval ?? ExplicitWaitConstants.DefaultPollingInterval)
                .Until(drv => drv.FindElements(_by).Count != 0 == shouldExist);

        public void ScrollElementToCenter() =>
            ((IJavaScriptExecutor)ContextProvider.WebDriver).ExecuteScript("arguments[0].scrollIntoView({inline: \"center\"});", WebElement);
    }
}
