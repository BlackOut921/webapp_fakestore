using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapp_fakestore.Controllers
{
	[AllowAnonymous]
	public class ProductController : Controller
	{
		[HttpGet]
		public IActionResult Clothing() => View();
	}
}
