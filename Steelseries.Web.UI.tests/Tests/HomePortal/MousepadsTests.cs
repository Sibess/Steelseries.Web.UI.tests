using NUnit.Framework;
using NUnit.Framework.Internal;
using Steelseries.Web.UI.tests.PageObjects;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class Mousepads : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldShowValidMousePadSize()
        {
            Home.ClickHeaderButton("Mousepads");
            Home.Mousepads.HoverOverMousepadlItemIcon();
            Home.Mousepads.ClickChevronRight();
            Home.Mousepads.HoverOverMousePadSizeXl();
            Assert.IsTrue(Home.Mousepads.IsXlTooltipDisplayed(), "Xl tooltip wasn't displayed");
        }
    }
}