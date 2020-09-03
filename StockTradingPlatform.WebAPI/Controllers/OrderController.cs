using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using StockTradingPlatform.Core.CoreLogic;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI.Controllers
{
    /// <summary>
    ///     Controller for handling orders
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        /// <summary>
        ///     Default constructor 
        /// </summary>
        /// <param name="orderService"> Singleton order service</param>
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        ///     Get's all incomplete orders
        /// </summary>
        /// <returns> All incomplete orders </returns>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetIncompleteOrders();
        }

        /// <summary>
        ///     Get's all complete orders
        /// </summary>
        /// <returns> All complete orders </returns>
        [HttpGet("complete")]
        public IEnumerable<Order> GetCompleteOrders()
        {
            return _orderService.GetCompleteOrders();
        }

        /// <summary>
        ///     Get an existing order by id
        /// </summary>
        /// <param name="id"> The guid of the order you want to retrieve</param>
        /// <returns> The order matching the provided guid</returns>
        [HttpGet("{id}")]
        public Order GetById(Guid id)
        {
            var orderToReturn = _orderService.GetOrder(id);

            if (orderToReturn == null) HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;

            return orderToReturn;
        }

        /// <summary>
        ///    Creates an order
        /// </summary>
        /// <param name="request"> The <see cref="OrderRequest"/> OrderRequest you wish to create </param>
        /// <returns> Returns the order you provided with its Id populated</returns>
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