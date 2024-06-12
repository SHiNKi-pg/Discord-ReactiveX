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
    /// <see cref="BaseSocketClient.ReactionsCleared"/>拡張メソッド
    /// </summary>
    public static class ReactionsClearedEx
    {
        private static IObservable<ReactionsClearedArgs> NotifyReactionsCleared(this BaseSocketClient client,
            Func<Action<ReactionsClearedArgs>, Func<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ReactionsCleared += h,
                h => client.ReactionsCleared -= h);
        }

        /// <summary>
        /// リアクションが全てクリアされると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ReactionsClearedArgs> NotifyReactionsCleared(this BaseSocketClient client)
        {
            return client.NotifyReactionsCleared(h => (message, channel) =>
            {
                h(new()
                {
                    Message = message,
                    Channel = channel
                });
                return Task.CompletedTask;
            });
        }
    }
}
