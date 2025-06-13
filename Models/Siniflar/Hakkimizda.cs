using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaId { get; set; }
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }
    }
}
