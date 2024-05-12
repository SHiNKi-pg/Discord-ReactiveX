using Discord;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseDiscord
{
    /// <summary>
    /// <seealso cref="BaseDiscordClient.Log"/> 拡張メソッド
    /// </summary>
    public static class LogEx
    {
        /// <summary>
        /// ログ出力されると通知されます。
        /// </summary>
        /// <param name="discordClient"></param>
        /// <returns></returns>
        public static IObservable<LogMessage> NotifyLogs(this BaseDiscordClient discordClient)
        {
            return Observable.FromEvent<Func<LogMessage, Task>, LogMessage>(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            },
            h => discordClient.Log += h,
            h => discordClient.Log -= h);
        }
    }
}
