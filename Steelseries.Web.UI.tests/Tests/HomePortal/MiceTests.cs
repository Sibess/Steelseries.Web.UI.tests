using NUnit.Framework;
using NUnit.Framework.Internal;
using Steelseries.Web.UI.tests.PageObjects;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class MiceTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldFilterMices()
        {
            Home.HoverOverHeaderButton("Mice");
            Home.ClickWirelessButton();
            Home.Mice.CheckFingertipCheckbox();
            Assert.IsFalse(Home.Mice.IsRival650WirelessItemDisplayed(), "Rival 650 wireless Item was displayed");
            Home.Mice.ClickSortByDropdown();
            Home.Mice.ClickPriceLowToHighOption();
            Assert.IsTrue(Home.Mice.IsPriceLowToHighOptionSelected(), "Price Low To High Option wasn't selected");
            Home.Mice.ClickRemoveFilterIcon("Connectivity Wireless");
            Assert.IsTrue(Home.Mice.IsRival3ItemDisplayed(), "Rival 3 Item wasn't displayed");
            Assert.IsTrue(Home.Mice.IsPriceLowToHighOptionSelected(), "Price Low To High Option wasn't selected");
        }
    }
}