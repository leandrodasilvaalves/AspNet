using System.Collections.Generic;

namespace CRUD_EntityFramework
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public Cargo()
        {
            Funcionarios = new List<Funcionario>();
        }
    }
}
