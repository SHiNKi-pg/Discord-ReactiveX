using DiscordRx.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.InviteDeleted"/> 拡張メソッド
    /// </summary>
    public static class InviteDeletedEx
    {
        private static IObservable<InviteDeletedArgs> NotifyInviteDeleted(this BaseSocketClient client,
            Func<Action<InviteDeletedArgs>, Func<SocketGuildChannel, string, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.InviteDeleted += h,
                h => client.InviteDeleted -= h);
        }

        /// <summary>
        /// 招待が削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<InviteDeletedArgs> NotifyInviteDeleted(this BaseSocketClient client)
        {
            return client.NotifyInviteDeleted(h => (arg1, arg2) =>
            {
                h(new()
                {
                    Arg1 = arg1,
                    Arg2 = arg2,
                });
                return Task.CompletedTask;
            });
        }
    }
}
