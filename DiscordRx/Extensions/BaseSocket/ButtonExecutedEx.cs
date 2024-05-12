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
    /// <seealso cref="BaseSocketClient.ButtonExecuted"/> 拡張メソッド定義
    /// </summary>
    public static class ButtonExecutedEx
    {
        private static IObservable<SocketMessageComponent> NotifyButtonExecuted(this BaseSocketClient socketClient,
            Func<Action<SocketMessageComponent>, Func<SocketMessageComponent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => socketClient.ButtonExecuted += h,
                h => socketClient.ButtonExecuted -= h);
        }

        /// <summary>
        /// ボタンが押されると通知されます。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <returns></returns>
        public static IObservable<SocketMessageComponent> NotifyButtonExecuted(this BaseSocketClient socketClient)
        {
            return socketClient.NotifyButtonExecuted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
