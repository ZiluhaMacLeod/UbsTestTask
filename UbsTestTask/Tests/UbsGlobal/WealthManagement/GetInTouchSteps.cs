using NUnit.Framework;
using TechTalk.SpecFlow;
using UbsTestTask.Constants.UbsGlobal.WealthManagement.GetInTouch;
using UbsTestTask.Core.Helpers;
using UbsTestTask.Pages.UbsGlobal;

namespace UbsTestTask.Tests.UbsGlobal.WealthManagement
{
    [Binding]
    public class GetInTouchSteps
    {
        [Given(@"I have navigated to the Wealth Management Your Life Goals")]
        public void GivenIHaveNavigatedToTheWealthManagementYourLifeGoals()
        {
            UbsGlobalGenericPages.MainPage.OpenYourLifeGoalsPage();
        }

        [Given(@"I have clicked Get in touch button")]
        public void GivenIHaveClickedGetInTouchButton()
        {
            UbsGlobalGenericPages.YourLifeGoalsPage.OpenGetInTouchPage();
        }

        [When(@"I have filled Your request")]
        public void WhenIHaveFilledYourRequest()
        {
            UbsGlobalGenericPages.GetInTouchPage.SelectHowCanWeHelpYou(HowCanWeHelpYouOptions.InternationalBanking);
            UbsGlobalGenericPages.GetInTouchPage.SelectDoIHaveOverEurOneMlnToInvest(IHaveOverOneMillionEuroToInvestOptions.Yes);
            UbsGlobalGenericPages.GetInTouchPage.EnterPleaseSpecifyYourRequest(RandomHelper.GetRandomString(15));
        }

        [When(@"I have filled Your details")]
        public void WhenIHaveFilledYourDetails()
        {
            UbsGlobalGenericPages.GetInTouchPage.ChooseMrsMsTitle();
            UbsGlobalGenericPages.GetInTouchPage.EnterFirstName(RandomHelper.GetRandomString(10));
            UbsGlobalGenericPages.GetInTouchPage.EnterLastName(RandomHelper.GetRandomString(10));
            UbsGlobalGenericPages.GetInTouchPage.EnterEmail(RandomHelper.GetRandomEmail());
            UbsGlobalGenericPages.GetInTouchPage.EnterPhoneNumber($"+{RandomHelper.GetRandomInt(11111111)}");
            UbsGlobalGenericPages.GetInTouchPage.SelectCountryOrRegion(CountryOrRegionOptions.Algeria);
        }

        [Then(@"I have confirmed and submitted request")]
        public void ThenIHaveConfirmedAndSubmittedRequest()
        {
            UbsGlobalGenericPages.GetInTouchPage.ConfirmRequest();
            UbsGlobalGenericPages.GetInTouchPage.SubmitRequest();
            UbsGlobalGenericPages.GetInTouchPage.WaitTillRequestIsSubmitted();
        }

        [Then(@"I have seen the confirmation")]
        public void ThenIHaveSeenTheConfirmation()
        {
            Assert.IsTrue(UbsGlobalGenericPages.GetInTouchPage.IsConfirmationAlertPresent(), "Confirmation alert is not present");
        }
    }
}
