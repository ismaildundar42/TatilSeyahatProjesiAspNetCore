using Microsoft.AspNetCore.Mvc;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    public class HakkimizdaController : Controller
    {


        private readonly Context _context;

        public HakkimizdaController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var degerler = _context.tbl_hakkimizda.ToList();
            return View(degerler);
        }
    }
}
