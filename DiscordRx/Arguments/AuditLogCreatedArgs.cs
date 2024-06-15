using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.AuditLogCreated"/>引数
    /// </summary>
    public class AuditLogCreatedArgs
    {
        /// <summary>
        /// 監査ログ
        /// </summary>
        public required SocketAuditLogEntry AuditLogEntry { get; init; }

        /// <summary>
        /// サーバー
        /// </summary>
        public required SocketGuild Guild { get; init; }
    }
}
