using Microsoft.AspNetCore.Mvc;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    public class IletisimController : Controller
    {
        private readonly Context _context;

        public IletisimController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Iletisim i)
        {
            _context.tbl_iletisim.Add(i);
            _context.SaveChanges();
            ViewBag.Basarili = "Mesajınız başarıyla gönderildi.";
            return View(); // formu tekrar gösterir, mesajla birlikte
        }

    }
}
