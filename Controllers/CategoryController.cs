using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripStyle.Models;

namespace TripStyle.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly TripStyleContext _context;

        public CategoryController(TripStyleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> GetById(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Category category)
        {
            var todo = _context.Categories.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = category.Name;

            _context.Categories.Update(todo);
            _context.SaveChanges();
            return CreatedAtRoute("GetCategory", new { id = category.CategoryId }, category);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Categories.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}