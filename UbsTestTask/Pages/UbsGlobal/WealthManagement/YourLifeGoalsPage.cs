using OpenQA.Selenium;
using UbsTestTask.Core.Extensions;
using UbsTestTask.Core.UbsWebElementDefinition;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.Pages.UbsGlobal.WealthManagement
{
    public class YourLifeGoalsPage
    {
        private readonly UbsWebElement _getInTouchButton = new UbsWebElement(By.XPath("//div[@id]/a[contains(@href,'get-in-touch')]"));

        public GetInTouchPage OpenGetInTouchPage()
        {
            ContextProvider.WebDriver.GetWait().Until(x =>
            {
                if (_getInTouchButton.IsPresent())
                {
                    _getInTouchButton.Click();
                }

                return !_getInTouchButton.IsPresent();
            });

            return new GetInTouchPage();
        }
    }
}
