using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ApplicationCommandCreated"/>拡張メソッド
    /// </summary>
    public static class ApplicationCommandCreatedEx
    {
        private static IObservable<SocketApplicationCommand> NotifyApplicationCommandCreated(this BaseSocketClient client,
            Func<Action<SocketApplicationCommand>, Func<SocketApplicationCommand, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ApplicationCommandCreated += h,
                h => client.ApplicationCommandCreated -= h);
        }

        /// <summary>
        /// ギルド アプリケーション コマンドが作成された場合に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketApplicationCommand> NotifyApplicationCommandCreated(this BaseSocketClient client)
        {
            return client.NotifyApplicationCommandCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        } 
    }
}
