using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_fakestore.Models
{
	public class FakeProductModel
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "Product needs a display name")]
		[Display(Name = "Product Name")]
		[DataType(DataType.Text)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Product needs a description")]
		[Display(Name = "Product Description")]
		[DataType(DataType.Text)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Price needs to be set")]
		[Display(Name = "Price")]
		[DataType(DataType.Currency)]
		public double Price { get; set; } = 0.00;

		public enum Category { None, Clothing, Electronics, Jewellery };
		[Display(Name = "Category")]
		[EnumDataType(typeof(Category))]
		public Category ProductCategory { get; set; } = Category.None;

		//if productcategory == clothing || jewellery ? show_gender_cat : hide;
		public enum GenderTarget { None, Male, Female };
		[Display(Name = "Gender")]
		[EnumDataType(typeof(GenderTarget))]
		public GenderTarget ProductGenderTarget { get; set; } = GenderTarget.None;

		[Display(Name = "Tags")]
		[DataType(DataType.Text)]
		public string Tags { get; set; } = "tag";
	}
}
