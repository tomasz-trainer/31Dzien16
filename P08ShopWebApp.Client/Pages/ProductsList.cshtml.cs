using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P08ShopWebApp.Client.Data;
using P08ShopWebApp.Client.Models;

namespace P08ShopWebApp.Client.Pages
{
    public class ProductsListModel : PageModel
    {

        private readonly ShopContext _context;

        public List<Product> Products { get; set; } = new List<Product>();


        public ProductsListModel(ShopContext shopContext)
        {
            _context= shopContext;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}
