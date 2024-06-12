using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.ReactionsCleared"/>引数
    /// </summary>
    public class ReactionsClearedArgs : IDownloadable
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
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [Message.GetOrDownloadAsync(), Channel.GetOrDownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
