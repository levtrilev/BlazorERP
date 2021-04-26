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
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProjectController(ApplicationDBContext context)
        {
            this._context = context;
        }

        //An Action method to get all the developers from the context instance.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        //Fetches the details of one developer that matches the passed id as parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var proj = await _context.Projects.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(proj);
        }

        //Creates a new Developer with the passed developer object data.
        [HttpPost]
        public async Task<IActionResult> Post(Project project)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
            return Ok(project.Id);
        }

        //Modifies an existing developer record.
        [HttpPut]
        public async Task<IActionResult> Put(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Deletes a developer record by Id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proj = new Project { Id = id };
            _context.Remove(proj);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
