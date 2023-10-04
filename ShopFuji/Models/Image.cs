using System.ComponentModel.DataAnnotations;

namespace ShopFuji.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }
		public int prodId { get; set; }
		public string Image1 { get; set; }	
		public string Size { get; set; }
	}
}
