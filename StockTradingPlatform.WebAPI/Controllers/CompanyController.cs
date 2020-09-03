using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockTradingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }
    }
}