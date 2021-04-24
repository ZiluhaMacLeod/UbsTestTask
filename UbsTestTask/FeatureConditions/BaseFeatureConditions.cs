using TechTalk.SpecFlow;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.FeatureConditions
{
    [Binding]
    public class BaseFeatureConditions
    {
        [BeforeFeature("InitializeDriver", Order = 1)]
        public static void InitializeDriver()
        {
            ContextProvider.StartWebDriver();
        }

        [AfterFeature("StopDriver")]
        public static void StopDriver()
        {
            ContextProvider.StopWebDriver();
        }
    }
}
