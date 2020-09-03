using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI.Controllers
{
    /// <summary>
    ///     The controller for handling companies
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        /// <summary>
        ///     Default constructor 
        /// </summary>
        /// <param name="companyService"> Singleton order service</param>
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        ///     Gets all companies
        /// </summary>
        /// <returns> A list of all companies within the system</returns>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetCompanies();
        }

        /// <summary>
        ///     Creates a company
        /// </summary>
        /// <param name="company"> The company you want to create</param>
        /// <returns> The created company</returns>
        [HttpPost]
        public Company Post([FromBody] Company company)
        {
            var returnCompany = _companyService.AddCompany(company);
            HttpContext.Response.StatusCode = (int) HttpStatusCode.Created;
            return returnCompany;
        }

        /// <summary>
        ///     Issues shares for a company
        /// </summary>
        /// <param name="companySymbol"> The symbol of the company you wish to issue shares for</param>
        /// <param name="request"> The <see cref="SharesRequest"/> SharesRequest object of the shares you wish to create </param>
        /// <returns></returns>
        [HttpPost("{companySymbol}/shares")]
        public Order IssueShare(string companySymbol, [FromBody] SharesRequest request)
        {
            return _companyService.IssueShares(companySymbol, request.Price, request.Quantity);
        }
    }
}