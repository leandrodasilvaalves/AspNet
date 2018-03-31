namespace Model.Entities
{
    public class Produto
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public int SupplierID { get; private set; }

        public virtual Categoria Categoria { get; set; }
        public int CategoryID { get; private set; }

        public decimal UnitPrice { get; private set; }
    }
}
