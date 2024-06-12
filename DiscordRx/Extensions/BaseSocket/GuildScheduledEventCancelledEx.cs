using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildScheduledEventCancelled"/>拡張メソッド
    /// </summary>
    public static class GuildScheduledEventCancelledEx
    {
        private static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCancelled(this BaseSocketClient client,
            Func<Action<SocketGuildEvent>, Func<SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventCancelled += h,
                h => client.GuildScheduledEventCancelled -= h);
        }

        /// <summary>
        /// ギルド イベントがキャンセルされたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCancelled(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventCancelled(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
