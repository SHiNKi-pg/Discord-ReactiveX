using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.InviteCreated"/> 拡張メソッド
    /// </summary>
    public static class InviteCreatedEx
    {
        private static IObservable<SocketInvite> NotifyInviteCreated(this BaseSocketClient client,
            Func<Action<SocketInvite>, Func<SocketInvite, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.InviteCreated += h,
                h => client.InviteCreated -= h);
        }

        /// <summary>
        /// 招待が作成された場合に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketInvite> NotifyInviteCreated(this BaseSocketClient client)
        {
            return client.NotifyInviteCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
