using System.Collections.Generic;

namespace Model.Entities
{
    public class Categoria
    {
        public int CategoryID { get; private set; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new List<Produto>();
        }
    }
}
