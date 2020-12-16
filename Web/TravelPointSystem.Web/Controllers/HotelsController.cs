using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPointSystem.Web.Controllers
{
    public class HotelsController : BaseController
    {
        [Authorize]
        [HttpPost]
        public IActionResult AllByDestination()
        {

            return View();
        }
    }
}
