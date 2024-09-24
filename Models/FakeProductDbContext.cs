using Microsoft.EntityFrameworkCore;

namespace webapp_fakestore.Models
{
	public class FakeProductDbContext : DbContext
	{
		public DbSet<FakeProductModel> Products { get; set; }

		public FakeProductDbContext(DbContextOptions<FakeProductDbContext> options)
			: base(options)
		{
			//
		}
	}
}
