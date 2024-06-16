using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.RecipientAdded"/> 拡張メソッド
    /// </summary>
    public static class RecipientAddedEx
    {
        private static IObservable<SocketGroupUser> NotifyRecipientAdded(this BaseSocketClient client,
            Func<Action<SocketGroupUser>, Func<SocketGroupUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RecipientAdded += h,
                h => client.RecipientAdded -= h);
        }

        /// <summary>
        /// ユーザーがグループ チャネルに参加したときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGroupUser> NotifyRecipientAdded(this BaseSocketClient client)
        {
            return client.NotifyRecipientAdded(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
