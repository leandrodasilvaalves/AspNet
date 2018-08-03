using Model.Entities;
using System;
using System.Collections.Generic;

namespace Model.Charge
{
    public static class PersonData
    {
        public static ICollection<Person> Seed()
        {
            return new List<Person>
            {
                new Person{ Name = "Leandro Alves", DataCadastro = DateTime.Now,  Age = 32, VIP = true},
                new Person{ Name = "Meirilene Alves", DataCadastro = DateTime.Now, Age = 26, VIP = true},
                new Person { Name = "Isabella Alves", DataCadastro = DateTime.Now, Age = 9, VIP = false}
            };
        }

    }
}
