using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockTradingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }
    }
}