using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sales.WEB.Auth
{
    // Clase de autenticacion
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            //Autenticacion generica hardcodeada
            var anonimous = new ClaimsIdentity();//Creo un usuario que no es anonimo
            var zuluUser = new ClaimsIdentity(new List<Claim>
             {
                //lista reclamaciones
                new Claim("FirstName", "Juan"),//Usuario Administrador
                new Claim("LastName", "Zulu"),
                new Claim(ClaimTypes.Name, "zulu@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")

             },
             authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));
        }

    }
}
