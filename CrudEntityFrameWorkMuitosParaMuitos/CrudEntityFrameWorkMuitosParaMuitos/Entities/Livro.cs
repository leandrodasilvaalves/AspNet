using System.Collections.Generic;

namespace CrudEntityFrameWorkMuitosParaMuitos.Entities
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public virtual ICollection<LivroAutor> LivrosAutores { get; set; }

        public Livro()
        {
            LivrosAutores = new List<LivroAutor>();
        }
    }
}
