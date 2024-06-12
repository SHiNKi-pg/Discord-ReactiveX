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
    /// <see cref="BaseSocketClient.ReactionRemoved"/>拡張メソッド
    /// </summary>
    public static class ReactionRemovedEx
    {
        private static IObservable<ReactionRemovedArg> NotifyReactionRemoved(this BaseSocketClient client,
            Func<Action<ReactionRemovedArg>, Func<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, SocketReaction, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ReactionRemoved += h,
                h => client.ReactionRemoved -= h);
        }

        /// <summary>
        /// リアクションが削除されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ReactionRemovedArg> NotifyReactionRemoved(this BaseSocketClient client)
        {
            return client.NotifyReactionRemoved(h => (message, channel, reaction) =>
            {
                h(new()
                {
                    Message = message,
                    Channel = channel,
                    Reaction = reaction,
                });
                return Task.CompletedTask;
            });
        }
    }
}
