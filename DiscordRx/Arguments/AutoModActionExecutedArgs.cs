using DiscordRx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Arguments
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.AutoModActionExecuted"/>引数
    /// </summary>
    public class AutoModActionExecutedArgs : IDiscordEventArgs<SocketGuild, AutoModRuleAction, AutoModActionExecutedData>
    {
        /// <summary>
        /// サーバー
        /// </summary>
        public required SocketGuild Guild { get; init; }

        /// <summary>
        /// ルールアクション
        /// </summary>
        public required AutoModRuleAction AutoModRuleAction { get; init; }

        /// <summary>
        /// 実行データ
        /// </summary>
        public required AutoModActionExecutedData ExecutedData { get; init; }

        #region IEventArgs
        /// <summary>
        /// 
        /// </summary>
        public AutoModActionExecutedData Arg3 => ExecutedData;

        /// <summary>
        /// 
        /// </summary>
        public AutoModRuleAction Arg2 => AutoModRuleAction;

        /// <summary>
        /// 
        /// </summary>
        public SocketGuild Arg1 => Guild;
        #endregion
    }
}
