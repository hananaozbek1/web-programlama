using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HealthyLife.Data;
using HealthyLife.Models;

namespace HealthyLife.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string ConfirmPassword { get; set; }
        [BindProperty] public DateTime BirthDate { get; set; }
        [BindProperty] public string Gender { get; set; }

        public IActionResult OnPost()
        {
            if (Password != ConfirmPassword)
            {
                TempData["error"] = "Şifreler eşleşmiyor!";
                return Page();
            }

            _context.Users.Add(new User
            {
                Username = Username,
                Email = Email,
                Password = Password, // hashlenmeli
                BirthDate = BirthDate,
                Gender = Gender
            });
            _context.SaveChanges();

            HttpContext.Session.SetString("user", Username);
            return RedirectToPage("/Index");
        }
    }
}
