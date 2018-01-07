using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TenderApp.Models;
using TenderApp.Models.ManageViewModels;
using TenderApp.Models.RoleViewModels;
using TenderApp.Services;
using System.ComponentModel.DataAnnotations;

namespace SciBuy.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleAdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleAdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _roleManager = rolemanager;
        }

        public async  Task<ActionResult> Index()
        {
            Dictionary<IdentityRole, IList<ApplicationUser>> usersinroles = new Dictionary<IdentityRole, IList<ApplicationUser>>();
            foreach (IdentityRole role in _roleManager.Roles)
            {
                IList<ApplicationUser> users = await _userManager.GetUsersInRoleAsync(role.Name);
                usersinroles.Add(role, users);
            }
            return View(usersinroles);
        }

        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            IList<ApplicationUser> Users = await _userManager.GetUsersInRoleAsync(role.Name);
            string[] memberIDs =  Users.Select(x => x.Id).ToArray();
            IEnumerable<ApplicationUser> members
                = _userManager.Users.Where(x => memberIDs.Any(y => y == x.Id));

            IEnumerable<ApplicationUser> nonMembers = _userManager.Users.Except(members);

            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                   
                    result = await _userManager.AddToRoleAsync(user, model.RoleName);

                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    result = await _userManager.RemoveFromRoleAsync(user,
                    model.RoleName);

                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");

            }
            return View("Error", new string[] { "Роль не найдена" });
        }
        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result
                    = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Роль не найдена" });
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}