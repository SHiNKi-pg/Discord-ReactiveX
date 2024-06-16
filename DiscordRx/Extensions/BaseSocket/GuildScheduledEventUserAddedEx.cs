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
    /// <seealso cref="BaseSocketClient.GuildScheduledEventUserAdd"/> 拡張メソッド
    /// </summary>
    public static class GuildScheduledEventUserAddedEx
    {
        private static IObservable<GuildScheduledEventUserAddArgs> NotifyGuildScheduledEventUserAdd(this BaseSocketClient client,
            Func<Action<GuildScheduledEventUserAddArgs>, Func<Cacheable<SocketUser, RestUser, IUser, ulong>, SocketGuildEvent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildScheduledEventUserAdd += h,
                h => client.GuildScheduledEventUserAdd -= h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildScheduledEventUserAddArgs> NotifyGuildScheduledEventUserAdd(this BaseSocketClient client)
        {
            return client.NotifyGuildScheduledEventUserAdd(h => (arg1, arg2) =>
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
