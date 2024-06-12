using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.ThreadCreated"/>拡張メソッド
    /// </summary>
    public static class ThreadCreatedEx
    {
        private static IObservable<SocketThreadChannel> NotifyThreadCreated(this BaseSocketClient client,
            Func<Action<SocketThreadChannel>, Func<SocketThreadChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ThreadCreated += h,
                h => client.ThreadCreated -= h);
        }

        /// <summary>
        /// スレッドが作成されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketThreadChannel> NotifyThreadCreated(this BaseSocketClient client)
        {
            return client.NotifyThreadCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
