using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderSellController : ControllerBase
    {
        IStoreService service;

        public OrderSellController(IStoreService service)
        {
            this.service = service;
        }
        // GET: api/<OrderSellController>
        [HttpGet("/api/sell/orders")]
        public IEnumerable<OrderSellResponseModel> Get()
        {
            var mapper = new MapperConfiguration
                    (cfg => cfg.CreateMap<OrderSellDTO, OrderSellResponseModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderSellDTO>, IEnumerable<OrderSellResponseModel>>
                        (service.GetOrderSells());
            return orders;
        }

        // GET api/<OrderSellController>/5
        [HttpGet("/api/sell/orders/{id}")]
        public ActionResult<OrderSellResponseModel> Get(int id)
        {
            var mapper = new MapperConfiguration(cfg =>
                    cfg.CreateMap<OrderSellDTO, OrderSellResponseModel>()).CreateMapper();
            var order = mapper.Map<OrderSellDTO, OrderSellResponseModel>(service.GetOrderSell(id));
            if (order == null)
                return NotFound();
            return order;
        }

        // POST api/<OrderSellController>
        [HttpPost("/api/sell/orders")]
        public ActionResult Post([FromBody] OrderSellRequestModel orderModel)
        {
            if (orderModel == null)
                return BadRequest();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderSellRequestModel, OrderSellDTO>()).CreateMapper();
            var order = mapper.Map<OrderSellRequestModel, OrderSellDTO>(orderModel);

            service.MakeOrderSell(order);
            return Ok();
        }

        // PUT api/<OrderSellController>/5
        /*[HttpPut("/api/sell/orders/{id}")]
        public ActionResult Put(int id)
        {
            if (id < 0)
                return BadRequest();
            service.CloseOrderSell(id);

            return Ok();
        }*/
/*
        // DELETE api/<OrderSellController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
