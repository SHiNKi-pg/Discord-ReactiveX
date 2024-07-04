using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.StageStarted"/>拡張メソッド
    /// </summary>
    public static class StageStartedEx
    {
        private static IObservable<SocketStageChannel> NotifyStageStarted(this BaseSocketClient client,
            Func<Action<SocketStageChannel>, Func<SocketStageChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.StageStarted += h,
                h => client.StageStarted -= h);
        }

        /// <summary>
        /// ステージが開始されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketStageChannel> NotifyStageStarted(this BaseSocketClient client)
        {
            return client.NotifyStageStarted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
