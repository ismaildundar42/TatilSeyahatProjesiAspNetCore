using System.ComponentModel.DataAnnotations;

namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class SoruCevap
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Soru alanı boş bırakılamaz.")]
        [StringLength(250, ErrorMessage = "Soru en fazla 250 karakter olabilir.")]
        public string Soru { get; set; }

        [Required(ErrorMessage = "Cevap alanı boş bırakılamaz.")]
        public string Cevap { get; set; }
    }
}
