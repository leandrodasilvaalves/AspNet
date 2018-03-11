using System;
using System.Linq;

namespace CRUD_EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework acessando o PostgreSql");
            
            var db = new PostgreContext();
            db.Funcionarios.ToList()
                .ForEach(f => Console.WriteLine(f.Nome));
            
            Console.ReadKey();
        }
    }
}


/*
 
     Só funcionou depois que eu atualizaei todos os pacotes via nuget e descomentei a linha
     <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />      
     pois havia visto um tutorial dizendo para comentar. 
     
     */
