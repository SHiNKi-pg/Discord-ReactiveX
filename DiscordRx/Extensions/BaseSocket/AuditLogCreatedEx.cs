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
    /// <see cref="BaseSocketClient.AuditLogCreated"/>拡張メソッド
    /// </summary>
    public static class AuditLogCreatedEx
    {
        private static IObservable<AuditLogCreatedArgs> NotifyAuditLogCreated(this BaseSocketClient client,
            Func<Action<AuditLogCreatedArgs>, Func<SocketAuditLogEntry, SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AuditLogCreated += h,
                h => client.AuditLogCreated -= h);
        }

        /// <summary>
        /// ギルド監査ログ エントリが作成された場合に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<AuditLogCreatedArgs> NotifyAuditLogCreated(this BaseSocketClient client)
        {
            return client.NotifyAuditLogCreated(h => (auditLog, guild) =>
            {
                h(new() {
                    AuditLogEntry = auditLog,
                    Guild = guild,
                });
                return Task.CompletedTask;
            });
        }
    }
}
