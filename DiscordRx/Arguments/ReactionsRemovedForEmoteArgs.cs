using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.ReactionsRemovedForEmote"/>引数
    /// </summary>
    public class ReactionsRemovedForEmoteArgs : ReactionsClearedArgs
    {
        /// <summary>
        /// エモート
        /// </summary>
        public required IEmote Emote { get; init; }
    }
}
