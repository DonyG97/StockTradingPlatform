using System.Collections.Generic;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.CoreLogic
{
    public class CompanyService
    {
        private readonly CompanyContext _companyContext;

        public CompanyService(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _companyContext.GetCompanies();
        }

        public Company GetCompany(string symbol)
        {
            return _companyContext.GetCompany(symbol);
        }

        // TODO: Decide whether this should return the company. Nothing get's set on the company so the object doesn't change but it's probably a good idea
        public void AddCompany(Company company)
        {
            _companyContext.AddCompany(company);
        }

        public void IssueShares()
        {
            // TODO
        }
    }
}