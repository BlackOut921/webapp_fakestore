using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_fakestore.Models
{
	public class FakeProductModel
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Product Name")]
		[DataType(DataType.Text)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Display(Name = "Product Description")]
		[DataType(DataType.Text)]
		public string Description { get; set; } = string.Empty;

		[Required]
		[Display(Name = "Price")]
		[DataType(DataType.Currency)]
		public double Price { get; set; } = 0.00;

		public enum Category { None, Clothing, Electronics, Jewellery };
		public Category ProductCategory { get; set; } = FakeProductModel.Category.None;

		[Display(Name = "Keywords")]
		[DataType(DataType.Text)]
		public string[]? Keywords { get; set; } = Array.Empty<string>();

		public FakeProductModel()
		{
			//
		}
	}
}
