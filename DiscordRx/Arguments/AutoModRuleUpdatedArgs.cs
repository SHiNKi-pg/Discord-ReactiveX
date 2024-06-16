using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.AutoModRuleUpdated"/>引数
    /// </summary>
    public class AutoModRuleUpdatedArgs :
        IDiscordEventArgs<Cacheable<SocketAutoModRule, ulong>, SocketAutoModRule>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketAutoModRule Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketAutoModRule, ulong> Arg1 { get; init; }
    }
}
