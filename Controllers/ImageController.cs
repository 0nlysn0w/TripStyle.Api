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
    public class ImageController : Controller
    {
        private readonly TripStyleContext _context;

        public ImageController(TripStyleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Image> Get()
        {
            return _context.Images.ToList();
        }

        [HttpGet("{id}", Name = "GetImage")]
        public ActionResult<Image> GetById(int id)
        {
            Image image = _context.Images.Find(id);
            if  (image == null)
            {
                return NotFound();
            }

            return image;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Image image)
        {
            _context.Images.Add(image);
            
            _context.SaveChanges();

            return CreatedAtRoute("GetImage", new { id = image.ImageId}, image);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Image image)
        {
            var todo = _context.Images.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Url = image.Url;

            _context.Images.Update(todo);
            _context.SaveChanges();
            return CreatedAtRoute("GetCategory", new { id = image.ImageId }, image);

        }
       [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Images.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Images.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}