using Microsoft.AspNetCore.Mvc;
using WebServerExample.DataProvider.Interfaces;
using WebServerExample.Models;
using WebServerExample.Data;
using System.Linq;

namespace WebServerExample.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteContext _context;

        public NoteController(NoteContext context)
        {
            _context = context;   
        }       

        [HttpGet]
        [Route("api/get/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Notes.OrderBy(n => n.NoteID));
        }

        [HttpPost]
        [Route("api/upd/[controller]")]
        public IActionResult Post([FromBody]Note newNote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Notes.Update(newNote);
            _context.SaveChangesAsync();

            return Ok(newNote);
        }

        [HttpPost]
        [Route("api/add/[controller]")]
        public IActionResult Add([FromBody] Note newNote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Notes.Add(newNote);
            _context.SaveChangesAsync();

            return Ok(newNote);
        }

        [HttpPost]
        [Route("api/del/[controller]")]
        public IActionResult Del([FromBody]Note delNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(delNote);
            }

            _context.Remove(delNote);
            _context.SaveChangesAsync();

            return Ok(delNote);
        }
    }
}
