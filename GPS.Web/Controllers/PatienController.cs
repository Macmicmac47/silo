using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GPS.Web.Controllers
{
    public class PatienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}