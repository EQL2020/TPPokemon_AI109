using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


// localhost:54654/Toto >>> TotoController.Index()
// localhost:54654/UnTrucDeOuf >>> UnTrucDeOufController.Index()