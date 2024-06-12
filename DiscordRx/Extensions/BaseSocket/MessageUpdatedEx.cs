using Discord;
using Discord.WebSocket;
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
    /// <seealso cref="BaseSocketClient.MessageUpdated"/> 拡張メソッド定義
    /// </summary>
    public static class MessageUpdatedEx
    {
        private static IObservable<MessageUpdatedArgs> NotifyMessageUpdated(this BaseSocketClient client,
            Func<Action<MessageUpdatedArgs>, Func<Cacheable<IMessage, ulong>, SocketMessage, ISocketMessageChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.MessageUpdated += h,
                h => client.MessageUpdated -= h);
        }

        /// <summary>
        /// メッセージが更新されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<MessageUpdatedArgs> NotifyMessageUpdated(this BaseSocketClient client)
        {
            return client.NotifyMessageUpdated(e => (message, socketMessage, channel) =>
            {
                e(new()
                {
                    Message = message,
                    SocketMessage = socketMessage,
                    Channel = channel,
                });
                return Task.CompletedTask;
            });
        }
    }
}
