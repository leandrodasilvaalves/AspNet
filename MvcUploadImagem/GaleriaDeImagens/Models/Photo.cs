using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaDeImagens.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public String Description { get; set; }

        [Display(Name = "Image Path")]
        public String ImagePath { get; set; }

        [Display(Name = "Thumb Path")]
        public String ThumbPath { get; set; }


        [Display(Name = "Criada em")]
        public DateTime CreatedOn { get; set; }
    }

}