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
    /// <seealso cref="BaseSocketClient.MessageDeleted"/> 拡張メソッド
    /// </summary>
    public static class MessageDeleted
    {
        private static IObservable<MessageDeletedArgs> NotifyMessageDeleted(this BaseSocketClient socketClient,
            Func<Action<MessageDeletedArgs>, Func<Cacheable<IMessage, ulong>, Cacheable<IMessageChannel, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => socketClient.MessageDeleted += h,
                h => socketClient.MessageDeleted -= h);
        }

        /// <summary>
        /// メッセージが削除されると通知されます。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <returns></returns>
        public static IObservable<MessageDeletedArgs> NotifyMessageDeleted(this BaseSocketClient socketClient)
        {
            return socketClient.NotifyMessageDeleted(h => async (message, channel) =>
            {
                var messageTask = message.GetOrDownloadAsync();
                var channelTask = channel.GetOrDownloadAsync();
                // データダウンロードされるまで待機する
                await Task.WhenAll(messageTask, channelTask);
                h(new() { 
                    Message = message,
                    Channel = channel
                });
            });
        }
    }
}
