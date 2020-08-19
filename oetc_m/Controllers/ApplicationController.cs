using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult ApplicationRecord()
        {
            return View();
        }
        public IActionResult ApplicationDetail(int id)
        {
            ViewData["id"] = id;
            return View();
        }
    }
}
