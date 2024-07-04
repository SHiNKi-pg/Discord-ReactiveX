using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.StageUpdated"/>引数
    /// </summary>
    public class StageUpdatedArgs : IDiscordEventArgs<SocketStageChannel, SocketStageChannel>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketStageChannel Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketStageChannel Arg1 { get; init; }
    }
}
