using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.MessagesBulkDeleted"/> 引数
    /// </summary>
    public class MessagesBulkDeletedArgs : IDownloadable,
        IDiscordEventArgs<IReadOnlyCollection<Cacheable<IMessage, ulong>>, Cacheable<IMessageChannel, ulong>>
    {
        /// <summary>
        /// 
        /// </summary>
        public required Cacheable<IMessageChannel, ulong> Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required IReadOnlyCollection<Cacheable<IMessage, ulong>> Arg1 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            await Arg2.GetOrDownloadAsync().ConfigureAwait(false);
            // TODO: 並列可能なら並列にする
            foreach(var message in Arg1)
            {
                await message.GetOrDownloadAsync().ConfigureAwait(false);
            }
        }
    }
}
