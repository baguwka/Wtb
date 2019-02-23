using System.Collections.Generic;
using System.Threading.Tasks;

namespace WtbTestApp.RestProvider
{
    public interface IRestProvider
    {
        Task<ServerResponse> GetAsync(string method);
        Task<ServerResponse> GetAsync(string method, Dictionary<string, string> parameters);
    }
}