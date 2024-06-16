using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildJoinRequestDeleted"/> 引数
    /// </summary>
    public class GuildJoinRequestDeletedArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<SocketGuildUser, ulong>, SocketGuild>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketGuild Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketGuildUser, ulong> Arg1 { get; init; }

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
