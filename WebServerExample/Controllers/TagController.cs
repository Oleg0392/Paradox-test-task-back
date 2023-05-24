using WebServerExample.Models;
using WebServerExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Tags);
        }
    }
}
