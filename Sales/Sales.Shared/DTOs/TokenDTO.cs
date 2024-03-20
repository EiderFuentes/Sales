namespace Sales.Shared.DTOs
{
    //Clase para generar token
    public class TokenDTO
    {
        //Token
        public string Token { get; set; } = null!;

        //Fecha de expitracion
        public DateTime Expiration { get; set; }

    }
}
