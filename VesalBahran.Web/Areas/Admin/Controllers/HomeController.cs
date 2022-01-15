using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesalBahran.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
