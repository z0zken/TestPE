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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
                return NotFound();
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();

            await _addressService.AddAddressAsync(address);
            return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Address address)
        {
            if (id != address.Id || address == null)
                return BadRequest();

            await _addressService.UpdateAddressAsync(address);
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }
    }
}
