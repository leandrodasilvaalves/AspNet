using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCareas.Models
{
    public class Categoria
    {       
        public int CategoriaId { get; set; }

        public string Descricao { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}