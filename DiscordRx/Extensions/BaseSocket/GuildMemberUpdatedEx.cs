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
    /// <see cref="BaseSocketClient.GuildMemberUpdated"/>拡張メソッド
    /// </summary>
    public static class GuildMemberUpdatedEx
    {
        private static IObservable<GuildMemberUpdatedArgs> NotifyGuildMemberUpdated(this BaseSocketClient client,
            Func<Action<GuildMemberUpdatedArgs>, Func<Cacheable<SocketGuildUser, ulong>, SocketGuildUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildMemberUpdated += h,
                h => client.GuildMemberUpdated -= h);
        }

        /// <summary>
        /// ギルドメンバーが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildMemberUpdatedArgs> NotifyGuildMemberUpdated(this BaseSocketClient client)
        {
            return client.NotifyGuildMemberUpdated(h => (buser, user) =>
            {
                h(new()
                {
                    BeforeUserInfo = buser,
                    UserInfo = user
                });
                return Task.CompletedTask;
            });
        }
    }
}
