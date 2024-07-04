using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ThreadMemberLeft"/>拡張メソッド
    /// </summary>
    public static class ThreadMemberLeftEx
    {
        private static IObservable<SocketThreadUser> NotifyThreadMemberLeft(this BaseSocketClient client,
            Func<Action<SocketThreadUser>, Func<SocketThreadUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ThreadMemberLeft += h,
                h => client.ThreadMemberLeft -= h);
        }

        /// <summary>
        /// ユーザーがスレッドを離れたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketThreadUser> NotifyThreadMemberLeft(this BaseSocketClient client)
        {
            return client.NotifyThreadMemberLeft(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
