using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
