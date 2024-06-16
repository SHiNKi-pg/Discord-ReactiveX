using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.CurrentUserUpdated"/> 引数
    /// </summary>
    public class CurrentUserUpdatedArgs : IDiscordEventArgs<SocketSelfUser, SocketSelfUser>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketSelfUser Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketSelfUser Arg2 { get; init; }
    }
}
