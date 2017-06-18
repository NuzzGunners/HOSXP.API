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
    public class AccountController : Controller
    {
        HOSXPContext context = new HOSXPContext();

        [HttpGet("{query}")]
        public IActionResult GetById(string query)
        {
            var item = context.V_ACCOUNT.Where(i => i.Userid.ToLower().Contains(query.ToLower()) || i.Fullname.ToLower().Contains(query.ToLower()))
                .Select(i => new { i.Userid, i.Fullname }).Take(10).ToArray();

            var dictionary = new Dictionary<string, object>();
            for (int i = 0; i < item.Length; i++)
            {
                dictionary.Add(item[i].Userid, null);
            }

            List<dataUser> listdataUser = new List<dataUser>();
            dataUser objdataUser = new dataUser();
            objdataUser.data = dictionary;
            listdataUser.Add(objdataUser);
            return new OkObjectResult(item);
        }

        public class dataUser
        {
            public object data { get; set; }
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
