using System;
using System.Net.Http;

namespace AppEscritorio.environments
{
    public static class ApiConfig
    {
        private static readonly Lazy<HttpClient> client = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Client => client.Value;

        public static string ApiBaseUrl => "http://localhost:5281/api";
    }
}
