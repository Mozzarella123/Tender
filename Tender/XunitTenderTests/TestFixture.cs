using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;

namespace XunitTenderTests
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly TestServer Server;
        private readonly HttpClient _client;


        public TestFixture()
        {
            //$"..\\..\\..\\..\\..\\src\\Blog.Turnmeup.API\\"
            string directory = Directory.GetCurrentDirectory();
            var builder = new WebHostBuilder()
                .UseContentRoot(directory)
                .UseStartup<TStartup>();

            Server = new TestServer(builder);
            _client = new HttpClient();
        }


        public void Dispose()
        {
            _client.Dispose();
            Server.Dispose();
        }
    }
}
