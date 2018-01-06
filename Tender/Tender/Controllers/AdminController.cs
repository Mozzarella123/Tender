using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TenderApp.Models;
using TenderApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace TenderApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository repository;
        readonly UserManager<ApplicationUser> userManager;
        public AdminController(UserManager<ApplicationUser> userManager, IRepository repos)
        {
            repository = repos;
            this.userManager = userManager;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Users = userManager.Users;
            return View();
        }

    }
}