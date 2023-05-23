using Microsoft.AspNetCore.Mvc;
using WebServerExample.DataProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using WebServerExample.Models;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace WebServerExample.Controllers
{
    public class NoteController : Controller
    {
        IQueryManager queryManager;

        public NoteController(IQueryManager queryManager)
        {
            this.queryManager = queryManager;   
        }       

        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            Note[] notes = new Note[]     // test data
            {
                new Note{NoteID=0,Name="работа",Raw="сделать отчеты"},
                new Note{NoteID=1,Name="дом",Raw="помочь приготовить ужин"},
                new Note{NoteID=2,Name="магазин",Raw="не забыть порошок"},
                new Note{NoteID=3,Name="машина",Raw="оплатить страховку"}
            };
            return Json(notes);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public OkResult Post()
        {
            string bodyRaw = String.Empty;
            using(Request.BodyReader.AsStream())
            {
                bodyRaw = readBody(Request).Result.ToString();
            }
            OkResult result = new OkResult();
            return result;
        }

        public IActionResult Index()
        {
            return null;
        }

        private async Task<ReadResult> readBody(HttpRequest request)
        {
            return await request.BodyReader.ReadAsync();
        }
    }
}
