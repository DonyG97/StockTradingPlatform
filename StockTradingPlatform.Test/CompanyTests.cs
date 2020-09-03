using System;
using System.Linq;
using NUnit.Framework;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Test
{
    [TestFixture]
    public class CompanyTests
    {
        [SetUp]
        public void SetUp()
        {
            var companyContext = new CompanyContext();
            var orderContext = new OrderContext();
            companyContext.AddCompany(new Company("TST"));
            companyContext.AddCompany(new Company("TEST"));
            _companyService = new CompanyService(companyContext, orderContext);
            _orderService = new OrderService(orderContext, companyContext);
        }

        private CompanyService _companyService;
        private OrderService _orderService;

        [Test]
        public void GetCompanies_ReturnsAllCompanies()
        {
            Assert.AreEqual(2, _companyService.GetCompanies().Count());
        }

        [Test]
        public void WhenACompanyIsFirstCreated_ItHasNoShares()
        {
            _companyService.AddCompany(new Company("NEW"));
            Assert.AreEqual(0, _orderService.GetOrders().Count());
        }

        [Test] // Probably out of the scope of the challenge but this should throw a custom error to explain what happened
        public void WhenAddingANewCompany_ThatAlreadyExists_AnErrorIsThrown()
        {
            var newCompany = new Company("NEW");

            Assert.DoesNotThrow(() => _companyService.AddCompany(newCompany));

            Assert.Throws<Exception>(() => _companyService.AddCompany(newCompany));
        }

        [Test]
        public void WhenAddingANewCompany_ThatDoesntAlreadyExist_TheNewCompanyIsSaved()
        {
            var newCompanySymbol = "NEW";
            _companyService.AddCompany(new Company(newCompanySymbol));

            Assert.IsNotNull(_companyService.GetCompany(newCompanySymbol));
        }

        [Test] // Probably out of the scope of the challenge. Also it should probably check for an error being thrown and a 400
        public void WhenIssuingShares_ForACompanyThatDoesNotExist_AnExceptionIsThrownAndNoOrderIsCreated()
        {
            Assert.Throws<Exception>(() => _companyService.IssueShares("NEW", 20, 100));
            Assert.AreEqual(0, _orderService.GetOrders().Count());
        }

        [Test]
        public void WhenIssuingShares_ForAnExistingCompany_AnOrderIsCreated()
        {
            var order = _companyService.IssueShares("TEST", 20, 100);
            Assert.AreEqual(1, _orderService.GetOrders().Count());
            Assert.IsNotNull(order);
        }
    }
}