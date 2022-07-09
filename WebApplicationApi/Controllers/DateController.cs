using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplicationApi.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Page()
        {
            DateTime datetime=DateTime.Now;
            
            return View();
        }
    }
}
