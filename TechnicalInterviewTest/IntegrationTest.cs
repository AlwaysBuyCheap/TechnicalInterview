using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test
{
    public class IntegrationTest
    {
        protected readonly HttpClient testClient;

        protected IntegrationTest ()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(
                    builder =>
                    {
                        builder.ConfigureTestServices(services => { });
                    }
                );

            testClient = appFactory.CreateClient();
        }
    }
}
