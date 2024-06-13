using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <see cref="BaseSocketClient.AutocompleteExecuted"/>拡張メソッド
    /// </summary>
    public static class AutocompleteExecutedEx
    {
        private static IObservable<SocketAutocompleteInteraction> NotifyAutocompleteExecuted(this BaseSocketClient client,
            Func<Action<SocketAutocompleteInteraction>, Func<SocketAutocompleteInteraction, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.AutocompleteExecuted += h,
                h => client.AutocompleteExecuted -= h);
        }

        /// <summary>
        /// オートコンプリートが使用され、そのインタラクションが受信されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketAutocompleteInteraction> NotifyAutocompleteExecuted(this BaseSocketClient client)
        {
            return client.NotifyAutocompleteExecuted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
