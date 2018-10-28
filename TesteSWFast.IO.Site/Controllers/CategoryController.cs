﻿using System;
using Microsoft.AspNetCore.Mvc;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.ViewModels;

namespace TesteSWFast.IO.Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // GET: Category
        [Route("categoria")]
        public IActionResult Index()
        {
            return View(_categoryAppService.GetAll());
        }

        // GET: Category/Details/5
        [Route("categoria/detalhes/{id:Guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = _categoryAppService.GetById(id.Value);
            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        // GET: Category/Create
        [Route("categoria/inserir")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categoria/inserir")]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return View(categoryViewModel);

            _categoryAppService.Insert(categoryViewModel);

            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        [Route("categoria/alterar/{id:Guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = _categoryAppService.GetById(id.Value);

            if (categoryViewModel == null)
            {
                return NotFound();
            }
            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categoria/alterar/{id:Guid}")]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {

            if (!ModelState.IsValid) return View(categoryViewModel);

            _categoryAppService.Update(categoryViewModel);

            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        [Route("categoria/excluir/{id:Guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = _categoryAppService.GetById(id.Value);
            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("categoria/excluir/{id:Guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _categoryAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
