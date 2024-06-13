using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.SlashCommandExecuted"/>拡張メソッド
    /// </summary>
    public static class SlashCommandExecutedEx
    {
        private static IObservable<SocketSlashCommand> NotifySlashCommandExecuted(this BaseSocketClient client,
            Func<Action<SocketSlashCommand>, Func<SocketSlashCommand, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.SlashCommandExecuted += h,
                h => client.SlashCommandExecuted -= h);
        }

        /// <summary>
        /// スラッシュ コマンドが使用され、その操作が受信されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketSlashCommand> NotifySlashCommandExecuted(this BaseSocketClient client)
        {
            return client.NotifySlashCommandExecuted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
