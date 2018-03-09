using CrudEntityFrameWorkMuitosParaMuitos.Context;
using CrudEntityFrameWorkMuitosParaMuitos.Entities;
using System;

namespace CrudEntityFrameWorkMuitosParaMuitos
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LivrariaContexto db = new LivrariaContexto())
            {
                Autor autor1 = new Autor() { Nome = "Fulano" };
                Autor autor2 = new Autor() { Nome = "Cicrano" };

                Livro livro1 = new Livro() { Titulo = "Asp.Net MVC 5" };
                Livro livro2 = new Livro() { Titulo = "Angular Js Profissional" };

                livro1.LivrosAutores.Add(new LivroAutor() { Autor=autor1, Ano=2017 });
                livro1.LivrosAutores.Add(new LivroAutor() { Autor = autor2, Ano = 2017 });

                livro2.LivrosAutores.Add(new LivroAutor() { Autor = autor1, Ano = 2017 });
                livro2.LivrosAutores.Add(new LivroAutor() { Autor = autor2, Ano = 2017 });

                db.Livros.Add(livro1);
                db.Livros.Add(livro2);
                db.SaveChanges();

                //autor1.LivrosAutores.Add(new LivroAutor() { Livro = livro1, Ano=2017 });
                //autor1.LivrosAutores.Add(new LivroAutor() { Livro = livro2, Ano=2017 });

                //autor2.LivrosAutores.Add(new LivroAutor() { Livro = livro1, Ano = 2017 });
                //autor2.LivrosAutores.Add(new LivroAutor() { Livro = livro2, Ano = 2017 });

                //db.Autores.Add(autor1);
                //db.Autores.Add(autor2);
                //db.SaveChanges();

            }
            Console.WriteLine("Os dados foram persistidos com sucesso na base de dados.");
            Console.ReadKey();
        }
    }
}
