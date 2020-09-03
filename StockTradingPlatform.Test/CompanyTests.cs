using NUnit.Framework;

namespace StockTradingPlatform.Test
{
    [TestFixture]
    public class CompanyTests
    {
        [Test] //TODO: Debate whether this a Web test or a core test
        public void GetCompanies_ReturnsAllCompanies()
        {
            Assert.True(false);
        }

        [Test]
        public void WhenACompanyIsFirstCreated_ItHasNoShares()
        {
            Assert.True(false);
        }

        [Test] // Probably out of the scope of the challenge
        public void WhenAddingANewCompany_ThatAlreadyExists_ACustomErrorIsThrown()
        {
            Assert.True(false);
        }

        [Test]
        public void WhenAddingANewCompany_ThatDoesntAlreadyExist_TheNewCompanyIsSaved()
        {
            Assert.True(false);
        }

        [Test] // Probably out of the scope of the challenge. Also it should probably check for an error being thrown and a 400
        public void WhenIssuingShares_ForACompanyThatDoesNotExist_AnOrderIsNotCreated()
        {
            Assert.True(false);
        }

        [Test]
        public void WhenIssuingShares_ForAnExistingCompany_AnOrderIsCreated()
        {
            Assert.True(false);
        }
    }
}