using System.Net.Http;
using System.Threading.Tasks;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.ServiceAgent
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string uri, string authorizationToken = null, string authorizationMethod = "");

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "");

        Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string requestId = null, string authorizationMethod = "");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string requestId = null, string authorizationMethod = "");
    }
}
