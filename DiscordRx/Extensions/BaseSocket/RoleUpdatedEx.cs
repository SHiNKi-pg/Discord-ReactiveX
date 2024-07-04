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
    /// <seealso cref="BaseSocketClient.RoleUpdated"/>拡張メソッド
    /// </summary>
    public static class RoleUpdatedEx
    {
        private static IObservable<RoleUpdatedArgs> NotifyRoleUpdated(this BaseSocketClient client,
            Func<Action<RoleUpdatedArgs>, Func<SocketRole, SocketRole, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RoleUpdated += h,
                h => client.RoleUpdated -= h);
        }

        /// <summary>
        /// ロールが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<RoleUpdatedArgs> NotifyRoleUpdated(this BaseSocketClient client)
        {
            return client.NotifyRoleUpdated(h => (a, b) =>
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
