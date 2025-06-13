using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var bilgiler = _context.tbl_admin
                .FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);

            if (bilgiler != null)
            {
                // 1. Claims tanımla
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, bilgiler.KullaniciAdi),
                    new Claim(ClaimTypes.Role, "Admin") // Rol kullanıyorsan
                };

                // 2. Kimlik oluştur
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // 3. Giriş yap
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // 4. Session içine kullanıcıyı yaz
                HttpContext.Session.SetString("KullaniciAdi", bilgiler.KullaniciAdi);

                // 5. Yönlendir
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
