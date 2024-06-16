using Discord;
using Discord.WebSocket;
using DiscordRx.Core;
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
    public class ReactionAddedArgs : IDownloadable
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [Message.DownloadAsync(), Channel.DownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
