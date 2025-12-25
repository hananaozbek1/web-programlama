using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HealthyLife.Data;
using System.Linq;

namespace HealthyLife.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user == null)
            {
                TempData["error"] = "Kullanıcı adı veya şifre yanlış!";
                return Page();
            }

            HttpContext.Session.SetString("user", user.Username);
            return RedirectToPage("/Index");
        }
    }
}
