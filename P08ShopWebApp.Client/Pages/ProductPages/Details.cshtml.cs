using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P08ShopWebApp.Client.Models;
using P08ShopWebApp.Client.Data;

namespace P08ShopWebApp.Client.Pages.ProductPages;

public class DetailsModel : PageModel
{
    private readonly ShopContext _context;
    public DetailsModel(ShopContext context)
    {
        _context = context;
    }

    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        if (product is null)
        {
            return NotFound();
        }
        else
        {
            Product = product;
        }

        return Page();
    }
}
