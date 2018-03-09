using System.Collections.Generic;

namespace CrudEntityFrameWorkMuitosParaMuitos.Entities
{
    public class Autor
    {        
        public int AutorId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<LivroAutor> LivrosAutores { get; set; }

        public Autor()
        {
            LivrosAutores = new List<LivroAutor>();
        }
    }
}
