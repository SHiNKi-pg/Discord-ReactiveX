using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.RoleUpdated"/>引数
    /// </summary>
    public class RoleUpdatedArgs : IDiscordEventArgs<SocketRole, SocketRole>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketRole Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketRole Arg1 { get; init; }
    }
}
