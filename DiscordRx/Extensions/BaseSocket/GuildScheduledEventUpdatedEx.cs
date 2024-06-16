using DiscordRx.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildScheduledEventUpdated"/> 拡張メソッド
    /// </summary>
    public static class GuildScheduledEventUpdatedEx
    {
        private static IObservable<GuildScheduledEventUpdatedArgs> NotifyGuildScheduledEventUpdated(this BaseSocketClient client,
            Func<Action<GuildScheduledEventUpdatedArgs>, Func<Cacheable<SocketGuildEvent, ulong>, SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventUpdated += h,
                h => client.GuildScheduledEventUpdated -= h);
        }

        /// <summary>
        /// ギルド イベントが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildScheduledEventUpdatedArgs> NotifyGuildScheduledEventUpdated(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventUpdated(h => (arg1, arg2) =>
            {
                h(new()
                {
                    Arg1 = arg1,
                    Arg2 = arg2,
                });
                return Task.CompletedTask;
            });
        }
    }
}
