using Discord;
using Discord.WebSocket;
using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.MessageDeleted"/> イベント引数用クラス
    /// </summary>
    public class MessageDeletedArgs : IDownloadable,
        IDiscordEventArgs<Cacheable<IMessage, ulong>, Cacheable<IMessageChannel, ulong>>
    {
        /// <summary>
        /// 削除されたメッセージ
        /// </summary>
        public required Cacheable<IMessage, ulong> Message { get; init; }

        /// <summary>
        /// 削除されたメッセージのチャンネル
        /// </summary>
        public required Cacheable<IMessageChannel, ulong> Channel { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task DownloadAsync()
        {
            IEnumerable<Task> taskList = [Message.DownloadAsync(), Channel.DownloadAsync()];

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
        public Cacheable<IMessage, ulong> Arg1 => Message;
        #endregion
    }
}
