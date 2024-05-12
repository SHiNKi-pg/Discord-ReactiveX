using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ReactionAdded"/> イベント引数用クラス
    /// </summary>
    public class ReactionAddedArgs
    {
        /// <summary>
        /// メッセージ
        /// </summary>
        public required Cacheable<IUserMessage, ulong> Message { get; init; }

        /// <summary>
        /// チャンネル
        /// </summary>
        public required Cacheable<IMessageChannel, ulong> Channel { get; init; }

        /// <summary>
        /// リアクション
        /// </summary>
        public required SocketReaction Reaction { get; init; }
    }
}
