using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.UserJoined"/> 拡張メソッド定義
    /// </summary>
    public static class UserJoinedEx
    {
        private static IObservable<SocketGuildUser> NotifyUserJoined(this BaseSocketClient baseSocketClient,
            Func<Action<SocketGuildUser>, Func<SocketGuildUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => baseSocketClient.UserJoined += h,
                h => baseSocketClient.UserJoined -= h
                );
        }

        /// <summary>
        /// ユーザーがサーバーに加入すると通知されます。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <returns></returns>
        public static IObservable<SocketGuildUser> NotifyUserJoined(this BaseSocketClient socketClient)
        {
            return socketClient.NotifyUserJoined(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
