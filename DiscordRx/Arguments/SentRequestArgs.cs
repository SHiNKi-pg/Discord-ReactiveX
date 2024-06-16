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
    /// <seealso cref="BaseDiscordClient.SentRequest"/> 引数
    /// </summary>
    public class SentRequestArgs : IDiscordEventArgs<string, string, double>
    {
        /// <summary>
        /// 
        /// </summary>
        public required double Arg3 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required string Arg2 { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public required string Arg1 { get; init; }
    }
}
