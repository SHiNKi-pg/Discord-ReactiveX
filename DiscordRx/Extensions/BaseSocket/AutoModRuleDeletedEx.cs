using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.AutoModRuleDeleted"/>拡張メソッド
    /// </summary>
    public static class AutoModRuleDeletedEx
    {
        private static IObservable<SocketAutoModRule> NotifyAutoModRuleDeleted(this BaseSocketClient client,
            Func<Action<SocketAutoModRule>, Func<SocketAutoModRule, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AutoModRuleDeleted += h,
                h => client.AutoModRuleDeleted -= h);
        }

        /// <summary>
        /// 自動モデレーション ルールが削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketAutoModRule> NotifyAutoModRuleDeleted(this BaseSocketClient client)
        {
            return client.NotifyAutoModRuleDeleted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
