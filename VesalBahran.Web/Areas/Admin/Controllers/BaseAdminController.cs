using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace VesalBahran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize]
    public class BaseAdminController : Controller
    {
      
    }
}
