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
    /// <see cref="BaseSocketClient.PresenceUpdated"/>拡張メソッド
    /// </summary>
    public static class PresenceUpdatedEx
    {
        private static IObservable<PresenceUpdatedArgs> NotifyPresenceUpdated(this BaseSocketClient client,
            Func<Action<PresenceUpdatedArgs>, Func<SocketUser, SocketPresence, SocketPresence, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.PresenceUpdated += h,
                h => client.PresenceUpdated -= h);
        }

        /// <summary>
        /// ユーザーのプレゼンスが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<PresenceUpdatedArgs> NotifyPresenceUpdated(this BaseSocketClient client)
        {
            return client.NotifyPresenceUpdated(h => (user, beforePresence, currentPresence) =>
            {
                h(new()
                {
                    User = user,
                    BeforePresence = beforePresence,
                    AfterPresence = currentPresence,
                });
                return Task.CompletedTask;
            });
        }
    }
}
