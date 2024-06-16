using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRx.Core;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.UserIsTyping"/>引数
    /// </summary>
    public class UserIsTypingArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<IUser, ulong>, Cacheable<IMessageChannel, ulong>>
    {
        /// <summary>
        /// ユーザー
        /// </summary>
        public required Cacheable<IUser, ulong> User { get; init; }

        /// <summary>
        /// チャンネル
        /// </summary>
        public required Cacheable<IMessageChannel, ulong> Channel { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [User.GetOrDownloadAsync(), Channel.GetOrDownloadAsync()];

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public Cacheable<IMessageChannel, ulong> Arg2 => Channel;

        /// <summary>
        /// 
        /// </summary>
        public Cacheable<IUser, ulong> Arg1 => User;
        #endregion
    }
}
