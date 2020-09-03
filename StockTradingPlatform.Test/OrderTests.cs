using System;
using NUnit.Framework;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Test
{
    [TestFixture]
    public class OrderTests
    {
        [SetUp]
        public void SetUp()
        {
            var orderContext = new OrderContext();
            var companyContext = new CompanyContext();
            // TODO: Move test symbol into const
            companyContext.AddCompany(new Company("TEST"));
            _companyService = new CompanyService(companyContext, orderContext);
            _orderService = new OrderService(orderContext, companyContext);
        }

        private OrderService _orderService;
        private CompanyService _companyService;

        [Test] // This should probably state that the order is valid on creation, but currently there is no data validation
        public void WhenAddingAnOrder_ForACompanyThatDoesExist_TheOrderIsCreated()
        {
            var order = new Order("TEST", 20, 21, 100, OrderType.Buy);
            var returnedId = _orderService.AddOrder(order).Id;
            Assert.AreEqual(order, _orderService.GetOrder(returnedId));
        }

        [Test] // Should probably expect a bad response code with a custom exception
        public void WhenAddingAnOrder_ForACompanyThatDoesNotExist_NoOrderIsCreated()
        {
            Assert.Throws<Exception>(() => _orderService.AddOrder(new Order("TST", 20, 21, 100, OrderType.Buy)));
        }

        [Test] // This should probably state that the order is valid on creation, but currently there is no data validation
        public void WhenAddingAnOrder_TheOrderIsAssignedACreatedTime()
        {
            var order = new Order("TEST", 20, 21, 100, OrderType.Buy);
            var returnedOrder = _orderService.AddOrder(order);
            Assert.IsNotNull(returnedOrder.Created);
        }

        [Test] // This should probably state that the order is valid on creation, but currently there is no data validation
        public void WhenAddingAnOrder_TheOrderIsAssignedAnId()
        {
            var order = new Order("TEST", 20, 21, 100, OrderType.Buy);
            var returnedOrder = _orderService.AddOrder(order);
            Assert.IsNotNull(returnedOrder.Id);
        }

        [Test]
        public void
            WhenCreatingAnOrder_WithInsufficientExistingShares_TheOrderIsMarkedAsProcessingAndTheSharesAreUpdated()
        {
            _companyService.IssueShares("TEST", 50, 100);
            var order = _orderService.AddOrder(new Order("TEST", 50, 50, 150, OrderType.Buy));
            Assert.AreEqual(50, order.AmountRemaining);
            Assert.AreEqual(OrderStatus.Processing, order.Status);
        }

        [Test]
        public void WhenCreatingAnOrder_WithSufficientExistingShares_TheOrderIsCompleteAndTheSharesAreUpdated()
        {
            _companyService.IssueShares("TEST", 50, 100);
            var order = _orderService.AddOrder(new Order("TEST", 50, 50, 100, OrderType.Buy));
            Assert.AreEqual(0, order.AmountRemaining);
            Assert.AreEqual(OrderStatus.Complete, order.Status);
        }

        [Test]
        public void WhenGettingAnOrder_ThatDoesExist_TheCorrectOrderIsReturned()
        {
            var order = new Order("TEST", 20, 21, 100, OrderType.Buy);
            var returnedId = _orderService.AddOrder(order).Id;
            Assert.AreEqual(order, _orderService.GetOrder(returnedId));
        }

        [Test] // They'd expect a bad request but the test is more likely focused at the core logic
        public void WhenGettingAnOrder_ThatDoesNotExist_NullIsReturned()
        {
            // Add data in so there is something there
            var order = new Order("TEST", 20, 21, 100, OrderType.Buy)
            {
                Id = Guid.NewGuid()
            };
            var _ = _orderService.AddOrder(order);
            Assert.IsNull(_orderService.GetOrder(Guid.NewGuid()));
        }
    }
}