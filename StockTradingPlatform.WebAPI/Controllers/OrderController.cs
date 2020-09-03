using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public Order GetById(Guid id)
        {
            var orderToReturn = _orderService.GetOrder(id);

            if (orderToReturn == null) HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;

            return orderToReturn;
        }

        [HttpPost]
        public Order Post([FromBody] OrderRequest request)
        {
            var addedOrder = _orderService.AddOrder(new Order(request.Symbol, request.MinPrice, request.MaxPrice,
                request.Quantity, request.OrderType));
            if (addedOrder == null) HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            return addedOrder;
        }
    }
}