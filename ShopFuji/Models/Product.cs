using System.ComponentModel.DataAnnotations;

namespace ShopFuji.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; } = 0;
		public string Color { get; set; }
		public string Brand { get; set; }
		public string Size { get; set; }
		public string Gender { get; set; }
		public decimal Rating {  get; set; }
		public string Image { get; set; }



	}
}
