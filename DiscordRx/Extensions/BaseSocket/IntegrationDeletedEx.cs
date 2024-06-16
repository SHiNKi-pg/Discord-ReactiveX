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
    /// <seealso cref="BaseSocketClient.IntegrationDeleted"/> 拡張メソッド
    /// </summary>
    public static class IntegrationDeletedEx
    {
        private static IObservable<IntegrationDeletedArgs> NotifyIntegrationDeleted(this BaseSocketClient client,
            Func<Action<IntegrationDeletedArgs>, Func<IGuild, ulong, Optional<ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.IntegrationDeleted += h,
                h => client.IntegrationDeleted -= h);
        }

        /// <summary>
        /// 統合が削除されたときに発生します。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<IntegrationDeletedArgs> NotifyIntegrationDeleted(this BaseSocketClient client)
        {
            return client.NotifyIntegrationDeleted(h => (arg1, arg2, arg3) =>
            {
                h(new()
                {
                    Arg1 = arg1,
                    Arg2 = arg2,
                    Arg3 = arg3,
                });
                return Task.CompletedTask;
            });
        }
    }
}
