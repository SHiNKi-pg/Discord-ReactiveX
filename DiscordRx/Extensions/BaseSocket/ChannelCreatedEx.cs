using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.ChannelCreated"/>拡張メソッド
    /// </summary>
    public static class ChannelCreatedEx
    {
        private static IObservable<SocketChannel> NotifyChannelCreated(this BaseSocketClient client,
            Func<Action<SocketChannel>, Func<SocketChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ChannelCreated += h,
                h => client.ChannelCreated -= h);
        }

        /// <summary>
        /// チャンネルが作成されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketChannel> NotifyChannelCreated(this BaseSocketClient client)
        {
            return client.NotifyChannelCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
