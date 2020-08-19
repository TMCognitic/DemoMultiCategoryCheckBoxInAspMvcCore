using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMultiCategories.Models.Client.Data;
using DemoMultiCategories.Models.Client.Interfaces;
using DemoMultiCategories.Models.Forms;
using DemoMultiCategories.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMultiCategories.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MovieController(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            return View(_movieRepository.Get().Select(m => new DisplayMovie(m, _categoryRepository.GetByMovieId(m.Id))));
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            CreateMovieForm createMovieForm = new CreateMovieForm();
            createMovieForm.Categories = _categoryRepository.Get().Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            return View(createMovieForm);
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMovieForm form)
        {
            if (ModelState.IsValid)
            {
                if (form.Categories.Count(sli => sli.Selected) > 0)
                {
                    try
                    {
                        _movieRepository.Insert(new Movie(form.Title, form.Year), form.Categories.Where(sli => sli.Selected).Select(sli => int.Parse(sli.Value)));
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Exception = ex.Message;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sélectionnez au moins une catégorie");
                }
            }

            return View(form);
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = _movieRepository.Get(id);

            if (movie is null)
                return RedirectToAction(nameof(Index));

            IEnumerable<int> categories = _categoryRepository.GetByMovieId(movie.Id).Select(c => c.Id);

            UpdateMovieForm updateMovieForm = new UpdateMovieForm() { Id = movie.Id, Title = movie.Title, Year = movie.Year };

            updateMovieForm.Categories = _categoryRepository.Get().Select(c => new SelectListItem(c.Name, c.Id.ToString(), categories.Contains(c.Id))).ToList();
            return View(updateMovieForm);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateMovieForm form)
        {
            if (ModelState.IsValid)
            {
                if (form.Categories.Count(sli => sli.Selected) > 0)
                {
                    try
                    {
                        _movieRepository.Update(id, new Movie(form.Title, form.Year), form.Categories.Where(sli => sli.Selected).Select(sli => int.Parse(sli.Value)));
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Exception = ex.Message;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sélectionnez au moins une catégorie");
                }
            }

            return View(form);
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
