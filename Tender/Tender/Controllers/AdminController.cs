﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TenderApp.Models;
using TenderApp.Models.ManageViewModels;
using TenderApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace TenderApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository repository;
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        [TempData]
        string StatusMessage { get; set; }
        public AdminController(UserManager<ApplicationUser> userManager,
                      SignInManager<ApplicationUser> signInManager,
            IRepository repos)
        {
            repository = repos;
            this._userManager = userManager;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(_userManager.Users);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                throw new ApplicationException($"Не получилось загрузить пользователя с  ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new IndexViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                throw new ApplicationException($"Не получилось загрузить пользователя с ID '{_userManager.GetUserId(User)}'.");
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Непредвиденная ошибка при установке email для пользователя с ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Непредвиденная ошибка при установке телефона для пользователя ID '{user.Id}'.");
                }
            }

            StatusMessage = "Профиль обновлен";
            return RedirectToAction("Edit", new { Id = model.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            await _userManager.DeleteAsync(user);
            return View();
        }
        public ActionResult Users()
        {
            return View(_userManager.Users);
        }

    }
}