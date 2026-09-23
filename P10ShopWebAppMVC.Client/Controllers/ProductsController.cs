using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P10ShopWebAppMVC.Client.Data;
using P10ShopWebAppMVC.Client.Models;

namespace P10ShopWebAppMVC.Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetProductsAsync();
            if (!response.Success)
            {
                return Problem(response.Message);
            }

            return View(response.Data);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var response = await _productService.GetProductAsync(id.Value);
            if (!response.Success)
            {
                return Problem(response.Message);
            }
            return View(response.Data);

        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Barcode,Price,ReleaseDate")] Product product)
        {
           if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync(product);
                if (!response.Success)
                {
                    return Problem(response.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           if(id == null)
            {
                return NotFound();
            }
            var response = await _productService.GetProductAsync(id.Value);
            if (!response.Success)
            {
                return Problem(response.Message);
            }
            return View(response.Data);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Barcode,Price,ReleaseDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync(product);
                if (!response.Success)
                {
                    return Problem(response.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _productService.GetProductAsync(id.Value);
            if (!response.Success)
            {
                return Problem(response.Message);
            }
            return View(response.Data);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.Success)
            {
                return Problem(response.Message);
            }

            return RedirectToAction(nameof(Index));

        }

     
    }
}
