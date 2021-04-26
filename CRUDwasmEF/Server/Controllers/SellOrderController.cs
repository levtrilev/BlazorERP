using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDwasmEF.Server.Data;
using Microsoft.EntityFrameworkCore;
using CRUDwasmEF.Shared.Models;

namespace CRUDwasmEF.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellOrderController : ControllerBase
    {
        private readonly ExternalDbContext _context;
        public SellOrderController(ExternalDbContext context)
        {
            this._context = context;
        }

        //An Action method to get all the developers from the context instance.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _context.SellOrders.ToListAsync();
            return Ok(orders);
        }

        //Fetches the details of one developer that matches the passed id as parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _context.SellOrders.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(order);
        }

        //Creates a new Developer with the passed developer object data.
        [HttpPost]
        public async Task<IActionResult> Post(SellOrder order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order.Id);
        }

        //Modifies an existing developer record.
        [HttpPut]
        public async Task<IActionResult> Put(SellOrder order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Deletes an order record by Id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ordr = new SellOrder { Id = id };
            _context.Remove(ordr);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
