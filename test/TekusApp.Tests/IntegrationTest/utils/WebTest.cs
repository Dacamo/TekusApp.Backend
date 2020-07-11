using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;


namespace TekusApp.Tests.IntegrationTest.utils
{
    public class WebTest
    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        public WebTest()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
