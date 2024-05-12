using Discord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseDiscord
{
    /// <summary>
    /// <seealso cref="BaseDiscordClient.LoggedIn"/>と <seealso cref="BaseDiscordClient.LoggedOut"/> 拡張メソッド定義
    /// </summary>
    public static class LoggedInOutEx
    {
        /// <summary>
        /// ログインすると通知されます。
        /// </summary>
        /// <param name="discordClient"></param>
        /// <returns></returns>
        public static IObservable<Unit> NotifyLoggedIn(this BaseDiscordClient discordClient)
        {
            return Observable.FromEvent<Func<Task>, Unit>(h => () =>
            {
                h(Unit.Default);
                return Task.CompletedTask;
            },
            h => discordClient.LoggedIn += h,
            h => discordClient.LoggedIn -= h);
        }

        /// <summary>
        /// ログアウトすると通知されます。
        /// </summary>
        /// <param name="discordClient"></param>
        /// <returns></returns>
        public static IObservable<Unit> NotifyLoggedOut(this BaseDiscordClient discordClient)
        {
            return Observable.FromEvent<Func<Task>, Unit>(h => () =>
            {
                h(Unit.Default);
                return Task.CompletedTask;
            },
            h => discordClient.LoggedOut += h,
            h => discordClient.LoggedOut -= h);
        }
    }
}
