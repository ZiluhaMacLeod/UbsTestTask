using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Core.WebDriverFactory;
using UbsTestTask.Pages.UbsGlobal;

namespace UbsTestTask.Tests.UbsGlobal
{
    [Binding]
    public class LanguageSwitchSteps
    {
        [Given(@"I have checked that current language is (.*)")]
        public void GivenIHaveCheckedThatCurrentLanguageIsLanguage(string language)
        {
            Assert.IsTrue(ContextProvider.WebDriver.Url.Contains(language.ToLower()));
            var languagePossibleToSwitchFor = UbsGlobalGenericPages.MainPage.GetLanguagePossibleToSwitchFor();
            switch (language)
            {
                case UbsGlobalMainPageLanguages.Deutsch:
                    Assert.AreEqual(UbsGlobalMainPageLanguages.English.ToUpper(), languagePossibleToSwitchFor);
                    break;
                case UbsGlobalMainPageLanguages.English:
                    Assert.AreEqual(UbsGlobalMainPageLanguages.Deutsch.ToUpper(), languagePossibleToSwitchFor);
                    break;
                default:
                    throw new ArgumentException($"{language} language is not supported");
            }
        }

        [When(@"I switched to the (.*)")]
        public void WhenISwitchedToTheLanguage(string language)
        {
            switch (language)
            {
                case UbsGlobalMainPageLanguages.Deutsch:
                    UbsGlobalGenericPages.MainPage.ChangeLanguageToDeutsch();
                    break;
                case UbsGlobalMainPageLanguages.English:
                    UbsGlobalGenericPages.MainPage.ChangeLanguageToEnglish();
                    break;
                default:
                    throw new ArgumentException($"{language} language is not supported");
            }
        }

        [Then(@"I check that header elements are written in (.*) now")]
        public void ThenICheckThatHeaderElementsWrittenInLanguageNow(string language)
        {
            var headerTitle = UbsGlobalGenericPages.MainPage.GetHeaderTitle();
            var domicileDropdownButtonText = UbsGlobalGenericPages.MainPage.GetDomicileDropdownButtonText();
            var locationsButtonText = UbsGlobalGenericPages.MainPage.GetLocationsButtonText();
            switch (language)
            {
                case UbsGlobalMainPageLanguages.Deutsch:
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual("Globale Themen", headerTitle);
                        Assert.AreEqual("Domizil wählen", domicileDropdownButtonText);
                        Assert.AreEqual("Standorte", locationsButtonText);
                    });
                    break;
                case UbsGlobalMainPageLanguages.English:
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual("Global", headerTitle);
                        Assert.AreEqual("Select domicile", domicileDropdownButtonText);
                        Assert.AreEqual("Locations", locationsButtonText);
                    });
                    break;
                default:
                    throw new ArgumentException($"{language} language is not supported");
            }
        }

        [Then(@"tab elements are written in (.*) now")]
        public void ThenTabElementsAreWrittenInLanguageNow(string language)
        {
            var wealthManagementButtonText = UbsGlobalGenericPages.MainPage.GetWealthManagementButtonText();
            var assetManagementButtonText = UbsGlobalGenericPages.MainPage.GetAssetManagementButtonText();
            var investmentBankButtonText = UbsGlobalGenericPages.MainPage.GetInvestmentBankButtonText();
            var aboutUsButtonText = UbsGlobalGenericPages.MainPage.GetAboutUsButtonText();
            var careersButtonText = UbsGlobalGenericPages.MainPage.GetCareersButtonText();
            switch (language)
            {
                case UbsGlobalMainPageLanguages.Deutsch:
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual("Vermögensverwaltung", wealthManagementButtonText);
                        Assert.AreEqual("Anlagenmanagement", assetManagementButtonText);
                        Assert.AreEqual("Investmentbank", investmentBankButtonText);
                        Assert.AreEqual("Wir über uns", aboutUsButtonText);
                        Assert.AreEqual("Karriere", careersButtonText);
                    });
                    break;
                case UbsGlobalMainPageLanguages.English:
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual("Wealth Management", wealthManagementButtonText);
                        Assert.AreEqual("Asset Management", assetManagementButtonText);
                        Assert.AreEqual("Investment Bank", investmentBankButtonText);
                        Assert.AreEqual("About us", aboutUsButtonText);
                        Assert.AreEqual("Careers", careersButtonText);
                    });
                    break;
                default:
                    throw new ArgumentException($"{language} language is not supported");
            }
        }
    }
}
