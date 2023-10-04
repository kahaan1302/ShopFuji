using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ShopFuji.Data;
using ShopFuji.Migrations;
using ShopFuji.Models;
using System.Security.Cryptography;

namespace ShopFuji.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopFujiDbContext _context;

        public ProductsController(ShopFujiDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int? id)
        {
            var tempimages = _context.Images.Where(x => x.prodId == id).Select(x => x.Image1).ToList();
            var tempsizes = _context.Images.Where(x => x.prodId == id).Select(x => x.Size).ToList();
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productDetails = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDetails == null)
            {
                return NotFound();
            }

            var imageVM = new ImageViewModel
            {

                Images = tempimages,
                Id = productDetails.Id,
                Brand = productDetails.Brand,
                Rating = productDetails.Rating,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Color = productDetails.Color,
                Size = tempsizes,
                Gender = productDetails.Gender,
                Price = productDetails.Price,
            };
            return View(imageVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("UserId,ProductName,Price,Image, ProductId, Quantity, IsAdded")] CartItem cart)
        {



            //cart.UserId = UserManager.GetUserId(User)!;


            cart.UserId = "";
            cart.IsAdded = true;
            _context.CartItems.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            //return View(cart);
        }



        public async Task<IActionResult> Cart()
        {

            // Retrieve the current user's ID (if applicable)
            var cartItems = _context.CartItems.ToList();

            // Calculate total price and quantity
            decimal totalPrice = cartItems.Sum(ci => ci.Price * ci.Quantity);
            int totalQuantity = cartItems.Sum(ci => ci.Quantity);

            // Create a CartViewModel to pass data to the view
            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems,
                TotalPrice = totalPrice,
                TotalQuantity = totalQuantity
            };

            return View(cartViewModel);


        }

        [HttpPost]
        public async Task<IActionResult> Cart(CartItem cart, int? id2)
        {

            var cartItem = await _context.CartItems.FindAsync(id2);

            if (cartItem != null)
            {
                cart.IsAdded = false;
                _context.CartItems.Remove(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Cart));
            }
            return View(cart);
        }



        public async Task<IActionResult> OrderInfo()
        {
            return View();
        }


    }
}
