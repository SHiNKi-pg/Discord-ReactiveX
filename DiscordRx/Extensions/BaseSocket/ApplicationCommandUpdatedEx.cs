using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.ApplicationCommandUpdated"/>
    /// </summary>
    public static class ApplicationCommandUpdatedEx
    {
        private static IObservable<SocketApplicationCommand> NotifyApplicationCommandUpdated(this BaseSocketClient client,
            Func<Action<SocketApplicationCommand>, Func<SocketApplicationCommand, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ApplicationCommandUpdated += h,
                h => client.ApplicationCommandUpdated -= h);
        }

        /// <summary>
        /// ギルド アプリケーション コマンドが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketApplicationCommand> NotifyApplicationCommandUpdated(this BaseSocketClient client)
        {
            return client.NotifyApplicationCommandUpdated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
