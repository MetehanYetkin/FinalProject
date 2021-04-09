using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntitiyFramework;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//api/product
    [ApiController]//Attrıbute
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //Soyut sınıfa bağımlılık 
        //Fieldler genel olarak _ ile başlar.
        //IoC Container -- Inversion of Control

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //swagger
           var result= _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200 iyi
            }
            return BadRequest(result.Message);//400 kötü

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBycategory")]
        public IActionResult GetAllByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]//Güncelleme ve silme için de kullanılabilir.
        public IActionResult Add(Product product)//Eklenecek ürün buraya yazılır.
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);//IResult oldugu için data barındırmıyor metotta ama data olarak resultu verebiliirz.
            }
            return BadRequest(result);
        }

    }
}
