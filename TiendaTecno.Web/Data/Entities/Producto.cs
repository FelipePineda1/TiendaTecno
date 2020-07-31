using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TiendaTecno.Web.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImage { get; set; }

        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }


        [Display(Name = "Marca")]
        public int MarcaID { get; set; }
        public Marca Marca { get; set; }


        [Display(Name = "Categoría")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }


        [Display(Name = "Descripción del producto")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }


        [Display(Name = "¿Disponible?")]
        public bool Disponible { get; set; }

        public User User { get; set; }

    }
}
