using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.PresenceUpdated"/>引数
    /// </summary>
    public class PresenceUpdatedArgs
    {
        /// <summary>
        /// ユーザー
        /// </summary>
        public required SocketUser User { get; init; }

        /// <summary>
        /// 前プレゼンス情報
        /// </summary>
        public required SocketPresence BeforePresence { get; init; }

        /// <summary>
        /// プレゼンス情報
        /// </summary>
        public required SocketPresence AfterPresence { get; init; }
    }
}
