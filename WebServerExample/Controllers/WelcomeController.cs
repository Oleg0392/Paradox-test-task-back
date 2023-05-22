using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerExample.Controllers
{
    public class WelcomeController : Controller
    {
        [HttpGet]
        [Route("[controller]")]
        public string Index()
        {
            return "Welcome to the ASPnet back-end application. To load data add prefix 'api/' and model name (note/tag).";
        }
    }
}
