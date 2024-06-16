using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using DiscordRx.Core;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.ThreadDeleted"/>引数
    /// </summary>
    public class ThreadDeletedArgs : IDownloadable, IDiscordEventArgs<Cacheable<SocketThreadChannel, ulong>>
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

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public Cacheable<SocketThreadChannel, ulong> Arg1 => ThreadChannel;
        #endregion
    }
}
