using Discord.Webhook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.WebhookClient
{
    /// <summary>
    /// <seealso cref="DiscordWebhookClient.Log"/> 拡張メソッド
    /// </summary>
    public static class WebhookLogEx
    {
        private static IObservable<LogMessage> NotifyLog(this DiscordWebhookClient client,
            Func<Action<LogMessage>, Func<LogMessage, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.Log += h,
                h => client.Log -= h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<LogMessage> NotifyLog(this DiscordWebhookClient client)
        {
            return client.NotifyLog(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
