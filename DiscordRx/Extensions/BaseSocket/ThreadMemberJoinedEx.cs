using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ThreadMemberJoined"/>拡張メソッド
    /// </summary>
    public static class ThreadMemberJoinedEx
    {
        private static IObservable<SocketThreadUser> NotifyThreadMemberJoined(this BaseSocketClient client,
            Func<Action<SocketThreadUser>, Func<SocketThreadUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ThreadMemberJoined += h,
                h => client.ThreadMemberJoined -= h);
        }

        /// <summary>
        /// ユーザーがスレッドに参加したときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketThreadUser> NotifyThreadMemberJoined(this BaseSocketClient client)
        {
            return client.NotifyThreadMemberJoined(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
