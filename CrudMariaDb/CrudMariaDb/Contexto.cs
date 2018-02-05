using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMariaDb
{
    public class Contexto : DbContext
    {
        public Contexto() : base("mariadbConexao")
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
