using Microsoft.AspNetCore.Mvc;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    public class SSSController : Controller
    {
        private readonly Context _context;

        public SSSController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sorular = _context.tbl_sorucevap.ToList();
            return View(sorular);;
        }
    }
}
