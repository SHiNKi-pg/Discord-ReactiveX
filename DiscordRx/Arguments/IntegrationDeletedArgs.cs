using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.IntegrationDeleted"/> 引数
    /// </summary>
    public class IntegrationDeletedArgs : IDiscordEventArgs<IGuild, ulong, Optional<ulong>>
    {
        /// <summary>
        /// 
        /// </summary>
        public required Optional<ulong> Arg3 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required ulong Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required IGuild Arg1 { get; init; }
    }
}
