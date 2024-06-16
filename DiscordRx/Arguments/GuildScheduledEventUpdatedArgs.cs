using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildScheduledEventUpdated"/> 拡張メソッド
    /// </summary>
    public class GuildScheduledEventUpdatedArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<SocketGuildEvent, ulong>, SocketGuildEvent>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketGuildEvent Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketGuildEvent, ulong> Arg1 { get; init; }

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
