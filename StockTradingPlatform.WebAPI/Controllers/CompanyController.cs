using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetCompanies();
        }

        [HttpPost]
        public Company Post([FromBody] Company company)
        {
            var returnCompany = _companyService.AddCompany(company);
            HttpContext.Response.StatusCode = (int) HttpStatusCode.Created;
            return company;
        }

        [HttpPost("{companySymbol}/shares")]
        public Order IssueShare(string companySymbol, [FromBody] SharesRequest request)
        {
            return _companyService.IssueShares(companySymbol, request.Price, request.Quantity);
        }
    }
}