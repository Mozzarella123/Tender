using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TenderApp.Controllers
{
    public class UserMetaController : Controller
    {
        // GET: UserMeta
        public ActionResult Index()
        {
            return View();
        } 
    }
}