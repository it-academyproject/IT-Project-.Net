using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ItAcademyProjecteNET.IntegrationTests
{
    public class TestClientProvider : IDisposable
    {
        private TestServer Server { get; set; }

        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
