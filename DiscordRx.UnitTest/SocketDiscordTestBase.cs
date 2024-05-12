using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.UnitTest
{
    internal abstract class SocketDiscordTestBase : IClassFixture<AppSettingsFixture>, IDisposable
    {
        private readonly AppSettingsFixture _appsettingsFixture;

        private string token;

        protected DiscordSocketClient Client { get; init; }

        public SocketDiscordTestBase(AppSettingsFixture appsettingsFixture)
        {
            _appsettingsFixture = appsettingsFixture;
            token = _appsettingsFixture.Configuration.GetSection("testing")?.GetSection("token")?.ToString()!;

            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                GatewayIntents = Discord.GatewayIntents.All,
            });
        }

        protected async Task LoginAsync()
        {
            await Client.LoginAsync(Discord.TokenType.Bot, token);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
