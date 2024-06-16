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
    /// <seealso cref="BaseSocketClient.PollVoteAdded"/> 引数
    /// </summary>
    public class PollVoteAddedArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<IUser, ulong>, Cacheable<ISocketMessageChannel, IRestMessageChannel, IMessageChannel, ulong>, Cacheable<IUserMessage, ulong>, Cacheable<SocketGuild, RestGuild, IGuild, ulong>?, ulong>
    {
        /// <summary>
        /// 
        /// </summary>
        public required ulong Arg5 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<SocketGuild, RestGuild, IGuild, ulong>? Arg4 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<IUserMessage, ulong> Arg3 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<ISocketMessageChannel, IRestMessageChannel, IMessageChannel, ulong> Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<IUser, ulong> Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            await Arg1.GetOrDownloadAsync().ConfigureAwait(false);
            await Arg2.GetOrDownloadAsync().ConfigureAwait(false);
            await Arg3.GetOrDownloadAsync().ConfigureAwait(false);
            if (Arg4.HasValue)
                await Arg4.Value.GetOrDownloadAsync().ConfigureAwait(false);
        }
    }
}
