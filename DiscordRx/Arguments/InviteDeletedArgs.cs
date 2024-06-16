using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.InviteDeleted"/> 拡張メソッド
    /// </summary>
    public class InviteDeletedArgs : IDiscordEventArgs<SocketGuildChannel, string>
    {
        /// <summary>
        /// 
        /// </summary>
        public required string Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketGuildChannel Arg1 { get; init; }
    }
}
