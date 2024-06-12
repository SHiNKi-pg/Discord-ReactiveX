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
    /// <see cref="BaseSocketClient.UserLeft"/>拡張メソッド
    /// </summary>
    public static class UserLeftEx
    {
        private static IObservable<UserLeftArgs> NotifyUserLeft(this BaseSocketClient client,
            Func<Action<UserLeftArgs>, Func<SocketGuild, SocketUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.UserLeft += h,
                h => client.UserLeft -= h);
        }

        /// <summary>
        /// ユーザーがサーバーから離脱した時に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<UserLeftArgs> NotifyUserLeft(this BaseSocketClient client)
        {
            return client.NotifyUserLeft(h => (guild, user) =>
            {
                h(new()
                {
                    Guild = guild,
                    User = user
                });
                return Task.CompletedTask;
            });
        }
    }
}
