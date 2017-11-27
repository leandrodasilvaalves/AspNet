using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EnumDispalyName
{
    class Program
    {
        static void Main(string[] args)
        {  
            var Status = new StatusViewModel();
            var Lista = Status.GetLista();

            foreach (var s in Lista)
            {
                Console.WriteLine(s.Id + " - " + s.Nome);
            }
            Console.ReadKey();
        }

        
    }

    public enum Status
    {
        [Display(Name = "Pendente")]
        pendente,

        [Display(Name = "Em andamento")]
        andamento,

        [Display(Name = "Finalizado")]
        finalizado,

        [Display(Name = "Cancelado")]
        cancelado,

        [Display(Name ="Leandro")]
        leandro
    }

    public static class DisplayEnum
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }

    public class StatusObj
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class StatusViewModel
    {
        private ICollection<StatusObj> Lista { get; set; }

        public StatusViewModel()
        {
            Lista = new List<StatusObj>();
        }

        public ICollection<StatusObj> GetLista()
        {
            var EnumValues = Enum.GetValues(typeof(Status));
            foreach (var enValue in EnumValues)
            {
                Lista.Add(new StatusObj { Id = (int)enValue, Nome= DisplayEnum.GetDisplayName((Enum)enValue) });
            }
            return Lista;
        }
       
    }

   


}
