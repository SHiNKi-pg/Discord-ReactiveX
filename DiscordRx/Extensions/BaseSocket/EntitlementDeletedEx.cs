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
    /// <seealso cref="BaseSocketClient.EntitlementDeleted"/> 拡張メソッド
    /// </summary>
    public static class EntitlementDeletedEx
    {
        private static IObservable<EntitlementDeletedArgs> NotifyEntitlementDeleted(this BaseSocketClient client,
            Func<Action<EntitlementDeletedArgs>, Func<Cacheable<SocketEntitlement, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.EntitlementDeleted += h,
                h => client.EntitlementDeleted -= h);
        }

        /// <summary>
        /// ユーザーの権限が削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<EntitlementDeletedArgs> NotifyEntitlementDeleted(this BaseSocketClient client)
        {
            return client.NotifyEntitlementDeleted(h => e =>
            {
                h(new() { Arg1 = e });
                return Task.CompletedTask;
            });
        }
    }
}
