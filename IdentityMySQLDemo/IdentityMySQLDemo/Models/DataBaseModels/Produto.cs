using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityMySQLDemo.Models.DataBaseModels
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

    }
}