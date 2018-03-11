using CrudEntityFramework;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OracleContext())
            {
                db.Clientes.ToList()
                    .ForEach(c => Console.WriteLine("Id: {0} | Nome: {1}", c.Id, c.Nome));
            }

            Console.ReadKey();
        }
    }
}
