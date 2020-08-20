using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMultiCategories.Models.Client.Data;
using DemoMultiCategories.Models.Client.Interfaces;
using DemoMultiCategories.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMultiCategories.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryRepository.Get());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            Category category = _categoryRepository.Get(id);
            return (category is null) ? (ActionResult)RedirectToAction("Index") : View(_categoryRepository.Get(id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryForm form)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Insert(new Category(form.Name));
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                }
            }
            return View(form);            
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryRepository.Get(id);
            return (category is null) ? (ActionResult)RedirectToAction("Index") : View(new UpdateCategoryForm() { Id = category.Id, Name = category.Name });
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateCategoryForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Update(form.Id, new Category(form.Name));
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                }
            }
            return View(form);
        }
    }
}
