namespace CRUD_EntityFramework
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
