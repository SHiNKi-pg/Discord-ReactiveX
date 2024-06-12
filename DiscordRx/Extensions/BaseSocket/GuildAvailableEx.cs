using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildAvailable"/>拡張メソッド
    /// </summary>
    public static class GuildAvailableEx
    {
        private static IObservable<SocketGuild> NotifyGuildAvailable(this BaseSocketClient client,
            Func<Action<SocketGuild>, Func<SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildAvailable += h,
                h => client.GuildAvailable -= h);
        }

        /// <summary>
        /// サーバーが利用可能になると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuild> NotifyGuildAvailable(this BaseSocketClient client)
        {
            return client.NotifyGuildAvailable(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
