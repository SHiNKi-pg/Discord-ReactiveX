using Discord.WebSocket;
using DiscordRx.Extensions.DiscordSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.UnitTest
{
    public abstract class SocketDiscordTestBase : IClassFixture<AppSettingsFixture>, IDisposable
    {
        private readonly AppSettingsFixture _appsettingsFixture;

        private string token;

        protected DiscordSocketClient Client { get; init; }

        public SocketDiscordTestBase(AppSettingsFixture appsettingsFixture)
        {
            _appsettingsFixture = appsettingsFixture;
            token = _appsettingsFixture.Configuration.GetSection("testing")?.GetSection("token")?.Value!;

            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                GatewayIntents = Discord.GatewayIntents.All,
            });
        }

        protected async Task LoginAsync()
        {
            await Client.StartAsync();
            await Client.LoginAsync(Discord.TokenType.Bot, token);
            await Client.NotifyReady().Take(1);
        }

        protected async Task LogoutAsync()
        {
            await Client.LogoutAsync();
            await Client.StopAsync();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
