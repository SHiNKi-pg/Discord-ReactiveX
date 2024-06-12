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
    /// <see cref="BaseSocketClient.ReactionsRemovedForEmote"/>拡張メソッド
    /// </summary>
    public static class ReactionsRemovedForEmoteEx
    {
        private static IObservable<ReactionsRemovedForEmoteArgs> NotifyReactionsRemovedForEmote(this BaseSocketClient client,
            Func<Action<ReactionsRemovedForEmoteArgs>, Func<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, IEmote, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ReactionsRemovedForEmote += h,
                h => client.ReactionsRemovedForEmote -= h);
        }

        /// <summary>
        /// 特定の絵文字を含むメッセージに対するすべての反応が削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ReactionsRemovedForEmoteArgs> NotifyReactionsRemovedForEmote(this BaseSocketClient client)
        {
            return client.NotifyReactionsRemovedForEmote(h => (message, channel, emote) =>
            {
                h(new()
                {
                    Message = message,
                    Channel = channel,
                    Emote = emote
                });
                return Task.CompletedTask;
            });
        }
    }
}
