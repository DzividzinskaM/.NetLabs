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
    public class OrderBuyController : ControllerBase
    {
        IStoreService service;

        public OrderBuyController(IStoreService service)
        {
            this.service = service;
        }

        // GET: api/<OrderBuyController>
        [HttpGet("/api/buy/orders")]
        public IEnumerable<OrderBuyResponseModel> Get()
        {
            var mapper = new MapperConfiguration
                    (cfg => cfg.CreateMap<OrderBuyDTO, OrderBuyResponseModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderBuyDTO>, IEnumerable<OrderBuyResponseModel>>
                        (service.GetOrderBuys());
            return orders;
            //return service.GetOrderBuys();
        }

        // GET api/<OrderBuyController>/5
        [HttpGet("/api/buy/orders/{id}")]
        public ActionResult<OrderBuyResponseModel> Get(int id)
        {
            if (id < 0)
                return BadRequest();

            var mapper = new MapperConfiguration(cfg => 
                    cfg.CreateMap<OrderBuyDTO, OrderBuyResponseModel>()).CreateMapper();
            var order = mapper.Map<OrderBuyDTO, OrderBuyResponseModel>(service.GetOrderBuy(id));
            if (order == null)
                return NotFound();
            return order;
        }

        // POST api/<OrderBuyController>
        [HttpPost("/api/buy/orders")]
        public ActionResult Post([FromBody] OrderBuyRequestModel orderModel)
        {
            if (orderModel == null)
                return BadRequest();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderBuyRequestModel, OrderBuyDTO>()).CreateMapper();
            var order = mapper.Map<OrderBuyRequestModel, OrderBuyDTO>(orderModel);
            service.MakeOrderBuy(order);
            return Ok();
        }

        // PUT api/<OrderBuyController>/5
        [HttpPut("/api/buy/orders/{id}")]
        public ActionResult Put(int id,[FromBody] SupplierRequestModel supplier)
        {
            if (id < 0 || supplier == null)
                return BadRequest();

            service.CloseOrderBuy(id, supplier.Name);
            return Ok();

        }

/*        // DELETE api/<OrderBuyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
