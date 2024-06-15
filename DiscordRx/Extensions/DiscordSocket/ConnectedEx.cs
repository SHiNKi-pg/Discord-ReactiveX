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
    /// <see cref="DiscordSocketClient.Connected"/>拡張メソッド
    /// </summary>
    public static class ConnectedEx
    {
        /// <summary>
        /// Discord ゲートウェイに接続されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<Unit> NotifyConnected(this DiscordSocketClient client)
        {
            return Observable.FromEvent<Func<Task>, Unit>(h => () =>
            {
                h(Unit.Default);
                return Task.CompletedTask;
            },
            h => client.Connected += h,
            h => client.Connected -= h);
        }
    }
}
