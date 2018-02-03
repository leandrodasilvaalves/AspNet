using System.Data.Entity;

namespace GaleriaDeImagens.Models
{
    public class GalleryContext : DbContext
    {       
        public GalleryContext():base("DefaultConnection")
        {
        }

        public DbSet<Photo> Photos { get; set; }
    }
}