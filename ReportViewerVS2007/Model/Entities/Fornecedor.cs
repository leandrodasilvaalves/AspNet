using System.Collections.Generic;

namespace Model.Entities
{
    public class Fornecedor
    {
        public int SupplierID { get; private set; }
        public string CompanyName { get; private set; }
        public string ContactName { get; private set; }
        public string ContactTitle { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public Fornecedor()
        {
            Produtos = new List<Produto>();
        }
    }
}
