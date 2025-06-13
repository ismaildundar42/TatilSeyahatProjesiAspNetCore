using Microsoft.AspNetCore.Mvc;
using TatilSeyahatProjesiCore.Models.Siniflar;
using X.PagedList.Extensions;

namespace TatilSeyahatProjesiCore.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context _context;

        public BlogController(Context context)
        {
            _context = context;
        }
        BlogYorum by = new BlogYorum();
        public IActionResult Index(int page = 1) // sadece parametre eklendi
        {
            var by = new BlogYorum();

            // SADECE BURASI DEĞİŞTİ
            by.BlogDeger1 = _context.tbl_blog.ToPagedList(page, 5); // Sayfalama

            by.BlogDeger2 = _context.tbl_blog
                .OrderByDescending(x => x.BlogId)
                .Take(4)
                .ToList();

            by.YorumDeger2 = _context.tbl_yorumlar
                .OrderByDescending(y => y.YorumId)
                .Take(5)
                .Select(y => new SonYorumDto
                {
                    BlogId = y.BlogId,
                    TakmaAd = y.TakmaAd,
                    BlogBaslik = y.Blog.Baslik
                })
                .ToList();

            return View(by);
        }


        public IActionResult BlogDetay(int id)
        {
            var by = new BlogYorum();

            by.BlogDeger1 = _context.tbl_blog.Where(x => x.BlogId == id).ToList();
            by.YorumDeger1 = _context.tbl_yorumlar.Where(x => x.BlogId == id).ToList();
            by.BlogDeger2 = _context.tbl_blog.OrderByDescending(x => x.BlogId).Take(4).ToList();

            by.YorumDeger2 = _context.tbl_yorumlar
                .OrderByDescending(x => x.YorumId)
                .Take(5)
                .Select(y => new SonYorumDto
                {
                    BlogId = y.BlogId,
                    TakmaAd = y.TakmaAd,
                    BlogBaslik = y.Blog.Baslik
                }).ToList();

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult YorumYap(Yorumlar y)
        {
            _context.tbl_yorumlar.Add(y);
            _context.SaveChanges();
            return RedirectToAction("BlogDetay", new { id = y.BlogId });
        }
        public PartialViewResult DPartial1()
        {
            // Bu method kullanılmayabilir ama bırakalım yedek kalsın
            var blogGetir = _context.tbl_blog.OrderByDescending(x => x.BlogId).Take(4).ToList();
            return PartialView(blogGetir);
        }
        public PartialViewResult DPartial2()
        {
            var yorumlar = _context.tbl_yorumlar
        .OrderByDescending(x => x.YorumId)
        .Take(5)
        .Select(y => new SonYorumDto
        {
            TakmaAd = y.TakmaAd,
            BlogBaslik = y.Blog.Baslik
        })
        .ToList();

            return PartialView(yorumlar);
        }

    }
}
