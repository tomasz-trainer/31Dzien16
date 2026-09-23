using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P08ShopWebApp.Client.Models;
using P08ShopWebApp.Client.Data;

namespace P08ShopWebApp.Client.Pages.ProductPages;

public class IndexModel : PageModel
{
    private readonly ShopContext _context;

    public IndexModel(ShopContext context)
    {
        _context = context;
    }

    public IList<Product> Product { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Product = await _context.Products.ToListAsync();
    }
}
