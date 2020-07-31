using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TiendaTecno.Web.Models
{
    public class Marca
    {
        [Required]
        [Key]
        public int MarcaID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} no debe contener más de {1} Caracteres ")]
        [Display(Name = "Marca")]
        public string Nombre { get; set; }

        [Display(Name = "Logotipo")]
        public string UrlLogo { get; set; }
    }
}