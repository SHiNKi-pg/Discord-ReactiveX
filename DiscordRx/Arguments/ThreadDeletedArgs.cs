using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.ThreadDeleted"/>引数
    /// </summary>
    public class ThreadDeletedArgs : IDownloadable
    {
        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketThreadChannel, ulong> ThreadChannel { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [ThreadChannel.GetOrDownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
