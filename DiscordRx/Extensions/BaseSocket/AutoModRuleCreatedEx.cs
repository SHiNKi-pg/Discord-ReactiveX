using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.AutoModRuleCreated"/>拡張メソッド
    /// </summary>
    public static class AutoModRuleCreatedEx
    {
        private static IObservable<SocketAutoModRule> NotifyAutoModRuleCreated(this BaseSocketClient client,
            Func<Action<SocketAutoModRule>, Func<SocketAutoModRule, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AutoModRuleCreated += h,
                h => client.AutoModRuleCreated -= h);
        }

        /// <summary>
        /// 自動モデレーション ルールが作成されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketAutoModRule> NotifyAutoModRuleCreated(this BaseSocketClient client)
        {
            return client.NotifyAutoModRuleCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
