using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.RoleDeleted"/> 拡張メソッド
    /// </summary>
    public static class RoleDeletedEx
    {
        private static IObservable<SocketRole> NotifyRoleDeleted(this BaseSocketClient client,
            Func<Action<SocketRole>, Func<SocketRole, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RoleDeleted += h,
                h => client.RoleDeleted -= h);
        }

        /// <summary>
        /// ロールが削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketRole> NotifyRoleDeleted(this BaseSocketClient client)
        {
            return client.NotifyRoleDeleted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
