using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.RecipientRemoved"/> 拡張メソッド
    /// </summary>
    public static class RecipientRemovedEx
    {
        private static IObservable<SocketGroupUser> NotifyRecipientRemoved(this BaseSocketClient client,
            Func<Action<SocketGroupUser>, Func<SocketGroupUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RecipientRemoved += h,
                h => client.RecipientRemoved -= h);
        }

        /// <summary>
        /// ユーザーがグループ チャネルから削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGroupUser> NotifyRecipientRemoved(this BaseSocketClient client)
        {
            return client.NotifyRecipientRemoved(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
