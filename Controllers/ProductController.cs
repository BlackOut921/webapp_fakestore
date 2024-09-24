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
		private readonly FakeProductDbContext productDb;
		public ProductController(FakeProductDbContext dbContext)
		{
			this.productDb = dbContext;

			FakeProductModel testNone = new FakeProductModel
			{
				Name = "_name_",
				Description = "_description_",
				Price = 1.23,
				ProductCategory = FakeProductModel.Category.None,
				Keywords = ["test", "product"]
			};

			FakeProductModel testClothing = new FakeProductModel
			{
				Name = "_clothing_name_",
				Description = "_clothing_description_",
				Price = 1.23,
				ProductCategory = FakeProductModel.Category.Clothing,
				Keywords = ["test", "product", "clothing"]
			};

			productDb.SaveChanges();
		}

		[HttpGet]
		public IActionResult Index() => View();

		[HttpPost]
		public async Task<IActionResult> ShowSearchResult(string query)
		{
			IEnumerable<FakeProductModel> products = await productDb.Products
				.Where(i => i.Name.Contains(query) || i.Keywords.Contains(query))
				.ToListAsync();

			FakeSearchResult result = new FakeSearchResult
			{
				Query = query,
				Products = products
			};

			return View(nameof(Index), result);
		}
	}
}