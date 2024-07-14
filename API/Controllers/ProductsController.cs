using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [EnableQuery]
        [Authorize(Policy = "StaffAndAbove")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [Authorize(Policy = "StaffAndAbove")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Policy = "ManagerOnly")]
        [EnableQuery]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        [EnableQuery]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (id != product.Id || product == null)
                return BadRequest();

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        [EnableQuery]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}