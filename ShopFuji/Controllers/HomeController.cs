using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopFuji.Data;
using ShopFuji.Migrations;
using ShopFuji.Models;
using System.Diagnostics;

namespace ShopFuji.Controllers
{

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ShopFujiDbContext _context;

		public HomeController(ILogger<HomeController> logger, ShopFujiDbContext context)
		{
			_logger = logger;
			_context = context;
		}


		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Men(string SortString, string searchString, string SelectBrand, ProductViewModel model)
		{
			if (_context.Products == null)
			{
				return Problem("Entity set empty");
			}

			var products = from m in _context.Products select m;
	
			switch (SortString)
			{
				case "Price (Low - High)":
					products = products.OrderBy(model => model.Price);
					break;
				case "Price (High - Low)":
					products = products.OrderByDescending(model => model.Price);
					break;
				case "Latest Arrivals":
					products = products.OrderByDescending(model => model.Id); break;
				default:
					products = products.OrderBy(model => model.Name);
					break;
			}

			IQueryable<string> genreQuery = from m in _context.Products
											orderby m.Brand
											select m.Brand;

			int minPrice = model.MinPrice;
			int maxPrice = model.MaxPrice;

			/* var brandCheckboxes = await genreQuery
				 .Distinct()
				 .Select(brand => new BrandViewModel
				 {
					 Name = brand,
					 IsSelected = SelectBrand == brand // Set IsSelected based on the currently selected brand
				 })
				 .ToListAsync();
			*/
			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(s => s.Brand.Contains(searchString));
			}

			var productNameVM = new ProductViewModel
			{
				sortOrder = new SelectList(new List<string> { "ascending", "descending", "latest" }, SortString), 
				Products = await products.ToListAsync(),
				Brands = products.ToList().DistinctBy(X => X.Brand).Select(x => x.Brand).ToList(),
			};

			return View(productNameVM);
		}


		[HttpPost]
		public IActionResult Men([Bind("MinPrice,MaxPrice")] ProductViewModel model, List<string> size)
		{
			int minPrice = model.MinPrice;
			int maxPrice = model.MaxPrice;

			var filteredProducts = _context.Products
				.Where(product => product.Price >= minPrice && product.Price <= maxPrice)
				.ToList();

			//var filterSize = _context.Products.Where(product => product.Size == size).ToList();

			var filteredList = new ProductViewModel
			{
				Products = filteredProducts ,
				Brands = filteredProducts.ToList().DistinctBy(X => X.Brand).Select(x => x.Brand).ToList(),
			};
			return View("Men",filteredList);
		}



		/*
         public IActionResult Men()
         {
             ProductViewModel productViewModel = new ProductViewModel();
             productViewModel.Products = _context.Products.ToList();
             return View(productViewModel);
         }
        */


		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Women()
		{
			return View();
		}

		public IActionResult Kids()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
