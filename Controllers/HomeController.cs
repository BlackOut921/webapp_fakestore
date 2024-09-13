using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapp_fakestore.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index() => View();
	}
}