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
    public class ProductController : ControllerBase
    {
        IStoreService db;

        public ProductController(IStoreService store)
        {
            db = store;
        }

        [HttpGet("/api/products")]
        public IEnumerable<ProductResponseModel> Get()
        {
            var mapper = new MapperConfiguration
                    (cfg => cfg.CreateMap<ProductDTO, ProductResponseModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductResponseModel>>
                        (db.GetProducts());
            return products;
        }

        [HttpGet("/api/products/{id}")]
        public ActionResult<ProductResponseModel> Get(int id)
        {
            var mapper = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ProductDTO, ProductResponseModel>()).CreateMapper();
            var product = mapper.Map<ProductDTO, ProductResponseModel>(db.GetProduct(id));

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost("/api/products")]
        public ActionResult Post([FromBody] ProductRequestModel model)
        {
            if (model == null)
                return BadRequest();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductRequestModel, ProductDTO>()).CreateMapper();
            var product = mapper.Map<ProductRequestModel, ProductDTO>(model);

            db.CreateProduct(product);

            return Ok();
            
        }

    }
}
