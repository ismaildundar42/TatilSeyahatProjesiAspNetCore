using Microsoft.AspNetCore.Mvc;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }
        HomePageViewModel hpvm = new HomePageViewModel();
        public IActionResult Index()
        {
           //  hpvm.SliderBlog = _context.tbl_blog.ToList();
            var degerler = _context.tbl_blog.ToList();
            
            return View(degerler);
        }

        public IActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var blogGetir = _context.tbl_blog
                .OrderByDescending(x => x.BlogId)
                .Take(3)
                .ToList();


            return PartialView(blogGetir);
        }

        public PartialViewResult Partial2()
        {
            var deger = _context.tbl_blog.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = _context.tbl_blog.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var degerler = _context.tbl_blog.OrderByDescending(x =>x.BlogId).Take(3).ToList();
            return PartialView(degerler);
        }
    }
}
