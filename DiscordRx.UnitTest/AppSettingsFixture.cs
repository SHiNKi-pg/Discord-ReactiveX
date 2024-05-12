using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.UnitTest
{
    public class AppSettingsFixture : IDisposable
    {
        public IConfigurationRoot Configuration { get; private set; }
        public AppSettingsFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                ;
            
            Configuration = builder.Build();
        }

        public void Dispose()
        {
               
        }
    }
}
