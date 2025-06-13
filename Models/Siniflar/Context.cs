using Microsoft.EntityFrameworkCore;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Admin> tbl_admin { get; set; }
        public DbSet<Adresim> tbl_adres { get; set; }
        public DbSet<Anasayfa> tbl_anasayfa { get; set; }
        public DbSet<Blog> tbl_blog { get; set; }
        public DbSet<Hakkimizda> tbl_hakkimizda { get; set; }
        public DbSet<Iletisim> tbl_iletisim { get; set; }
        public DbSet<Yorumlar> tbl_yorumlar { get; set; }
        public DbSet<SoruCevap> tbl_sorucevap { get; set; }

    }
}
