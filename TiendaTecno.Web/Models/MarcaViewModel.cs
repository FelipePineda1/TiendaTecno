using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecno.Web.Models.ViewModels
{
    public class MarcaViewModel : Marca
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
