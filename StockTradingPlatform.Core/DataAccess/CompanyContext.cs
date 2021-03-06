﻿using System;
using System.Collections.Generic;
using System.Linq;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.DataAccess
{
    public class CompanyContext
    {
        private readonly List<Company> _companies = new List<Company>();

        public IEnumerable<Company> GetCompanies()
        {
            return _companies;
        }

        public Company GetCompany(string symbol)
        {
            // TODO: Think about whether this needs to be case sensitive
            return _companies.FirstOrDefault(x =>
                string.Equals(x.Symbol, symbol, StringComparison.InvariantCultureIgnoreCase));
        }

        public Company AddCompany(Company company)
        {
            _companies.Add(company);
            return company;
        }
    }
}