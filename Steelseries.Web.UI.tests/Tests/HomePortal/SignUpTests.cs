using NUnit.Framework;
using NUnit.Framework.Internal;
using Steelseries.Web.UI.tests.PageObjects;
using System;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class SignUpTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldSignUp()
        {
            DateTime date = DateTime.Now;
            long uniqueNumber = ((DateTimeOffset)date).ToUnixTimeSeconds();

            Home.ClickSignUpButton();
            Home.SignUp.EnterEmail($"test@gmail.com{uniqueNumber}");
            Home.SignUp.EnterPassword("[]s_^9g[y/;X/_:k");
            Home.SignUp.EnterConfirmPassword("[]s_^9g[y/;X/_:k");
            Home.SignUp.ClickSubscribeCheckbox();
            Home.SignUp.ClickAcceptCheckbox();
            Home.SignUp.ClickCreateAccountButton();
            Assert.IsTrue(Home.SignUp.IsConfirmationMessageDisplayed(), "Confirmation message wasn't displayed");
        }
    }
}

