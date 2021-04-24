using System.Linq;
using OpenQA.Selenium;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Core.Extensions;
using UbsTestTask.Core.Helpers;
using UbsTestTask.Core.UbsWebElementDefinition;
using UbsTestTask.Pages.UbsGlobal.UbsLogins;
using UbsTestTask.Pages.UbsGlobal.WealthManagement;

namespace UbsTestTask.Pages.UbsGlobal
{
    public class MainPage
    {
        private const string MainMenuBaseXpath =
            "//*[@id='mainmenu']//button[contains(text(),'{0}') or contains(text(),'{1}')]";

        private readonly UbsWebElement _selectYourLanguageButton =
            new UbsWebElement(By.XPath("//li[@aria-label='Select your language']"));

        private readonly UbsWebElement _headerTitleSpanWithText =
            new UbsWebElement(By.CssSelector(".header__title span"));

        private readonly UbsWebElement _domicileDropdownButton = new UbsWebElement(By.Id("domicileButton"));

        private readonly UbsWebElement _locationsButton =
            new UbsWebElement(By.XPath(
                "//*[@id='metanavigation']//a[contains(text(),'Locations') or contains(text(),'Standorte')]"));

        private readonly UbsWebElement _wealthManagementMainMenuButton =
            new UbsWebElement(By.XPath(string.Format(MainMenuBaseXpath, "Wealth Management", "Vermögensverwaltung")));

        private readonly UbsWebElement _assetManagementMainMenuButton =
            new UbsWebElement(By.XPath(string.Format(MainMenuBaseXpath, "Asset Management", "Anlagenmanagement")));

        private readonly UbsWebElement _investmentBankMainMenuButton =
            new UbsWebElement(By.XPath(string.Format(MainMenuBaseXpath, "Investment Bank", "Investmentbank")));

        private readonly UbsWebElement _aboutUsMainMenuButton =
            new UbsWebElement(By.XPath(string.Format(MainMenuBaseXpath, "About us", "Wir über uns")));

        private readonly UbsWebElement _careersMainMenuButton =
            new UbsWebElement(By.XPath(string.Format(MainMenuBaseXpath, "Careers", "Karriere")));

        private readonly UbsWebElement _ubsLoginsButton = new UbsWebElement(By.XPath("//*[@id='headerLoginToggleButton']"));

        private UbsWebElement SelectYourLanguageLinkWithText =>
            new UbsWebElement(By.XPath($"{_selectYourLanguageButton.Selector.GetLocator()}//*[@lang]"));

        public void ChangeLanguageToDeutsch()
        {
            if (GetLanguagePossibleToSwitchFor() == UbsGlobalMainPageLanguages.Deutsch.ToUpper())
            {
                _selectYourLanguageButton.Click();
            }
        }

        public void ChangeLanguageToEnglish()
        {
            if (GetLanguagePossibleToSwitchFor() == UbsGlobalMainPageLanguages.English.ToUpper())
            {
                _selectYourLanguageButton.Click();
            }
        }

        public string GetLanguagePossibleToSwitchFor() => SelectYourLanguageLinkWithText.Text;

        public string GetHeaderTitle() => _headerTitleSpanWithText.Text;

        public string GetDomicileDropdownButtonText() => _domicileDropdownButton.Text;

        public string GetLocationsButtonText() => _locationsButton.Text;

        public string GetWealthManagementButtonText() => _wealthManagementMainMenuButton.Text;

        public string GetAssetManagementButtonText() => _assetManagementMainMenuButton.Text;

        public string GetInvestmentBankButtonText() => _investmentBankMainMenuButton.Text;

        public string GetAboutUsButtonText() => _aboutUsMainMenuButton.Text;

        public string GetCareersButtonText() => _careersMainMenuButton.Text;

        public YourLifeGoalsPage OpenYourLifeGoalsPage() =>
            OpenMainMenuTab<YourLifeGoalsPage>(_wealthManagementMainMenuButton, "Your life goals", "Ihre Ziele");

        public UbsEbankingSwitzerlandPage OpenUbsEbankingSwitzerlandPage() =>
            OpenUbsLoginsTab<UbsEbankingSwitzerlandPage>("UBS E-Banking Switzerland", "UBS E-Banking in der Schweiz");

        private T OpenMainMenuTab<T>(UbsWebElement ubsMainMenuWebElement, params string[] tabItemNames) where T : new()
        {
            var tabItem =
                new UbsWebElement(
                    By.XPath(
                        $"{ubsMainMenuWebElement.Selector.GetLocator()}//following-sibling::div//a[{XpathHelper.CombineFewTextPartsInOneWithOr(tabItemNames)}]"));

            return OpenTab<T>(ubsMainMenuWebElement, tabItem);
        }

        private T OpenUbsLoginsTab<T>(params string[] tabItemNames) where T : new()
        {
            var tabItem =
                new UbsWebElement(
                    By.XPath(
                        $"{_ubsLoginsButton.Selector.GetLocator()}//following-sibling::ul//*[{XpathHelper.CombineFewTextPartsInOneWithOr(tabItemNames)}]"));

            return OpenTab<T>(_ubsLoginsButton, tabItem);
        }

        private T OpenTab<T>(UbsWebElement ubsMainMenuWebElement, UbsWebElement tabItem) where T : new()
        {
            ubsMainMenuWebElement.Click();
            tabItem.WaitForElementIsEnabled();
            tabItem.Click();

            return new T();
        }
    }
}
