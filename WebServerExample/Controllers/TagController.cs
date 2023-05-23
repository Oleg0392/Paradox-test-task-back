using WebServerExample.Models;
using WebServerExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebServerExample.Controllers
{
    public class TagController : Controller
    {
        private readonly NoteContext _context;

        public TagController(NoteContext noteContext)
        {
            this._context = noteContext;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Tags);
        }
    }
}
