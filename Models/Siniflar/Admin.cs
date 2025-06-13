using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
