using Oracle.DataAccess.Client;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strcon = "Data Source=dbserver;User Id=dbuser;Password=123456;";
            using (var conn = new OracleConnection(strcon))
            {
                conn.Open();
                using (var cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM CLIENTE";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: {0} | Nome: {1}", reader["Id"], reader["Nome"]);
                        }
                    }
                }
                conn.Close();
            }

            Console.ReadKey();
        }
    }
}
