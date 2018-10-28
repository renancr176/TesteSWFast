using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.ViewModels;

namespace TesteSWFast.IO.Site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ProductController(IProductAppService productAppService, ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }

        // GET: Product
        [Route("produto")]
        public IActionResult Index()
        {
            return View(_productAppService.GetAll());
        }

        // GET: Product/Details/5
        [Route("produto/detalhes/{id:Guid}")]
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
        [Route("produto/inserir")]
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_categoryAppService.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("produto/inserir")]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_categoryAppService.GetAll(), "Id", "Nome");
                return View(productViewModel);
            }

            _productAppService.Insert(productViewModel);

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        [Route("produto/alterar/{id:Guid}")]
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

            ViewBag.Categorias = new SelectList(_categoryAppService.GetAll(), "Id", "Nome");
            return View(productViewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("produto/alterar/{id:Guid}")]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_categoryAppService.GetAll(), "Id", "Nome");
                return View(productViewModel);
            }

            _productAppService.Update(productViewModel);

            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        [Route("produto/excluir/{id:Guid}")]
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
        [Route("produto/excluir/{id:Guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _productAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
