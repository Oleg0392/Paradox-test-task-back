using Microsoft.AspNetCore.Mvc;
using WebServerExample.DataProvider.Interfaces;
using WebServerExample.Models;
using WebServerExample.Data;

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
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Notes);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody]Note newNote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            newNote.NoteID++;

            return Ok(newNote);
        }
    }
}
