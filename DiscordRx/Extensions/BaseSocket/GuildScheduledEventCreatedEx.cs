using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildScheduledEventCreated"/>拡張メソッド
    /// </summary>
    public static class GuildScheduledEventCreatedEx
    {
        private static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCreated(this BaseSocketClient client,
            Func<Action<SocketGuildEvent>, Func<SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventCreated += h,
                h => client.GuildScheduledEventCreated -= h);
        }

        /// <summary>
        /// ギルド イベントが作成されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCreated(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
