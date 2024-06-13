using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.ChannelDestroyed"/>拡張メソッド
    /// </summary>
    public static class ChannelDestroyedEx
    {
        private static IObservable<SocketChannel> NotifyChannelDestroyed(this BaseSocketClient client,
            Func<Action<SocketChannel>, Func<SocketChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ChannelDestroyed += h,
                h => client.ChannelDestroyed -= h);
        }

        /// <summary>
        /// チャネルが破棄されたとき通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketChannel> NotifyChannelDestroyed(this BaseSocketClient client)
        {
            return client.NotifyChannelDestroyed(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
