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
    /// <seealso cref="BaseSocketClient.EntitlementUpdated"/> 拡張メソッド
    /// </summary>
    public static class EntitlementUpdatedEx
    {
        private static IObservable<EntitlementUpdatedArgs> NotifyEntitlementUpdated(this BaseSocketClient client,
            Func<Action<EntitlementUpdatedArgs>, Func<Cacheable<SocketEntitlement, ulong>, SocketEntitlement, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.EntitlementUpdated += h,
                h => client.EntitlementUpdated -= h);
        }

        /// <summary>
        /// SKU へのサブスクリプションが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<EntitlementUpdatedArgs> NotifyEntitlementUpdated(this BaseSocketClient client)
        {
            return client.NotifyEntitlementUpdated(h => (arg1, arg2) =>
            {
                h(new()
                {
                    Arg1 = arg1,
                    Arg2 = arg2,
                });
                return Task.CompletedTask;
            });
        }
    }
}
