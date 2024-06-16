using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.InteractionCreated"/> 拡張メソッド
    /// </summary>
    public static class InteractionCreatedEx
    {
        private static IObservable<SocketInteraction> NotifyInteractionCreated(this BaseSocketClient client,
            Func<Action<SocketInteraction>, Func<SocketInteraction, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.InteractionCreated += h,
                h => client.InteractionCreated -= h);
        }

        /// <summary>
        /// インタラクションが作成された時に通知されます。
        /// このイベントは、ボタン、選択メニュー、スラッシュ コマンド、オートコンプリートなど、すべてのタイプのインタラクションをカバーします。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketInteraction> NotifyInteractionCreated(this BaseSocketClient client)
        {
            return client.NotifyInteractionCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
