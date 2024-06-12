using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.LeftGuild"/>拡張メソッド
    /// </summary>
    public static class LeftGuildEx
    {
        private static IObservable<SocketGuild> NotifyLeftGuild(this BaseSocketClient client,
            Func<Action<SocketGuild>, Func<SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.LeftGuild += h,
                h => client.LeftGuild -= h);
        }

        /// <summary>
        /// このアカウントがサーバーから離脱すると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuild> NotifyLeftGuild(this BaseSocketClient client)
        {
            return client.NotifyLeftGuild(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
