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
    /// <seealso cref="BaseSocketClient.ChannelUpdated"/> 拡張メソッド
    /// </summary>
    public static class ChannelUpdatedEx
    {
        private static IObservable<ChannelUpdatedArgs> NotifyChannelUpdated(this BaseSocketClient client,
            Func<Action<ChannelUpdatedArgs>, Func<SocketChannel, SocketChannel, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.ChannelUpdated += h,
                h => client.ChannelUpdated -= h);
        }

        /// <summary>
        /// チャネルが更新されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<ChannelUpdatedArgs> NotifyChannelUpdated(this BaseSocketClient client)
        {
            return client.NotifyChannelUpdated(h => (arg1, arg2) =>
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
