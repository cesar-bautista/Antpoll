using System;
using System.Collections.Generic;
using System.Linq;

namespace Antpoll.Application.Api.Adapters
{
    public class ApiResponse<T> where T : class
    {
        public Dictionary<string, string> Entry { get; set; }

        public T Response { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }

        public ApiResponse(T response, IEnumerable<KeyValuePair<string, string>> entry)
        {
            Entry = entry.GetQueryStrings();
            Response = response;
            Message = "Ok";
            Status = 200;
        }
    }
    /// <summary>
    /// Extends the HttpRequestMessage collection
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Returns a dictionary of QueryStrings that's easier to work with 
        /// than GetQueryNameValuePairs KevValuePairs collection.
        /// 
        /// If you need to pull a few single values use GetQueryString instead.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStrings(this IEnumerable<KeyValuePair<string, string>> request)
        {
            return request.ToDictionary(kv => kv.Key, kv => kv.Value,
                    StringComparer.OrdinalIgnoreCase);
        }
        //public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        //{
        //    return request.GetQueryNameValuePairs()
        //        .ToDictionary(kv => kv.Key, kv => kv.Value,
        //            StringComparer.OrdinalIgnoreCase);
        //}
    }
}
