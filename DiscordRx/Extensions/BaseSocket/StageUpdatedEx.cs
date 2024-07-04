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
    /// <seealso cref="BaseSocketClient.StageUpdated"/>拡張メソッド
    /// </summary>
    public static class StageUpdatedEx
    {
        private static IObservable<StageUpdatedArgs> NotifyStageUpdated(this BaseSocketClient client,
            Func<Action<StageUpdatedArgs>, Func<SocketStageChannel, SocketStageChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.StageUpdated += h,
                h => client.StageUpdated -= h);
        }

        /// <summary>
        /// ステージが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<StageUpdatedArgs> NotifyStageUpdated(this BaseSocketClient client)
        {
            return client.NotifyStageUpdated(h => (a, b) =>
            {
                h(new()
                {
                    Arg1 = a,
                    Arg2 = b,
                });
                return Task.CompletedTask;
            });
        }
    }
}
