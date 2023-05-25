using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevelopmentPeriode3.Repository;

namespace WebdevelopmentPeriode3.Pages;

public class Overzicht : PageModel
{
    // [BindProperty] public int Counter1 { get; set; } = 0;
    // [BindProperty] public float Price { get; set; } = 2.5f;

    public List<OrderLineRepository.ProductOverzicht> ProductOverzichts
    {
        get { return new OrderLineRepository().GetOverzicht(1); }
    }
    public void OnGet()
    {

    }

 

    public void OnPostIncrement(int ProductId, int TableId)
    {
        new OrderLineRepository().Order(ProductId,TableId, 1);
    }
    
    public void OnPostDecrement(int ProductId, int TableId)
    {
        new OrderLineRepository().Order(ProductId,TableId, -1);
    }
}