namespace ShopFuji.Models
{
	public class ImageViewModel
	{
		public List<string> Images { get; set; }
		public int Id { get; set; }	
		public string Name { get; set; }	
		public decimal Price { get; set; }
		public string Description { get; set; }
		public  string Brand { get; set; }
		public  string Color { get; set; }
		public  List<string> Size { get; set; }
		public  string Gender { get; set; }
		public  decimal Rating { get; set; }
		public int selectQuantity {  get; set; }	
		
	}
}
