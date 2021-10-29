using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TccCarol.Controllers
{
    public class CustoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
