using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Services;
using TenderApp.Models.BusinessModels;
using TenderApp.Models.AdminViewModels;

namespace TenderApp.Controllers
{
    public class CategoryManageController : Controller
    {
        IRepository<Category> repository;
        public CategoryManageController(IRepository<Category> repos)
        {
            repository = repos;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = repository;
            return View(repository);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = repository;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {
            ViewBag.Categories = repository;

            if (ModelState.IsValid)
            {
                Category parent = repository.FirstOrDefault(x => x.CategoryId == category.ParentId);
                Category cat = new Category()
                {
                    Name = category.Name,
                    Description = category.Description,
                    Type = category.Type,
                    Parent = parent
                };
                repository.Add(cat);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.Categories = repository;
            Category cat = repository.FirstOrDefault(x => x.CategoryId == Id);
            if (cat == null)
            {
                throw new ApplicationException($"Не получилось загрузить категорию с  ID '{Id}'.");
            }
            CategoryViewModel model = new CategoryViewModel()
            {
                Name = cat.Name,
                Description = cat.Description,
                Type = cat.Type,

            };
            if (cat.Parent != null)
                model.ParentId = cat.Parent.CategoryId;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel category, int Id)
        {
            ViewBag.Categories = repository;
            string status = null;
            if (ModelState.IsValid)
            {
                status = "Категория обновлена";
                var cat = repository.FirstOrDefault(x => x.CategoryId == Id);
                if (cat == null)
                {
                    throw new ApplicationException($"Не получилось загрузить категорию с  ID '{Id}'.");
                }
                cat.Name = category.Name;
                cat.Type = category.Type;
                cat.Description = category.Description;
                var parent = repository.FirstOrDefault(x => x.CategoryId == category.ParentId);
                if (!parent.Children.Contains(cat))
                cat.Parent = parent;
                repository.Update(cat);
            }
            ViewData["Status"] = status ?? "Error произошла ошибка";
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {

            Category cat = repository.FirstOrDefault(x => x.CategoryId == Id);
            repository.Remove(cat);
            return RedirectToAction("Index");
            return View();
        }
    }
}