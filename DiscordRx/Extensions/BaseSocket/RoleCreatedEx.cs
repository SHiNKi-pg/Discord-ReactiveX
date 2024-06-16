using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.RoleCreated"/> 拡張メソッド
    /// </summary>
    public static class RoleCreatedEx
    {
        private static IObservable<SocketRole> NotifyRoleCreated(this BaseSocketClient client,
            Func<Action<SocketRole>, Func<SocketRole, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RoleCreated += h,
                h => client.RoleCreated -= h);
        }

        /// <summary>
        /// ロールが作成された時に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketRole> NotifyRoleCreated(this BaseSocketClient client)
        {
            return client.NotifyRoleCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
