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
    /// <seealso cref="BaseSocketClient.GuildJoinRequestDeleted"/> 拡張メソッド
    /// </summary>
    public static class GuildJoinRequestDeletedEx
    {
        private static IObservable<GuildJoinRequestDeletedArgs> NotifyGuildJoinRequestDeleted(this BaseSocketClient client,
            Func<Action<GuildJoinRequestDeletedArgs>, Func<Cacheable<SocketGuildUser, ulong>, SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildJoinRequestDeleted += h,
                h => client.GuildJoinRequestDeleted -= h);
        }

        /// <summary>
        /// ユーザーがメンバー審査に同意せずに退会すると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildJoinRequestDeletedArgs> NotifyGuildJoinRequestDeleted(this BaseSocketClient client)
        {
            return client.NotifyGuildJoinRequestDeleted(h => (arg1, arg2) =>
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
