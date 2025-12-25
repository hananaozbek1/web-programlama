using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyLife.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
            Response.Redirect("/Index");
        }
    }
}
