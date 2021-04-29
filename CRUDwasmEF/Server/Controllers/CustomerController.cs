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
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CustomerController(ApplicationDBContext context)
        {
            this._context = context;
        }

        //An Action method to get all the Customers from the context instance.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        //Fetches the details of one Customer that matches the passed id as parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(customer);
        }

        //Creates a new Customer with the passed Customer object data.
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer.Id);
        }

        //Modifies an existing Customer record.
        [HttpPut]
        public async Task<IActionResult> Put(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Deletes a Customer record by Id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = new Customer { Id = id };
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}