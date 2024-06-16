using Discord.Rest;
using DiscordRx.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseDiscord
{
    /// <summary>
    /// <seealso cref="BaseDiscordClient.SentRequest"/> 拡張メソッド
    /// </summary>
    public static class SentRequestEx
    {
        private static IObservable<SentRequestArgs> NotifySentRequest(this BaseDiscordClient client,
            Func<Action<SentRequestArgs>, Func<string, string, double, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.SentRequest += h,
                h => client.SentRequest -= h);
        }

        /// <summary>
        /// REST リクエストが API に送信されたときに通知されます。
        /// 最初のパラメータは HTTP メソッド、2 番目はエンドポイント、3 番目はリクエストの完了にかかる時間です。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SentRequestArgs> NotifySentRequest(this BaseDiscordClient client)
        {
            return client.NotifySentRequest(h => (method, endpoint, completedTime) =>
            {
                h(new()
                {
                    Arg1 = method,
                    Arg2 = endpoint,
                    Arg3 = completedTime,
                });
                return Task.CompletedTask;
            });
        }
    }
}
