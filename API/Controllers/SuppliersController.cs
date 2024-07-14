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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound();
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return BadRequest();

            await _supplierService.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Supplier supplier)
        {
            if (id != supplier.Id || supplier == null)
                return BadRequest();

            await _supplierService.UpdateSupplierAsync(supplier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }
}
