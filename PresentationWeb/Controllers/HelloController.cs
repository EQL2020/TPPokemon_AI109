using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb.Controllers
{
    public class HelloController : Controller
    {
        // GET: HelloController
        public EmptyResult Index()
        {
            Response.WriteAsync("<!DOCTYPE html>");
            Response.WriteAsync("<html lang=fr>");
            Response.WriteAsync("<head>");
            Response.WriteAsync("<title>Plop</title>");
            Response.WriteAsync("</head>");
            Response.WriteAsync("<body>");
            Response.WriteAsync("<h1>Hello World</h1>");
            Response.WriteAsync("</body>");
            Response.WriteAsync("</html>");

            return new EmptyResult();
        }

 
    }
}
