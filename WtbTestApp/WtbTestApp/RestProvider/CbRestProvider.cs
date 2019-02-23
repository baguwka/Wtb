using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WtbTestApp.RestProvider
{
    public class CbRestProvider : IRestProvider
    {
        private const string Server = "http://www.cbr.ru/scripts/";

        private readonly HttpClient _Client;

        public CbRestProvider()
        {
            _Client = new HttpClient(new HttpClientHandler());
            _Client.BaseAddress = new Uri(Server);
            //_Client.DefaultRequestHeaders.Add("Content-Type", "application/xml");
        }

        public async Task<ServerResponse> GetAsync(string method)
        {
            var uri = CreateUriFromMethod(method);
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _Client.SendAsync(request);
            return await ServerResponse.FromHttpResponseAsync(response);
        }

        public async Task<ServerResponse> GetAsync(string method, Dictionary<string, string> parameters)
        {
            var uri = CreateUriFromMethod(method);

            var query = string.Join("&", parameters
                .Select(pair => $"{pair.Key}={pair.Value}"));

            var uriBuilder = new UriBuilder(uri)
            {
                Query = query
            };

            var requestUri = uriBuilder.Uri;
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _Client.SendAsync(request);

            return await ServerResponse.FromHttpResponseAsync(response);
        }

        private Uri CreateUriFromMethod(string method)
        {
            var baseUri = new Uri(Server);
            var methodUri = new Uri(baseUri, method);
            return methodUri;
        }

    }
}