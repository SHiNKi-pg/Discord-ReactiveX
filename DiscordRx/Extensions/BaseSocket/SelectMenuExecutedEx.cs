using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.SelectMenuExecuted"/>
    /// </summary>
    public static class SelectMenuExecutedEx
    {
        private static IObservable<SocketMessageComponent> NotifySelectMenuExecuted(this BaseSocketClient client,
            Func<Action<SocketMessageComponent>, Func<SocketMessageComponent, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.SelectMenuExecuted += h,
                h => client.SelectMenuExecuted -= h);
        }

        /// <summary>
        /// 選択メニューが使用され、その操作が受信されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketMessageComponent> NotifySelectMenuExecuted(this BaseSocketClient client)
        {
            return client.NotifySelectMenuExecuted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
