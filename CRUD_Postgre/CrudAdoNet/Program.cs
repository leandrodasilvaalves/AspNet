using Npgsql;
using System;

namespace CrudAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert("Meirilene Alves", "meiry@gmail.com");
            //Insert("Isabella Alves", "isa@hotmail.com");
            GetAll();
            Console.ReadKey();

        }

        static void Insert(string nome, string email)
        {
            using (var conn = new NpgsqlConnection(Strcon()))
            {
                var sql = String.Format("insert into funcionario (nome, email) values ('{0}', '{1}')", nome, email);
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static void GetAll()
        {
            using(var conn = new NpgsqlConnection(Strcon()))
            {
                conn.Open();
                using(var cmd = new NpgsqlCommand("select * from funcionario", conn))
                {
                    var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine("Id: {0} \t| Nome: {1} \t| E-mail: {2}", rd[0], rd[1], rd[2]);
                    }
                }
            }

        }

        static string Strcon()
        {
            string serverName = "127.0.0.1";
            string port = "5432";
            string userName = "postgres";
            string password = "le.126986";
            string databaseName = "crud_csharp";

            return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);

            
        }
    }
}
