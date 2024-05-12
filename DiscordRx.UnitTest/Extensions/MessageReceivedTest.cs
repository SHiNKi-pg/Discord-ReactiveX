using DiscordRx.Extensions.BaseSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.UnitTest.Extensions
{
    public class MessageReceivedTest : SocketDiscordTestBase
    {
        public MessageReceivedTest(AppSettingsFixture appsettingsFixture) : base(appsettingsFixture)
        {
        }

        [Fact]
        public async Task MessageTest()
        {
            await base.LoginAsync();
            try
            {
                Assert.True(Client.CurrentUser is not null);

                await Client
                    .NotifyMessageReceived()
                    .Take(1)
                    .Timeout(TimeSpan.FromSeconds(30));
            }
            finally
            {
                await base.LogoutAsync();
            }
        }
    }
}
