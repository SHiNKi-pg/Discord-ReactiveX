using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildUnavailable"/>拡張メソッド
    /// </summary>
    public static class GuildUnavailableEx
    {
        private static IObservable<SocketGuild> NotifyGuildUnavailable(this BaseSocketClient client,
            Func<Action<SocketGuild>, Func<SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildUnavailable += h,
                h => client.GuildUnavailable -= h);
        }

        /// <summary>
        /// ギルドが利用できなくなったときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuild> NotifyGuildUnavailable(this BaseSocketClient client)
        {
            return client.NotifyGuildUnavailable(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
