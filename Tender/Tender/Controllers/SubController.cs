using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Services;
using TenderApp.Models.BusinessModels;
using Microsoft.AspNetCore.Authorization;

namespace TenderApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class SubController : Controller
    {
        IRepository repository;
        public SubController(IRepository repos)
        {
            repository = repos;
        }
        // GET: Sub
        [HttpGet]
        public ViewResult ManageSubs()
        {
            return View(repository.SubGroup);
        }

        [HttpGet]
        public PartialViewResult EditSubGet(Sub sub)
        {
            return PartialView("CreateSub", sub);
        }

        [HttpPost]
        public ActionResult EditSubPost(int Parent, Sub sub)
        {
            SubGroup group = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == Parent);
            if (group != null)
            {
                repository.Sub.Update(sub);
            }
            
            return Redirect("ManageSubs");
        }

        [HttpGet]
        public PartialViewResult EditSubGroupGet(SubGroup group)
        {
            return PartialView("CreateSubGroup", group);
        }

        [HttpPost]
        public ActionResult EditSubGroupPost(SubGroup group)
        {
            repository.SubGroup.Update(group);
            return Redirect("ManageSubs");
        }

        [HttpGet]
        public PartialViewResult CreateSubGroup()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult CreateSub()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateSub(int Parent, Sub sub)
        {
            SubGroup group = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == Parent);
            if (group != null)
            {
                group.Subs.Add(sub);
            }
            return Redirect("ManageSubs");
        }

        [HttpPost]
        public ActionResult CreateSubGroup(SubGroup group)
        {
            repository.SubGroup.Add(group);
            return Redirect("ManageSubs");
        }
        [HttpPost]
        public ActionResult DeleteSubGroup(int groupId)
        {
            SubGroup current = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == groupId);
            if (current != null)
                repository.SubGroup.Remove(current);
            return Redirect("ManageSubs");
        }
        [HttpPost]
        public ActionResult DeleteSub(int SubId)
        {
            Sub current = repository.Sub.FirstOrDefault(s => s.SubId == SubId);
            if (current != null)
                repository.Sub.Remove(current);
            return Redirect("ManageSubs");
        }
    }
}