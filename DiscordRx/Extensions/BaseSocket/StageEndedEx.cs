using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.StageEnded"/>拡張メソッド
    /// </summary>
    public static class StageEndedEx
    {
        private static IObservable<SocketStageChannel> NotifyStageEnded(this BaseSocketClient client,
            Func<Action<SocketStageChannel>, Func<SocketStageChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.StageEnded += h,
                h => client.StageEnded -= h);
        }

        /// <summary>
        /// ステージ終了時に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketStageChannel> NotifyStageEnded(this BaseSocketClient client)
        {
            return client.NotifyStageEnded(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
