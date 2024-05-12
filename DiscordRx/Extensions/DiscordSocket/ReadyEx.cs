using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.DiscordSocket
{
    /// <summary>
    /// <seealso cref="DiscordSocketClient.Ready"/> 拡張メソッド
    /// </summary>
    public static class ReadyEx
    {
        /// <summary>
        /// 準備完了した時に通知されます。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <returns></returns>
        public static IObservable<Unit> NotifyReady(this DiscordSocketClient socketClient)
        {
            return Observable.FromEvent<Func<Task>, Unit>(h => () =>
            {
                h(Unit.Default);
                return Task.CompletedTask;
            },
            h => socketClient.Ready += h,
            h => socketClient.Ready -= h);
        }
    }
}
