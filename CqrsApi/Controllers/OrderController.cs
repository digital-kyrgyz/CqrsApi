﻿using CqrsApi.Interfaces.ICommandHandlers;
using CqrsApi.Interfaces.IQueryHandlers;
using CqrsApi.RequestModels.CommandRequestModels;
using CqrsApi.RequestModels.QueryRequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGetOrderByIdQueryHandler _getOrderByIdQueryHandler;
        private readonly IMakeOrderCommandHandler _makeOrderCommandHandler;
        public OrderController(IGetOrderByIdQueryHandler getOrderByIdQueryHandler, IMakeOrderCommandHandler makeOrderCommandHandler)
        {
            _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
            _makeOrderCommandHandler = makeOrderCommandHandler;
        }
        [HttpPost(template:"makeorder")]
        public IActionResult MakeOrder([FromBody] MakeOrderRequestModel requestModel)
        {
            var response = _makeOrderCommandHandler.MakeOrder(requestModel);
            return Ok(response);
        }
        [HttpGet(template:"order")]
        public IActionResult OrderDetails([FromQuery] GetOrderByIdRequestModel requestModel)
        {
            var response = _getOrderByIdQueryHandler.GetOrderById(requestModel);
            return Ok(response);
        }
    }
}
