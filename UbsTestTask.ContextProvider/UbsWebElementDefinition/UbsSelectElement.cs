using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UbsTestTask.Core.Extensions;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.Core.UbsWebElementDefinition
{
    public class UbsSelectElement : UbsWebElement
    {
        private SelectElement SelectElement => new SelectElement(GetIWebElement());

        public UbsSelectElement(By by) : base(by)
        {
        }

        public void SelectValue(string value) => ContextProvider.WebDriver.GetWait()
            .Until(drv =>
            {
                SelectElement.SelectByText(value);

                return true;
            });
    }
}
