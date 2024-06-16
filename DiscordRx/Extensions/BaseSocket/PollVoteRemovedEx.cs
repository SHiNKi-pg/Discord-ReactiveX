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
    /// <seealso cref="BaseSocketClient.PollVoteRemoved"/> 拡張メソッド
    /// </summary>
    public static class PollVoteRemovedEx
    {
        private static IObservable<PollVoteRemovedArgs> NotifyPollVoteRemoved(this BaseSocketClient client,
    Func<Action<PollVoteRemovedArgs>, Func<Cacheable<IUser, ulong>, Cacheable<ISocketMessageChannel, IRestMessageChannel, IMessageChannel, ulong>, Cacheable<IUserMessage, ulong>, Cacheable<SocketGuild, RestGuild, IGuild, ulong>?, ulong, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.PollVoteRemoved += h,
                h => client.PollVoteRemoved -= h);
        }

        /// <summary>
        /// 投票がアンケートから削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<PollVoteRemovedArgs> NotifyPollVoteRemoved(this BaseSocketClient client)
        {
            return client.NotifyPollVoteRemoved(h => (arg1, arg2, arg3, arg4, arg5) =>
            {
                h(new()
                {
                    Arg1 = arg1,
                    Arg2 = arg2,
                    Arg3 = arg3,
                    Arg4 = arg4,
                    Arg5 = arg5,
                });
                return Task.CompletedTask;
            });
        }
    }
}
