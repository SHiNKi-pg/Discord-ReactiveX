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
    /// <seealso cref="BaseSocketClient.MessageUpdated"/> イベント引数用クラス
    /// </summary>
    public class MessageUpdatedArgs : IDownloadable
    {
        /// <summary>
        /// メッセージ
        /// </summary>
        public required Cacheable<IMessage, ulong> Message { get; init; }

        /// <summary>
        /// Socketメッセージ
        /// </summary>
        public required SocketMessage SocketMessage { get; init; }

        /// <summary>
        /// チャンネル
        /// </summary>
        public required ISocketMessageChannel Channel { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [Message.DownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
