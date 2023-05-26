using WebServerExample.Models;
using WebServerExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Add([FromBody]Tag newTag)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("api/del/[controller]")]
        public async Task<IActionResult> Del([FromBody]Tag delTag)
        {
            if (!ModelState.IsValid) { return BadRequest(delTag); }

            _context.Remove(delTag);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
