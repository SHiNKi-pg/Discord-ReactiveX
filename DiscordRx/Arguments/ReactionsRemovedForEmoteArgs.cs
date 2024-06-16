using DiscordRx.Core;
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
    public class ReactionsRemovedForEmoteArgs : ReactionsClearedArgs,
        IDiscordEventArgs<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, IEmote>
    {
        /// <summary>
        /// エモート
        /// </summary>
        public required IEmote Emote { get; init; }

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public IEmote Arg3 => Emote;
        #endregion
    }
}
