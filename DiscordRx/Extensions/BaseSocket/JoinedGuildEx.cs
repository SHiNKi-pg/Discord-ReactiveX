using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.JoinedGuild"/>
    /// </summary>
    public static class JoinedGuildEx
    {
        private static IObservable<SocketGuild> NotifyJoinedGuild(this BaseSocketClient client,
            Func<Action<SocketGuild>, Func<SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.JoinedGuild += h,
                h => client.JoinedGuild -= h
                );
        }

        /// <summary>
        /// このアカウントがサーバーに参加すると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuild> NotifyJoinedGuild(this BaseSocketClient client)
        {
            return client.NotifyJoinedGuild(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
