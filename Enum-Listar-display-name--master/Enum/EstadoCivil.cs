using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDispalyName.Enum
{
    public enum EstadoCivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro,

        [Display(Name = "Casado(a)")]
        Casado,

        [Display(Name = "Viúvo(a)")]
        Viuvo,

        [Display(Name ="Divorciado(a)")]
        Divorciado,

        [Display(Name =("União Estável"))]
        UniaoEstavel

    }
}
