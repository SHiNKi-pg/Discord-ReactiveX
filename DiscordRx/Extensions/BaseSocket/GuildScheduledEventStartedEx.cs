using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildScheduledEventStarted"/>拡張メソッド
    /// </summary>
    public static class GuildScheduledEventStartedEx
    {
        private static IObservable<SocketGuildEvent> NotifyGuildScheduledEventStarted(this BaseSocketClient client,
            Func<Action<SocketGuildEvent>, Func<SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventStarted += h,
                h => client.GuildScheduledEventStarted -= h);
        }

        /// <summary>
        /// ギルド イベントが開始されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuildEvent> NotifyGuildScheduledEventStarted(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventStarted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
