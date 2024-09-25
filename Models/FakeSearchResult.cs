using System.ComponentModel.DataAnnotations;

namespace webapp_fakestore.Models
{
    public class FakeSearchResult
    {
        [Required]
        public string Query { get; set; } = string.Empty;

        public IEnumerable<FakeProductModel> Products { get; set; } = [];
    }
}
