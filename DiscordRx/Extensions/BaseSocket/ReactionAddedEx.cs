using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordRx.Arguments;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ReactionAdded"/> 拡張メソッド定義
    /// </summary>
    public static class ReactionAddedEx
    {
        private static IObservable<ReactionAddedArgs> NotifyReactionAdded(this BaseSocketClient client,
            Func<Action<ReactionAddedArgs>, Func<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, SocketReaction, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ReactionAdded += h,
                h => client.ReactionAdded -= h
                );
        }

        /// <summary>
        /// メッセージにリアクションが追加されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ReactionAddedArgs> NotifyReactionAdded(this BaseSocketClient client)
        {
            return client.NotifyReactionAdded(h => (message, channel, reaction) =>
            {
                h(new ReactionAddedArgs()
                {
                    Message = message,
                    Channel = channel,
                    Reaction = reaction
                });
                return Task.CompletedTask;
            });
        }
    }
}
