using Discord.Rest;
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
    /// <seealso cref="BaseSocketClient.GuildScheduledEventUserRemove"/> 拡張メソッド
    /// </summary>
    public static class GuildScheduledEventUserRemoveEx
    {
        private static IObservable<GuildScheduledEventUserRemoveArgs> NotifyGuildScheduledEventUserRemove(this BaseSocketClient client,
            Func<Action<GuildScheduledEventUserRemoveArgs>, Func<Cacheable<SocketUser, RestUser, IUser, ulong>, SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventUserRemove += h,
                h => client.GuildScheduledEventUserRemove -= h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildScheduledEventUserRemoveArgs> NotifyGuildScheduledEventUserRemove(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventUserRemove(h => (arg1, arg2) =>
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
