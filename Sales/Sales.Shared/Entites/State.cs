using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entites
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Departamento/Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        //Creacion Modelo Entidad Relacion en entity framework
        //Un Departamento petenece a un país Relaciones
        public Country? Country { get; set; }

        //Un Estado tiene muchas Cuidades
        public ICollection<City>? Cities { get; set; }

        //Propiedad de lectura no se mapean en la base de datos
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
