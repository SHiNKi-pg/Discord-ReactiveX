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
    public class ReactionRemovedArg : IDownloadable
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
            IEnumerable<Task> taskList = [Message.GetOrDownloadAsync(), Channel.GetOrDownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
