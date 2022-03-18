﻿using Microsoft.AspNetCore.Mvc;
using UdemyProject.Data;
using UdemyProject.Models;

namespace UdemyProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
        _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _db.Categories;
            return View(categorylist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id is null || id ==0)
            { return NotFound(); }

            var categoryfromdb = _db.Categories.Find(id);
            if(categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
