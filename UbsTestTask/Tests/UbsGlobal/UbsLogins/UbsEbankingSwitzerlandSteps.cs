using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UbsTestTask.Constants.Constants;
using UbsTestTask.Core.Helpers;
using UbsTestTask.Pages.UbsGlobal;

namespace UbsTestTask.Tests.UbsGlobal.UbsLogins
{
    [Binding]
    public class UbsEbankingSwitzerlandSteps
    {
        [Given(@"I have navigated to the UBS E-Banking Switzerland")]
        public void GivenIHaveNavigatedToTheUbsEBankingSwitzerland()
        {
            UbsGlobalGenericPages.MainPage.OpenUbsEbankingSwitzerlandPage();
        }

        [When(@"I have entered wrong contract number")]
        public void WhenIHaveEnteredWrongContractNumber()
        {
            UbsGlobalGenericPages.UbsEbankingSwitzerlandPage.EnterContractNumber(RandomHelper.GetRandomString(9));
        }

        [When(@"I have clicked Continue")]
        public void WhenIHaveClickedContinue()
        {
            UbsGlobalGenericPages.UbsEbankingSwitzerlandPage.ClickContinueButton();
        }

        [Then(@"I have seen the message that contract number is incorrect")]
        public void ThenIHaveSeenTheMessageThatContractNumberIsIncorrect()
        {
            Assert.IsTrue(UbsGlobalGenericPages.UbsEbankingSwitzerlandPage.IsWarningDisplayed(), "Warning message is not displayed");
            var warningText = UbsGlobalGenericPages.UbsEbankingSwitzerlandPage.GetWarningText();
            switch (TestSettings.UbsGlobalLanguage)
            {
                case UbsGlobalMainPageLanguages.English:
                    Assert.AreEqual("Unknown contract number, please repeat entry.", warningText);
                    break;
                case UbsGlobalMainPageLanguages.Deutsch:
                    Assert.AreEqual("Die Vertragsnummer ist unbekannt. Überprüfen und korrigieren Sie die Eingabe.", warningText);
                    break;
                default:
                    throw new ArgumentException($"{TestSettings.UbsGlobalLanguage} language is not supported");
            }
        }
    }
}
