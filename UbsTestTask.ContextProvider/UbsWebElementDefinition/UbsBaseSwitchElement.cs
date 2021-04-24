using OpenQA.Selenium;
using UbsTestTask.Core.Extensions;

namespace UbsTestTask.Core.UbsWebElementDefinition
{
    public class UbsBaseSwitchElement : UbsWebElement
    {
        private UbsWebElement Label => new UbsWebElement(By.XPath($"{Selector.GetLocator()}/label"));
        private UbsWebElement Input => new UbsWebElement(By.XPath($"{Selector.GetLocator()}/input"));
        public UbsBaseSwitchElement(By by) : base(by)
        {
        }

        public void Check()
        {
            if (!Input.Selected)
            {
                Label.Click();
            }
        }

        public void UnCheck()
        {
            if (Input.Selected)
            {
                Label.Click();
            }
        }
    }
}
