using System.ComponentModel.DataAnnotations;

namespace EnumDispalyName.Enum
{
    public enum Status
    {
        [Display(Name = "Pendente")]
        pendente,

        [Display(Name = "Em andamento")]
        andamento,

        [Display(Name = "Finalizado")]
        finalizado,

        [Display(Name = "Cancelado")]
        cancelado
    }

}

