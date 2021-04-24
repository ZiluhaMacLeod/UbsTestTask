using OpenQA.Selenium;
using UbsTestTask.Core.Extensions;
using UbsTestTask.Core.UbsWebElementDefinition;
using UbsTestTask.Core.WebDriverFactory;

namespace UbsTestTask.Pages.UbsGlobal.WealthManagement
{
    public class GetInTouchPage
    {
        private readonly UbsSelectElement _howCanWeHelpYouSelect = new UbsSelectElement(By.Id("text1_sfcollection"));
        private readonly UbsSelectElement _iHaveOverEurOneMlnToInvestSelect = new UbsSelectElement(By.Id("text2_sfcollection"));
        private readonly UbsWebElement _pleaseSpecifyYourRequestTextBox = new UbsWebElement(By.Id("memo1"));
        private readonly UbsRadioButtonElement _titleMrsMsRadioButton = new UbsRadioButtonElement(By.XPath("//*[@id='gender_sfcollection_0']//parent::*"));
        private readonly UbsRadioButtonElement _titleMrRadioButton = new UbsRadioButtonElement(By.Id("//*[@id='gender_sfcollection_1']//parent::*"));
        private readonly UbsWebElement _firstNameTextBox = new UbsWebElement(By.Id("firstName"));
        private readonly UbsWebElement _lastNameTextBox = new UbsWebElement(By.Id("lastName"));
        private readonly UbsWebElement _emailTextBox = new UbsWebElement(By.Id("email"));
        private readonly UbsWebElement _phoneNumberTextBox = new UbsWebElement(By.Id("phoneNumber"));
        private readonly UbsSelectElement _countryOrRegionSelect = new UbsSelectElement(By.Id("domicile_sfcollection"));
        private readonly UbsCheckBoxElement _confirmationCheckBox = new UbsCheckBoxElement(By.XPath("//*[@type='checkbox' and contains(@id, 'confirmation')]//parent::*"));
        private readonly UbsWebElement _submitButton = new UbsWebElement(By.XPath("//*[@type='submit' and .//*[contains(text(),'Submit') or contains(text(),'Absenden')]]"));
        private readonly UbsWebElement _confirmationAlert = new UbsWebElement(By.XPath("//*[@role='alert' and contains(@class,'form__msg-is-success')]"));

        public void SelectHowCanWeHelpYou(string howCanWeHelpYou) => _howCanWeHelpYouSelect.SelectValue(howCanWeHelpYou);

        public void SelectDoIHaveOverEurOneMlnToInvest(string iHaveOverEurOneMlnToInvestSelect) =>
            _iHaveOverEurOneMlnToInvestSelect.SelectValue(iHaveOverEurOneMlnToInvestSelect);

        public void EnterPleaseSpecifyYourRequest(string specifyYourRequest) => _pleaseSpecifyYourRequestTextBox.SendKeys(specifyYourRequest);

        public void ChooseMrsMsTitle() => _titleMrsMsRadioButton.Check();

        public void ChooseMrTitle() => _titleMrRadioButton.Check();

        public void EnterFirstName(string firstName) => _firstNameTextBox.SendKeys(firstName);

        public void EnterLastName(string lastName) => _lastNameTextBox.SendKeys(lastName);

        public void EnterEmail(string email) => _emailTextBox.SendKeys(email);

        public void EnterPhoneNumber(string phoneNumber) => _phoneNumberTextBox.SendKeys(phoneNumber);

        public void SelectCountryOrRegion(string countryOrRegion)
        {
            _countryOrRegionSelect.ScrollElementToCenter();
            _countryOrRegionSelect.SelectValue(countryOrRegion);
        }

        public void ConfirmRequest()
        {
            _confirmationCheckBox.ScrollElementToCenter();
            _confirmationCheckBox.Check();
        }

        public void SubmitRequest() => _submitButton.Click();

        public void WaitTillRequestIsSubmitted() => ContextProvider.WebDriver.GetWait().Until(x => _submitButton.IsRemoved());

        public bool IsConfirmationAlertPresent() => _confirmationAlert.IsPresent() && _confirmationAlert.Displayed;
    }
}
