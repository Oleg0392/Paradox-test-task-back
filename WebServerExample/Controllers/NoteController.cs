using Microsoft.AspNetCore.Mvc;
using WebServerExample.DataProvider.Interfaces;
using WebServerExample.Models;
using WebServerExample.Data;
using System.Linq;
using System;
using System.Threading.Tasks;

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
            //return Json(repository.GetEntityies());
            return Json(_context.Notes.OrderBy(n => n.NoteID));
        }

        [HttpPost]
        [Route("api/upd/[controller]")]
        public async Task<IActionResult> Post([FromBody]Note newNote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Notes.Update(newNote);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("api/add/[controller]")]
        public async Task<IActionResult> Add([FromBody] Note newNote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Add(newNote);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("api/del/[controller]")]
        public async Task<IActionResult> Del([FromBody]Note delNote)
        {
            if (!ModelState.IsValid) return BadRequest(delNote);
            
            _context.Remove(delNote);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
