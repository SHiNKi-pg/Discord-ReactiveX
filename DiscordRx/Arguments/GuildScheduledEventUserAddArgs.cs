using Discord.Rest;
using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildScheduledEventUserAdd"/> 引数
    /// </summary>
    public class GuildScheduledEventUserAddArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<SocketUser, RestUser, IUser, ulong>, SocketGuildEvent>
    {
        /// <summary>
        /// 
        /// </summary>
        public required SocketGuildEvent Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketUser, RestUser, IUser, ulong> Arg1 { get; init; }

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
