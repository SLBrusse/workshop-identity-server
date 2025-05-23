using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Security.Claims;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string ErrorMessage { get; set; }

    public IActionResult OnGet(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        var user = TestUsers.Users.FirstOrDefault(u =>
            u.Username == "alice" && u.Password == "password");
        string text = "";
        if (user == null)
        {
            text = "hij is leeg bij "+ Username + "En" + Password;
            
        }

        //TestUsers.Users.ForEach(u => text += u.Username + " " + u.Password);

        if (user != null)
        {
            var claims = user.Claims.ToList();
            claims.Add(new Claim("sub", user.SubjectId));
            var identity = new ClaimsIdentity(claims, "password");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return Redirect("~/");
        }

        ErrorMessage = text;
        ViewData["ReturnUrl"] = returnUrl;
        return Page();
    }
}
