﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService ?? throw new ArgumentNullException(nameof(productService));
		}

		public async Task<IActionResult> ProductIndex()
		{
			var products = _productService.FindAllProducts();
			return View(products);
		}
		public async Task<IActionResult> ProductCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ProductCreate(ProductModel model)
		{
			if (ModelState.IsValid)
			{
				var response = _productService.CreateProduct(model);
				if (response != null)
				{
					return RedirectToAction(nameof(response));
				}
			}

			return View(model);
		}

		public async Task<IActionResult> ProductUpdate(int id)
		{
			var model = await _productService.FindProductById(id);
			if (model != null)
			{
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductUpdate(ProductModel model)
		{
			if (ModelState.IsValid)
			{
				var response = _productService.UpdateProduct(model);
				if (response != null)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}

			return View(model);
		}

		public async Task<IActionResult> ProductDelete(int id)
		{
			var model = await _productService.FindProductById(id);
			if (model != null)
			{
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProductById(ProductModel model)
		{
			var isUpdated = await _productService.DeleteProductById(model.Id);
			if (isUpdated)
			{
				return RedirectToAction(nameof(ProductIndex));
			}
			return View(model);
		}
	}
}
