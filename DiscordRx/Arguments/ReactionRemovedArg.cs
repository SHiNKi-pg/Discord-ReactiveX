using Discord;
using DiscordRx.Core;
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
    public class ReactionRemovedArg : ReactionsClearedArgs,
        IDiscordEventArgs<Cacheable<IUserMessage, ulong>, Cacheable<IMessageChannel, ulong>, SocketReaction>
    {

        /// <summary>
        /// リアクション
        /// </summary>
        public required SocketReaction Reaction { get; init; }

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public SocketReaction Arg3 => Reaction;
        #endregion
    }
}
