using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class SignUp : BasePageObject
    {
        public SignUp(IWebDriver driver) : base(driver)
        { 
        }

        [FindsBy(How = How.Id, Using = "id_email")]
        private IWebElement EmailIdInputField { get; set; }

        [FindsBy(How = How.Id, Using = "id_password1")]
        private IWebElement PasswordIdInputField { get; set; }

        [FindsBy(How = How.Id, Using = "id_password2")]
        private IWebElement ConfirmPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "id_subscribe_to_newsletter")]
        private IWebElement SubscribeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "id_accepted_privacy_policy")]
        private IWebElement AcceptPolicyCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='registration-form']/div[6]/button")]
        private IWebElement CreateAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Email Sent')]")]
        private IWebElement ConfirmationMessage { get; set; }

        public void EnterEmail(string email)
        {
            TypeInto(EmailIdInputField, email, "Email Input Field");
        }

        public void EnterPassword(string password)
        {
            TypeInto(PasswordIdInputField, password, "Email Input Field");
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            TypeInto(ConfirmPasswordField, confirmPassword, "Email Input Field");
        }

        public void ClickSubscribeCheckbox()
        {
            ClickElement(SubscribeCheckbox, "Subscribe Checkbox");
        }

        public void ClickAcceptCheckbox()
        {
            ClickElement(AcceptPolicyCheckbox, "Accept Policy Checkbox");
        }

        public void ClickCreateAccountButton()
        {
            ClickElement(CreateAccountButton, "Create Account Button");
        }

        public bool IsConfirmationMessageDisplayed()
        {
            return IsElementDisplayed(ConfirmationMessage, "Confirmation message");
        }    
    }
}
