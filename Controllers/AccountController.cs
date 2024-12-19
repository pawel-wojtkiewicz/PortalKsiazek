using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PortalKsiazkowy.Models;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    // GET: /Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Nieprawidłowa nazwa użytkownika lub hasło.");
        }

        return View();
    }

    // GET: /Account/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    public async Task<IActionResult> Register(string username, string password)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                UserName = username,
                Email = username // Możesz dodać inne dane użytkownika, np. email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // Zalogowanie użytkownika po rejestracji
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View();
    }

    // Logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}