using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SESEWebsite.Pages.Account
{
    public class LoginModel : PageModel
    {
        public Credential credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            //Veryfy
            if(credential.UserName=="SESE" && credential.Password == "Jamhaka")
            {
                //Security Concept
                var claims = new List<Claim> { new Claim(ClaimTypes.Name,"SESE" ),
                new Claim(ClaimTypes.Email,"jamhakatechnology@gmail.com")
                };
                //Identity claim
                var Identity = new ClaimsIdentity(claims, "MyCokieAutho");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(Identity);
                await HttpContext.SignInAsync("MyCokies", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            
            return Page();

            

        }

        public class Credential
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
