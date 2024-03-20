using Microsoft.JSInterop;

namespace Sales.WEB.Helpers
{
    //Clase de javaScript
    public static class IJSRuntimeExtensionMethods
    {
        //Metodo para almacenar un valor SetLocalStorage
        public static ValueTask<object> SetLocalStorage(this IJSRuntime js, string key, string content)
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, content);
        }
        //Metodo para consultar en el LocalStorage
        public static ValueTask<object> GetLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.getItem", key);
        }

        //Metodo para remover en el LocalStorage
        public static ValueTask<object> RemoveLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }
    }
}

