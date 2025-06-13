using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Adresim
    {
        [Key]
        public int AdresId { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string AcikAdres { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Konum { get; set; }
    }
}
