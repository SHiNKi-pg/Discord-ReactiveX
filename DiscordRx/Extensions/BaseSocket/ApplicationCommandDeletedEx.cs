using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ApplicationCommandDeleted"/>拡張メソッド
    /// </summary>
    public static class ApplicationCommandDeletedEx
    {
        private static IObservable<SocketApplicationCommand> NotifyApplicationCommandDeleted(this BaseSocketClient client,
            Func<Action<SocketApplicationCommand>, Func<SocketApplicationCommand, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ApplicationCommandDeleted += h,
                h => client.ApplicationCommandDeleted -= h);
        }

        /// <summary>
        /// ギルド アプリケーション コマンドが削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketApplicationCommand> NotifyApplicationCommandDeleted(this BaseSocketClient client)
        {
            return client.NotifyApplicationCommandDeleted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
