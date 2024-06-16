using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildMembersDownloaded"/> 拡張メソッド
    /// </summary>
    public static class GuildMemberDownloadedEx
    {
        private static IObservable<SocketGuild> NotifyGuildMembersDownloaded(this BaseSocketClient client,
            Func<Action<SocketGuild>, Func<SocketGuild, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildMembersDownloaded += h,
                h => client.GuildMembersDownloaded -= h);
        }

        /// <summary>
        /// オフラインのギルド メンバーがダウンロードされたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketGuild> NotifyGuildMembersDownloaded(this BaseSocketClient client)
        {
            return client.NotifyGuildMembersDownloaded(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
