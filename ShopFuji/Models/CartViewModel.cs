namespace ShopFuji.Models
{
    public class CartViewModel
    {
		public List<CartItem> CartItems { get; set; }  // List of items in the cart
		public decimal TotalPrice { get; set; }  // Total price of items in the cart
		public int TotalQuantity { get; set; }

		public CartViewModel()
		{
			CartItems = new List<CartItem>();
		}
	}
}
