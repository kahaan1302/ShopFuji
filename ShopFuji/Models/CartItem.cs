namespace ShopFuji.Models
{
	public class CartItem
	{

		public int Id { get; set; }  
		public int ProductId { get; set; }  
		public decimal Price { get; set; }  
		public string ProductName { get; set; }
		public string UserId {  get; set; }
		public string Image {  get; set; }
		public int Quantity { get; set; }
		public bool IsAdded { get; set; }
	
	}
}
