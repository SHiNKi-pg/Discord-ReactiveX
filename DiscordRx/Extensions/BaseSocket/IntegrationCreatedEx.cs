using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.IntegrationCreated"/> 拡張メソッド
    /// </summary>
    public static class IntegrationCreatedEx
    {
        private static IObservable<IIntegration> NotifyIntegrationCreated(this BaseSocketClient client,
            Func<Action<IIntegration>, Func<IIntegration, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.IntegrationCreated += h,
                h => client.IntegrationCreated -= h);
        }

        /// <summary>
        /// 統合が作成されたときに起動されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<IIntegration> NotifyIntegrationCreated(this BaseSocketClient client)
        {
            return client.NotifyIntegrationCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
