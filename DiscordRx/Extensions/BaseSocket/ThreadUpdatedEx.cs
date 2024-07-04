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
    /// <seealso cref="BaseSocketClient.ThreadUpdated"/>拡張メソッド
    /// </summary>
    public static class ThreadUpdatedEx
    {
        private static IObservable<ThreadUpdatedArgs> NotifyThreadUpdated(this BaseSocketClient client,
            Func<Action<ThreadUpdatedArgs>, Func<Cacheable<SocketThreadChannel, ulong>, SocketThreadChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ThreadUpdated += h,
                h => client.ThreadUpdated -= h);
        }

        /// <summary>
        /// ギルド内でスレッドが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ThreadUpdatedArgs> NotifyThreadUpdated(this BaseSocketClient client)
        {
            return client.NotifyThreadUpdated(h => (a, b) =>
            {
                h(new()
                {
                    Arg1 = a,
                    Arg2 = b,
                });
                return Task.CompletedTask;
            });
        }
    }
}
