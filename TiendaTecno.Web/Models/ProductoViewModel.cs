using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecno.Web.Models
{
    public class ProductoViewModel : Producto
    {
        [Display(Name = "Imagen")]
        public IFormFile FileImage { get; set; }
    }
}
