using OpenQA.Selenium;
using UbsTestTask.Core.UbsWebElementDefinition;

namespace UbsTestTask.Pages.UbsGlobal.UbsLogins
{
    public class UbsEbankingSwitzerlandPage
    {
        private readonly UbsWebElement _contractNumberTextBox = new UbsWebElement(By.Name("isiwebuserid"));
        private readonly UbsWebElement _continueButton = new UbsWebElement(By.Id("AuthGetContractNrDialog_submit"));
        private readonly UbsWebElement _warningTextLabel = new UbsWebElement(By.XPath("(//*[@data-type='warning']//*[text()])[last()]"));

        public void EnterContractNumber(string contractNumber) => _contractNumberTextBox.SendKeys(contractNumber);

        public void ClickContinueButton() => _continueButton.Click();

        public bool IsWarningDisplayed() => _warningTextLabel.Displayed;

        public string GetWarningText() => _warningTextLabel.Text;
    }
}
