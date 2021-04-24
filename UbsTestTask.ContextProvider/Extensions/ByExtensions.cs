using System;
using OpenQA.Selenium;

namespace UbsTestTask.Core.Extensions
{
    public static class ByExtension
    {
        public static string GetLocator(this By selector)
        {
            var selectorFullLocator = selector.ToString();

            return selectorFullLocator.Substring(selectorFullLocator.IndexOf(" ", StringComparison.InvariantCultureIgnoreCase) + 1);
        }
    }
}
