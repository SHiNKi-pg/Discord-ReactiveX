using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.MessageCommandExecuted"/> 拡張メソッド
    /// </summary>
    public static class MessageCommandExecutedEx
    {
        private static IObservable<SocketMessageCommand> NotifyMessageCommandExecuted(this BaseSocketClient client,
            Func<Action<SocketMessageCommand>, Func<SocketMessageCommand, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.MessageCommandExecuted += h,
                h => client.MessageCommandExecuted -= h);
        }

        /// <summary>
        /// メッセージ コマンドが使用され、その対話が受信されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketMessageCommand> NotifyMessageCommandExecuted(this BaseSocketClient client)
        {
            return client.NotifyMessageCommandExecuted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
