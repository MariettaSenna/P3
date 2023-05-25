using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevelopmentPeriode3.Repository;

namespace WebdevelopmentPeriode3.Pages;

public class Register : PageModel
{
    public void OnGet()
    {
        
    }
    [BindProperty]
    public Gebruiker Gebruiker { get; set; }

    public IActionResult OnPostRegister()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        new RegisterRepository().Insert(Gebruiker.Username, Gebruiker.Password, Gebruiker.Mail);
        return Page();
    }
    
}