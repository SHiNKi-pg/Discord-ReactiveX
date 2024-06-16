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
    /// <seealso cref="BaseSocketClient.AutoModRuleUpdated"/> 拡張メソッド
    /// </summary>
    public static class AutoModRuleUpdatedEx
    {
        private static IObservable<AutoModRuleUpdatedArgs> NotifyAutoModRuleUpdated(this BaseSocketClient client,
            Func<Action<AutoModRuleUpdatedArgs>, Func<Cacheable<SocketAutoModRule, ulong>, SocketAutoModRule, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AutoModRuleUpdated += h,
                h => client.AutoModRuleUpdated -= h);
        }

        /// <summary>
        /// 自動モデレーション ルールが変更されたときに通知されます。。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<AutoModRuleUpdatedArgs> NotifyAutoModRuleUpdated(this BaseSocketClient client)
        {
            return client.NotifyAutoModRuleUpdated(h => (arg1, arg2) =>
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
