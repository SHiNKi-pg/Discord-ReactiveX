using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.ModalSubmitted"/>拡張メソッド
    /// </summary>
    public static class ModalSubmittedEx
    {
        private static IObservable<SocketModal> NotifyModalSubmitted(this BaseSocketClient client,
            Func<Action<SocketModal>, Func<SocketModal, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ModalSubmitted += h,
                h => client.ModalSubmitted -= h);
        }

        /// <summary>
        /// モーダルが送信されると通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketModal> NotifyModalSubmitted(this BaseSocketClient client)
        {
            return client.NotifyModalSubmitted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
