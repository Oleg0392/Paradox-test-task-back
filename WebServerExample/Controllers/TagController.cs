using WebServerExample.Models;
using WebServerExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebServerExample.Controllers
{
    public class TagController : Controller
    {
        private readonly TagContext _context;

        public TagController(TagContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("api/get/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Tags.OrderBy(t => t.TagID));
        }

        [HttpPost]
        [Route("api/add/[controller]")]
        public IActionResult Add([FromBody]Tag newTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tags.Add(newTag);
            _context.SaveChangesAsync();

            return Ok(newTag);
        }

        [HttpPost]
        [Route("api/del/[controller]")]
        public IActionResult Del([FromBody]Tag delTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(delTag);
            }

            _context.Remove(delTag);
            _context.SaveChangesAsync();

            return Ok(delTag);
        }
    }
}
