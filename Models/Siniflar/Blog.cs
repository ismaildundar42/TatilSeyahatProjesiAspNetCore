using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string BlogResim { get; set; }
        public DateTime Tarih { get; set; }
        public ICollection<Yorumlar> yorumlars { get; set; }
    }
}
