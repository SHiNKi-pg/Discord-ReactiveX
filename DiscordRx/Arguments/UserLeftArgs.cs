using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <see cref="BaseSocketClient.UserLeft"/>引数
    /// </summary>
    public class UserLeftArgs : IDiscordEventArgs<SocketGuild, SocketUser>
    {
        /// <summary>
        /// サーバー
        /// </summary>
        public required SocketGuild Guild { get; init; }

        /// <summary>
        /// ユーザー
        /// </summary>
        public required SocketUser User { get; init; }

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public SocketUser Arg2 => User;

        /// <summary>
        /// 
        /// </summary>
        public SocketGuild Arg1 => Guild;
        #endregion
    }
}
