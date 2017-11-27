using EnumDispalyName.Enum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnumDispalyName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum Status");
            Console.WriteLine(new string('-', 40));
            var Status = new StatusViewModel();
            var statusLista = Status.GetLista();

            foreach (var st in statusLista)
            {
                Console.WriteLine(st.Num + " - " + st.Display);
            }

            Console.WriteLine("");
            Console.WriteLine("Enum Estado Civil");
            Console.WriteLine(new string('-', 40));
            var EstadCivil = new EstadoCivilViewModel();
            var estadoCivilLista = EstadCivil.GetLista();

            foreach(var estadoCivil in estadoCivilLista)
            {
                Console.WriteLine(estadoCivil.Num + " - " + estadoCivil.Display);
            }

            Console.ReadKey();
        }

        
    }  

}
