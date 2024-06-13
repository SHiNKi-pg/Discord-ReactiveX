using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.GuildMemberUpdated"/>引数
    /// </summary>
    public class GuildMemberUpdatedArgs : IDownloadable
    {
        /// <summary>
        /// 前ユーザー情報
        /// </summary>
        public required Cacheable<SocketGuildUser, ulong> BeforeUserInfo { get; init; }

        /// <summary>
        /// ユーザー情報
        /// </summary>
        public required SocketGuildUser UserInfo { get;init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [BeforeUserInfo.GetOrDownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }
    }
}
