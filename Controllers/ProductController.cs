using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using webapp_fakestore.Models;

namespace webapp_fakestore.Controllers
{
	[AllowAnonymous]
	public class ProductController : Controller
	{
		private readonly FakeProductDbContext productDbContext;
		public ProductController(FakeProductDbContext dbContext)
		{
			this.productDbContext = dbContext;
		}

		[HttpGet]
		public IActionResult Index() => View();

		[HttpGet]
		public IActionResult Clothing()
		{
			return View(
				nameof(Index), 
				new FakeSearchResult { 
					Query = "Category: clothing", 
					Products = GetProductsBy(FakeProductModel.Category.Clothing) 
				});
		}

		[HttpGet]
		public IActionResult Electronics()
		{
			return View(
				nameof(Index),
				new FakeSearchResult
				{
					Query = "Category: electronics",
					Products = GetProductsBy(FakeProductModel.Category.Electronics)
				});
		}

		[HttpPost]
		public async Task<IActionResult> GetSearchResult(string query)
		{
			IEnumerable<FakeProductModel> products = await productDbContext.Products
				.Where(i => i.Name.Contains(query) || i.KeywordString.Contains(query))
				.ToListAsync();

			return View(
				nameof(Index),
				new FakeSearchResult { Query = query, Products = products }
				);
		}

		private IEnumerable<FakeProductModel> GetProductsBy(FakeProductModel.Category c) => 
			productDbContext.Products.Where(i => i.ProductCategory == c);

		[HttpGet]
		public IActionResult AddProduct() => View();

		[HttpPost]
		public async Task<string> AddProduct(FakeProductModel model)
		{
			if(ModelState.IsValid)
			{
				await productDbContext.AddAsync<FakeProductModel>(model);
				await productDbContext.SaveChangesAsync();

				return "Product added";
			}

			return "Failed to add product";
		}
	}
}