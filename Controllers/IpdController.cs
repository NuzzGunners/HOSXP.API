using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HOSXP.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSXP.API.Controllers
{
    [Route("api/[controller]")]
    public class IpdController : Controller
    {
        HOSXPContext context = new HOSXPContext();

        [HttpGet("{query}")]
        public IActionResult GetById(string query)
        {
            var item = context.V_IPD.Where(i => i.AN == query);
            return new OkObjectResult(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
