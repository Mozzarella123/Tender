using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Services;
using TenderApp.Models.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using TenderApp.Models.AdminViewModels;
using TenderApp.Models.SubsViewModels;

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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SubGroups(SubGroup.Type type)
        {         
            return View(repository.SubGroup.Where(x => x.ForType == type));
        }
        [HttpGet]
        public IActionResult CreateSub()
        {
            return View("CESub");
        }

        [HttpPost]
        public ActionResult CreateSub(SubViewModel subm)
        {
            if (ModelState.IsValid)
            {
                SubGroup group = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == subm.SubGroupId);
                if (group != null)
                {
                    Sub sub = new Sub()
                    {
                        Name = subm.Name,
                        SubGroup = group,
                        Priority = subm.Priority,
                        Type = subm.Type
                    };
                    repository.Sub.Add(sub);
                    return Redirect("SubGroups");
                }
                throw new ApplicationException($"Не получилось загрузить группу с  ID '{subm.SubGroupId}'.");
            }
            return View("CESub", subm);
        }
        [HttpGet]
        public PartialViewResult EditSub(SubViewModel sub)
        {
            return PartialView("CreateSub", sub);
        }

        [HttpPost]
        public ActionResult EditSub(int Parent, Sub sub)
        {
            SubGroup group = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == Parent);
            if (group != null)

            {
                repository.Sub.Update(sub);
            }

            return Redirect("ManageSubs");
        }

        [HttpPost]
        public ActionResult DeleteSub(int SubId)
        {
            Sub current = repository.Sub.FirstOrDefault(s => s.SubId == SubId);
            if (current != null)
                repository.Sub.Remove(current);
            return Redirect("SubGroups");
        }

        [HttpGet]
        public IActionResult CreateSubGroup()
        {
            return View("CESubGroup");
        }
       

        [HttpGet]
        public PartialViewResult EditSubGroup()
        {
            return PartialView("CreateSubGroup");
        }

        [HttpPost]
        public IActionResult EditSubGroup(SubGroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                var editgroup = repository.SubGroup.FirstOrDefault(x => x.SubGroupId == group.SubGroupId);
                editgroup.Name = group.Name;
                editgroup.Priority = editgroup.Priority;
                editgroup.ForType = editgroup.ForType;
                repository.SubGroup.Update(editgroup);
                return Redirect("ManageSubs");
            }
            return View(group);
        }

       

        [HttpPost]
        public ActionResult CreateSubGroup(SubGroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                SubGroup newgroup = new SubGroup()
                {
                    Name = group.Name,
                    Priority = group.Priority,
                    ForType = group.ForType

                };
                repository.SubGroup.Add(newgroup);
                return Redirect("SubGroups");

            }
            return View(group);
        }
        [HttpPost]
        public ActionResult DeleteSubGroup(int groupId)
        {
            SubGroup current = repository.SubGroup.FirstOrDefault(s => s.SubGroupId == groupId);
            if (current != null)
                repository.SubGroup.Remove(current);
            return Redirect("SubGroups");
        }
        
    }
}