using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.ThreadUpdated"/>引数
    /// </summary>
    public class ThreadUpdatedArgs : IDiscordEventArgs<Cacheable<SocketThreadChannel, ulong>, SocketThreadChannel>, IDownloadable
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketThreadChannel Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketThreadChannel, ulong> Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            await Arg1.GetOrDownloadAsync();
        }
    }
}
