using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildStickerUpdated"/> 引数
    /// </summary>
    public class GuildStickerUpdatedArgs : IDiscordEventArgs<SocketCustomSticker, SocketCustomSticker>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketCustomSticker Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required SocketCustomSticker Arg1 { get; init; }
    }
}
