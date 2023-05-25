using System.ComponentModel.DataAnnotations;
using System.Configuration;
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
        private List<Gebruiker> _gebruikers;

        [BindProperty]
        public Gebruiker Gebruiker { get; set; }
        public bool IsLogin { get; set; } = false;

        public List<Gebruiker> Gebruikers
        {
            get
            {
                if (_gebruikers == null)
                {
                    _gebruikers = new GebruikerRepository().Get();
                }

                return _gebruikers;
            }
        }

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
            if (Gebruiker.Username == "TestUser" && Gebruiker.Password == "123")
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


    public class Gebruiker
    {
        public int UserId { get; set; }
        [Display(Name = "Gebruikersnaam")] public string Username { get; set; }

        [Display(Name = "Wachtwoord")] public string Password { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
    }
    

}


