using Microsoft.AspNetCore.Mvc;
using System;

namespace WebServerExample.Controllers
{
    public class NoteController : Controller
    {
        Note[] notes =
        {
            new Note(0,"note1"),
            new Note(1,"note2"),
            new Note(2,"note3"),
            new Note(3,"note4"),
            new Note(4,"note5")
        };

        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Index()
        {           
            for (int i = 0; i < notes.Length; i++)
            {
                notes[i].Raw = "this note written in backend asp.net microservice. #" + i.ToString();
            }
            return Json(notes);
        }
    }
}
