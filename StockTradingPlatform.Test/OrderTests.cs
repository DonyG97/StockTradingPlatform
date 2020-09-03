using NUnit.Framework;

namespace StockTradingPlatform.Test
{
    [TestFixture]
    public class OrderTests
    {
        [Test] // Should probably expect a bad response code with a custom exception
        public void WhenAddingAnOrder_ForACompanyThatDoesNotExist_NoOrderIsCreated()
        {
            Assert.True(false);
        }

        [Test] // This should probably state that the order is valid on creation, but currently there is no data validation
        public void WhenAddingAnOrder_TheOrderIsCreated()
        {
            Assert.True(false);
        }

        [Test]
        public void WhenGettingAnOrder_ThatDoesExist_TheCorrectOrderIsReturned()
        {
            Assert.True(false);
        }

        [Test] // They'd expect a bad request but the test is more likely focused at the core logic
        public void WhenGettingAnOrder_ThatDoesNotExist_NullIsReturned()
        {
            Assert.True(false);
        }
    }
}