using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.IntegrationUpdated"/> 拡張メソッド
    /// </summary>
    public static class IntegrationUpdatedEx
    {
        private static IObservable<IIntegration> NotifyIntegrationUpdated(this BaseSocketClient client,
            Func<Action<IIntegration>, Func<IIntegration, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.IntegrationUpdated += h,
                h => client.IntegrationUpdated -= h);
        }

        /// <summary>
        /// 統合が更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<IIntegration> NotifyIntegrationUpdated(this BaseSocketClient client)
        {
            return client.NotifyIntegrationUpdated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
