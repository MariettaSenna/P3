using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevelopmentPeriode3.Repository;

namespace WebdevelopmentPeriode3.Pages.Ober;

public class Bestellen : PageModel
{
    public void OnGet()
    {

    }

    public List<Category> Categories
    {
        get { return new CategoryRepository().Get(); }
    }


    public List<Product> Products
    {
        get { return new ProductRepository().Get(CategoryId); }
    }

    [BindProperty(SupportsGet = true)] public int CategoryId { get; set; }


}

