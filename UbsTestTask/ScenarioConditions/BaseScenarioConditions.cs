using TechTalk.SpecFlow;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.ScenarioConditions
{
    [Binding]
    public class BaseScenarioConditions
    {
        [BeforeScenario("OpenUbsGlobalDe", Order = 2)]
        public void OpenUbsGlobalDe() => OpenUbsGlobalWithExpectedLanguage(UbsGlobalMainPageLanguages.Deutsch);

        [BeforeScenario("OpenUbsGlobalEn", Order = 2)]
        public void OpenUbsGlobalEn() => OpenUbsGlobalWithExpectedLanguage(UbsGlobalMainPageLanguages.English);

        [BeforeScenario(Order = 1)]
        public void ReopenBasePage() => ContextProvider.WebDriver.Navigate().GoToUrl(TestSettings.UbsGlobalBaseUrl);

        private void OpenUbsGlobalWithExpectedLanguage(string language) =>
            ContextProvider.WebDriver.Navigate().GoToUrl(string.Format(TestSettings.UbsGlobalBaseUrlBase, language.ToLower()));
    }
}
