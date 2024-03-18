using Sales.Shared.Responses;

namespace Sales.API.Services
{
    //Servicio para consumir API Externas
    public interface IApiService 
    {
        //Get generico
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}
