using System;
using Microsoft.AspNetCore.Mvc;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.ViewModels;

namespace TesteSWFast.IO.Site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: Product
        public IActionResult Index()
        {
            return View(_productAppService.GetAll());
        }

        // GET: Product/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModel = _productAppService.GetById(id.Value);
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            _productAppService.Insert(productViewModel);

            return View(productViewModel);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModel = _productAppService.GetById(id.Value);
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            _productAppService.Update(productViewModel);

            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModel = _productAppService.GetById(id.Value);
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _productAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
