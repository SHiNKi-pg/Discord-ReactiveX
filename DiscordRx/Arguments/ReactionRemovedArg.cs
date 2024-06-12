using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.ReactionRemoved"/>引数
    /// </summary>
    public class ReactionRemovedArg : ReactionsClearedArgs
    {

        /// <summary>
        /// リアクション
        /// </summary>
        public required SocketReaction Reaction { get; init; }

    }
}
