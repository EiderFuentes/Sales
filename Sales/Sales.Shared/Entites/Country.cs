using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entites
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //Campo name es obligatorio en la base de datos
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!; //Diferente de null  
    }
}
