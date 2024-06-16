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
    /// <seealso cref="BaseSocketClient.CurrentUserUpdated"/> 引数
    /// </summary>
    public static class CurrentUserUpdatedEx
    {
        private static IObservable<CurrentUserUpdatedArgs> NotifyCurrentUserUpdated(this BaseSocketClient client,
            Func<Action<CurrentUserUpdatedArgs>, Func<SocketSelfUser, SocketSelfUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.CurrentUserUpdated += h,
                h => client.CurrentUserUpdated -= h);
        }

        /// <summary>
        /// 接続されたアカウントが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<CurrentUserUpdatedArgs> NotifyCurrentUserUpdated(this BaseSocketClient client)
        {
            return client.NotifyCurrentUserUpdated(h => (arg1, arg2) =>
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
