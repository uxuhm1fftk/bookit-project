﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookit.Data;
using Bookit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookit.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public IActionResult Index()
        {
            var model = _db.Books;
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Gallery()
        {
            var model = _db.Books;
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult More(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
         
            _db.Books.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {

            //_db.Entry<Book>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Book model)
        {

            //_db.Entry<Book>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}