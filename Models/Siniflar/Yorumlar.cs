using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int YorumId { get; set; }
        public string TakmaAd { get; set; }
        public string Mail { get; set; }
        public string YorumIcerik { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
