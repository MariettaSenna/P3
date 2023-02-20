using System.ComponentModel.DataAnnotations;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.X509;
using WebdevelopmentPeriode3.Repository;

namespace WebdevelopmentPeriode3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public LoginModel LoginModel { get; set; }
        public bool IsLogin { get; set; } = false;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IEnumerable<User> Users { get; set; }

        public IActionResult OnPost()
        {
            if (LoginModel.Username == "TestUser" && LoginModel.Password == "123")
            {
                HttpContext.Session.SetInt32("UserId", 1);
                return RedirectToPage("Ober/Overzicht");
            }
            else
            {
                IsLogin = false;
            }

            return Page();
        }
    }


    public class LoginModel
    {
        [Display(Name = "Gebruikersnaam")] public string Username { get; set; }

        [Display(Name = "Wachtwoord")] public string Password { get; set; }
    }
}


