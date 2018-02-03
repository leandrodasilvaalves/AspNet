using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMariaDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Contexto db = new Contexto();
            if (db.Pessoas.Count() == 0)
            {
                var pessoas = new List<Pessoa>
                {
                    new Pessoa{ Nome = "Leandro Alves", Idade = 31},
                    new Pessoa{ Nome = "Francisco Alves", Idade = 68},
                    new Pessoa{ Nome = "Antonio Alves", Idade = 89}
                };

                db.Pessoas.AddRange(pessoas);
                db.SaveChanges();
            }

            var listaPessoas = db.Pessoas.ToList();
            Console.WriteLine("Lista de Pessoas");
            Console.WriteLine(new String('-', 30));
            foreach (var p in listaPessoas)
            {
                Console.WriteLine("Nome: {0} - Idade: {1}", p.Nome, p.Idade);
            }
            Console.ReadKey();
        }


    }
}
