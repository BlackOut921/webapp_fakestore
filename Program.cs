using Microsoft.EntityFrameworkCore;

using webapp_fakestore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Connect to ProductDb
builder.Services.AddDbContext<FakeProductDbContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbRemote")));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();
//app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
app.Run();