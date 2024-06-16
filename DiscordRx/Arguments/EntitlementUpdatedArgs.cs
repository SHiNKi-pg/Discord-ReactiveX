using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.EntitlementUpdated"/> 引数
    /// </summary>
    public class EntitlementUpdatedArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<SocketEntitlement, ulong>, SocketEntitlement>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketEntitlement Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketEntitlement, ulong> Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            await Arg1.GetOrDownloadAsync().ConfigureAwait(false);
        }
    }
}
