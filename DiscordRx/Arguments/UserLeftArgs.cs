using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.UserLeft"/>
    /// </summary>
    public class UserLeftArgs
    {
        /// <summary>
        /// サーバー
        /// </summary>
        public required SocketGuild Guild { get; init; }

        /// <summary>
        /// ユーザー
        /// </summary>
        public required SocketUser User { get; init; }
    }
}
