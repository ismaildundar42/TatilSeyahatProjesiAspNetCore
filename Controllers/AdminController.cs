using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TatilSeyahatProjesiCore.Models.Siniflar;

namespace TatilSeyahatProjesiCore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.tbl_blog.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBlogEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBlogEkle(Blog b)
        {
            _context.tbl_blog.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BlogSil(int id)
        {
            var silinecekBlog = _context.tbl_blog.Find(id);
            _context.tbl_blog.Remove(silinecekBlog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BlogGetir(int id)
        {
            var guncellenecekBlog = _context.tbl_blog.Find(id);
            return View(guncellenecekBlog);
        }
        public IActionResult BlogGuncelle(Blog b)
        {
            var blog = _context.tbl_blog.Find(b.BlogId);
            blog.Baslik = b.Baslik;
            blog.Aciklama = b.Aciklama;
            blog.BlogResim = b.BlogResim;
            blog.Tarih = b.Tarih;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult YorumListesi(int sayfa = 1)
        {
            int sayfaBoyutu = 10;
            var yorumlar = _context.tbl_yorumlar
                            .Include(y => y.Blog)
                            .OrderByDescending(y => y.YorumId)
                            .Skip((sayfa - 1) * sayfaBoyutu)
                            .Take(sayfaBoyutu)
                            .ToList();

            int toplamKayit = _context.tbl_yorumlar.Count();
            ViewBag.ToplamSayfa = (int)Math.Ceiling((double)toplamKayit / sayfaBoyutu);
            ViewBag.SuankiSayfa = sayfa;

            return View(yorumlar);
        }

        public IActionResult YorumSil(int id)
        {
            var silinecekYorum = _context.tbl_yorumlar.Find(id);
            _context.tbl_yorumlar.Remove(silinecekYorum);
            _context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public IActionResult HakkimizdaListesi()
        {
            var deger = _context.tbl_hakkimizda.ToList();
            return View(deger);
        }
        public IActionResult HakkimizdaSil(int id)
        {
            var silinecekDeger = _context.tbl_hakkimizda.Find(id);
            _context.tbl_hakkimizda.Remove(silinecekDeger);
            _context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
        public IActionResult HakkimizdaGetir(int id)
        {
            var deger = _context.tbl_hakkimizda.Find(id);
            return View(deger);
        }
        public IActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hak = _context.tbl_hakkimizda.Find(h.HakkimizdaId);
            hak.FotoUrl = h.FotoUrl;
            hak.Aciklama = h.Aciklama;
            _context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
        [HttpGet]
        public IActionResult HakkimizdaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HakkimizdaEkle(Hakkimizda hak)
        {
            _context.tbl_hakkimizda.Add(hak);
            _context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
        public IActionResult IletisimListesi()
        {
            var deger = _context.tbl_iletisim.ToList();
            return View(deger);
        }
        public IActionResult IletisimSil(int id)
        {
            var silinecekDeger = _context.tbl_iletisim.Find(id);
            _context.tbl_iletisim.Remove(silinecekDeger);
            _context.SaveChanges();
            return RedirectToAction("IletisimListesi");
        }
        public IActionResult SSSListesi()
        {
            var deger = _context.tbl_sorucevap.ToList();
            return View(deger);
        }
        [HttpGet]
        public IActionResult SSSEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SSSEkle(SoruCevap sc)
        {
            _context.tbl_sorucevap.Add(sc);
            _context.SaveChanges();
            return RedirectToAction("SSSListesi");
        }
        public IActionResult SSSSil(int id)
        {
            var silinecekSSS = _context.tbl_sorucevap.Find(id);
            _context.tbl_sorucevap.Remove(silinecekSSS);
            _context.SaveChanges();
            return RedirectToAction("SSSListesi");
        }

        [HttpGet]
        public IActionResult SSSGuncelle(int id)
        {
            var sss = _context.tbl_sorucevap.Find(id);
            if (sss == null) return NotFound();
            return View(sss);
        }


        [HttpPost]
        public IActionResult SSSGuncelle(SoruCevap sc)
        {
            if (!ModelState.IsValid)
            {
                return View("SSSGetir", sc);
            }

            var sss = _context.tbl_sorucevap.Find(sc.Id);
            if (sss == null) return NotFound();

            sss.Soru = sc.Soru;
            sss.Cevap = sc.Cevap;

            _context.SaveChanges();
            return RedirectToAction("SSSListesi");
        }

        public IActionResult AdminListesi()
        {
            var degerler = _context.tbl_admin.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniAdminEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniAdminEkle(Admin admin)
        {
            _context.tbl_admin.Add(admin);
            _context.SaveChanges();
            return RedirectToAction("AdminListesi");
        }
        public IActionResult AdminSil(int id)
        {
            var silinecekAdmin = _context.tbl_admin.Find(id);
            _context.tbl_admin.Remove(silinecekAdmin);
            _context.SaveChanges();
            return RedirectToAction("AdminListesi");
        }
        public IActionResult AdminGetir(int id)
        {
            var deger = _context.tbl_admin.Find(id);
            return View(deger);
        }
        public IActionResult AdminGuncelle(Admin a)
        {
            var admin = _context.tbl_admin.Find(a.AdminId);
            admin.KullaniciAdi = a.KullaniciAdi;
            admin.Sifre = a.Sifre;
            _context.SaveChanges();
            return RedirectToAction("AdminListesi");
        }
    }
}
