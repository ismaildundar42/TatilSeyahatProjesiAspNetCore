using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Anasayfa
    {
        [Key]
        public int AnasayfaId { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
    }
}
