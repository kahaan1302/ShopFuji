using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace ShopFuji.Models;



public class ProductViewModel
{
    public List<Product> Products { get; set; }
    public List<String> Brands { get; set; }
    public SelectList? sortOrder {  get; set; }
    public int rangeFilter { get; set; }
   // public List<BrandViewModel> BrandCheckboxes { get; set; }
    public string? SearchString { get; set; }
    public string? SortString { get; set; }
    public string? SelectBrand {  get; set; }
    public int MinPrice { get; set; }  
    public int MaxPrice { get; set; }  
    

}

