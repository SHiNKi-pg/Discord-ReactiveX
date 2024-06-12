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
    /// <see cref="BaseSocketClient.ThreadDeleted"/>拡張メソッド
    /// </summary>
    public static class ThreadDeletedEx
    {
        private static IObservable<ThreadDeletedArgs> NotifyThreadDeleted(this BaseSocketClient client,
            Func<Action<ThreadDeletedArgs>, Func<Cacheable<SocketThreadChannel, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ThreadDeleted += h,
                h => client.ThreadDeleted -= h);
        }

        /// <summary>
        /// スレッドが削除されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ThreadDeletedArgs> NotifyThreadDeleted(this BaseSocketClient client)
        {
            return client.NotifyThreadDeleted(h => (threadChannel) =>
            {
                h(new()
                {
                    ThreadChannel = threadChannel
                });
                return Task.CompletedTask;
            });
        }
    }
}
