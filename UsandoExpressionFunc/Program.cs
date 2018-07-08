using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UsandoExpressionFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new Contexto();
            contexto.Pessoas.AddRange(new List<Pessoa> {
                new Pessoa("Leandro", 'M', 32),
                new Pessoa("Meiry",'F',26),
                new Pessoa("Isa", 'F',9)
            });
            contexto.SaveChanges();
            Console.WriteLine("Dados Inclusos com sucesso");

            var pessoas = contexto.Pessoas.Where(Filtro("Leandro"));
            foreach(var p in pessoas)
                Console.WriteLine(p);

            Console.ReadKey();
        }

        public static Expression<Func<Pessoa, bool>> Filtro(string nome)
        {
            return x => x.Nome.Equals(nome);
        }
    }
}
