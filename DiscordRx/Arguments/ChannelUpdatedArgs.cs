using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ChannelUpdated"/> 引数
    /// </summary>
    public class ChannelUpdatedArgs : IDiscordEventArgs<SocketChannel, SocketChannel>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketChannel Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketChannel Arg2 { get; init; }
    }
}
