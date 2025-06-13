namespace TatilSeyahatProjesiCore.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> BlogDeger1 { get; set; }
        public IEnumerable<Blog> BlogDeger2 { get; set; }
        public IEnumerable<Yorumlar> YorumDeger1 { get; set; }
            public IEnumerable<SonYorumDto> YorumDeger2 { get; set; }

    }
}
