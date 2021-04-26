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
    public class DeveloperController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DeveloperController(ApplicationDBContext context)
        {
            this._context = context;
        }

        //An Action method to get all the developers from the context instance.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Developers.ToListAsync();
            return Ok(devs);
        }

        //Fetches the details of one developer that matches the passed id as parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Developers.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        //Creates a new Developer with the passed developer object data.
        [HttpPost]
        public async Task<IActionResult> Post(Developer developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok(developer.Id);
        }

        //Modifies an existing developer record.
        [HttpPut]
        public async Task<IActionResult> Put(Developer developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Deletes a developer record by Id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Developer { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}