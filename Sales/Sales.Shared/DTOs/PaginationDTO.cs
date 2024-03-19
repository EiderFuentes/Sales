namespace Sales.Shared.DTOs
{
    //Clase modelo de la paginación
    public class PaginationDTO
    {
        public int Id { get; set; }
        //numero pagina 
        public int Page { get; set; } = 1;
        //Numero de registro
        public int RecordsNumber { get; set; } = 10;
        //Filtro
        public string? Filter { get; set; }

    }
}
