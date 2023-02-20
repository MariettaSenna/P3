using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Tls;

namespace WebdevelopmentPeriode3.Pages;

public class Test : PageModel
{
    // Geeft input van de gebruiker weer (Get Request)
    // public string Name { get; set; }
    //
    // public void OnGet([FromQuery] string name)
    // {
    //     Name = name;
    // }
    // Einde input (Get Request)


    [BindProperty] public int Counter1 { get; set; } = 0;
    [BindProperty] public float Price { get; set; } = 2.5f;

    public void OnGet()
    {

    }

    public void OnPostIncrement()
    {

        Counter1++;
    }

    public void OnPostDecrement()
    {

        Counter1--;
    }


    
}
