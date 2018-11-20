using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripStyle.Models;

namespace TripStyle.Controllers
{
    //Nog niet AF
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly TripStyleContext _context;

        public RoleController(TripStyleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _context.Roles.ToList();
        }

        [HttpGet("{id}", Name = "GetRole")]
        public ActionResult<Role> GetById(int id)
        {
            Role role = _context.Roles.Find(id);
            if  (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Role role)
        {
            _context.Roles.Add(role);
            
            _context.SaveChanges();

            return CreatedAtRoute("GetRole", new { id = role.RoleId}, role);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Role role)
        {
            var todo = _context.Roles.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = role.Name;

            _context.Roles.Update(todo);
            _context.SaveChanges();
            return CreatedAtRoute("GetCategory", new { id = role.RoleId }, role);

        }
       [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Roles.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}