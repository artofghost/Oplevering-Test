using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DndNotes.Models;
using Logic;

namespace DndNotes.Controllers
{
    public class CategoryController : Controller
    {
        private User _user = new User();

        // GET: CategoryController
        public ActionResult Index()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            foreach (var category in _user.GetAllCategories())
            {
                categoryModels.Add(new CategoryModel(category));
            }
            return View(categoryModels);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel collection)
        {
            try
            {
                Category category = new Category();
                category.Name = collection.Name;
                category.Id = collection.Id;
                category.Icon = collection.Icon;
                category.Colour = collection.Colour;
                _user.CreateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _user.GetCategory(id);
            CategoryModel categoryModel = new CategoryModel(category);

            return View(categoryModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryModel collection)
        {
            try
            {
                Category category = new Category();
                category.Name = collection.Name;
                category.Id = collection.Id;
                category.Icon = collection.Icon;
                category.Colour = collection.Colour;
                category.UpdateCategory();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _user.GetCategory(id);

            CategoryModel categoryModel = new CategoryModel(category);

            return View(categoryModel);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryModel collection)
        {
            try
            {
                Category category = new Category();
                category.Id = collection.Id;
                _user.DeleteCategory(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
