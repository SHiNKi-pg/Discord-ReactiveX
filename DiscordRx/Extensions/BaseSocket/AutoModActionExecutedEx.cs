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
    /// <seealso cref="BaseSocketClient.AutoModActionExecuted"/>拡張メソッド
    /// </summary>
    public static class AutoModActionExecutedEx
    {
        private static IObservable<AutoModActionExecutedArgs> NotifyAutoModActionExecuted(this BaseSocketClient client,
            Func<Action<AutoModActionExecutedArgs>, Func<SocketGuild, AutoModRuleAction, AutoModActionExecutedData, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AutoModActionExecuted += h,
                h => client.AutoModActionExecuted -= h);
        }

        /// <summary>
        /// ユーザーによって自動モデレーション ルールがトリガーされたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<AutoModActionExecutedArgs> NotifyAutoModActionExecuted(this BaseSocketClient client)
        {
            return client.NotifyAutoModActionExecuted(h => (guild, ruleAction, executedData) =>
            {
                h(new()
                {
                    Guild = guild,
                    AutoModRuleAction = ruleAction,
                    ExecutedData = executedData,
                });
                return Task.CompletedTask;
            });
        }
    }
}
