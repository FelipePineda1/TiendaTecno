using System.ComponentModel.DataAnnotations;

namespace TiendaTecno.Web.Models
{
    public class Categoria
    {

        [Key]
        [Required]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Categoría")]
        public string NombreCategoria { get; set; }


        
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
}