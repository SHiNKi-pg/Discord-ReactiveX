using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildScheduledEventCompleted"/>拡張メソッド
    /// </summary>
    public static class GuildScheduledEventCompletedEx
    {
        private static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCompleted(this BaseSocketClient client,
            Func<Action<SocketGuildEvent>, Func<SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventCompleted += h,
                h => client.GuildScheduledEventCompleted -= h);
        }

        /// <summary>
        /// ギルド イベントが完了したときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuildEvent> NotifyGuildScheduledEventCompleted(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventCompleted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
