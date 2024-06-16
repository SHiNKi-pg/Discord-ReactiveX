using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.EntitlementCreated"/> 拡張メソッド
    /// </summary>
    public static class EntitlementCreatedEx
    {
        private static IObservable<SocketEntitlement> NotifyEntitlementCreated(this BaseSocketClient client,
            Func<Action<SocketEntitlement>, Func<SocketEntitlement, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.EntitlementCreated += h,
                h => client.EntitlementCreated -= h);
        }

        /// <summary>
        /// ユーザーが SKU をサブスクライブしたときに通知されます。。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketEntitlement> NotifyEntitlementCreated(this BaseSocketClient client)
        {
            return client.NotifyEntitlementCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
