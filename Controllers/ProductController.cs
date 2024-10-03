using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using webapp_fakestore.Models;

namespace webapp_fakestore.Controllers
{
	[AllowAnonymous]
	public class ProductController(FakeProductDbContext dbContext) : Controller
	{
		private readonly FakeProductDbContext productDbContext = dbContext;		

		[HttpGet]
		public IActionResult Index() => View();

		[HttpGet]
		public IActionResult Clothing()
		{
			//Return all clothing products
			return View(
				nameof(Index), 
				new FakeSearchResult { 
					Query = "Category: clothing", 
					Products = GetProductsByCategory(FakeProductModel.Category.Clothing) 
				});
		}

		[HttpGet]
		public IActionResult Electronics()
		{
			//Return all electronic products
			return View(
				nameof(Index),
				new FakeSearchResult
				{
					Query = "Category: electronics",
					Products = GetProductsByCategory(FakeProductModel.Category.Electronics)
				});
		}

		[HttpPost]
		public async Task<IActionResult> GetSearchResult(string query)
		{
			//Get all products that have query in name or tags/keywords (maybe add description??)
			IEnumerable<FakeProductModel> products = await productDbContext.Products
				.Where(i => i.Name.Contains(query) || i.Tags.Contains(query))
				.ToListAsync();

			return View(
				nameof(Index),
				new FakeSearchResult { Query = query, Products = products }
				);
		}

		//Get product from db with id from asp-route-id on anchor tag
		[HttpGet]
		public async Task<IActionResult> ViewProduct(int id) => 
			View(await productDbContext.FindAsync<FakeProductModel>(id) ?? new FakeProductModel { Name = string.Empty });

		[HttpGet]
		public IActionResult AddProduct() => View();

		[HttpPost]
		public async Task<IActionResult> AddProduct(FakeProductModel model)
		{
			if(ModelState.IsValid)
			{
				await productDbContext.AddAsync<FakeProductModel>(model);
				await productDbContext.SaveChangesAsync();

				return View(nameof(Index));
			}

			ModelState.AddModelError(string.Empty, "Failed adding new product");
			return View(nameof(AddProduct));
		}

		private IEnumerable<FakeProductModel> GetProductsByCategory(FakeProductModel.Category c) =>
			productDbContext.Products.Where(i => i.ProductCategory == c);
	}
}