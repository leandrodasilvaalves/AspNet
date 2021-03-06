﻿using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MvcUploadImagem.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    }
}