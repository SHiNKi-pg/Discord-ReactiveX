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
    /// <seealso cref="BaseSocketClient.MessageDeleted"/> イベント引数用クラス
    /// </summary>
    public class MessageDeletedArgs
    {
        /// <summary>
        /// 削除されたメッセージ
        /// </summary>
        public required Cacheable<IMessage, ulong> Message { get; init; }

        /// <summary>
        /// 削除されたメッセージのチャンネル
        /// </summary>
        public required Cacheable<IMessageChannel, ulong> Channel { get; init; }
    }
}
