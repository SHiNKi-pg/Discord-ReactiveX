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
    /// <seealso cref="BaseSocketClient.MessagesBulkDeleted"/> 拡張メソッド
    /// </summary>
    public static class MessagesBulkDeletedEx
    {
        private static IObservable<MessagesBulkDeletedArgs> NotifyMessagesBulkDeleted(this BaseSocketClient client,
            Func<Action<MessagesBulkDeletedArgs>, Func<IReadOnlyCollection<Cacheable<IMessage, ulong>>, Cacheable<IMessageChannel, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.MessagesBulkDeleted += h,
                h => client.MessagesBulkDeleted -= h);
        }

        /// <summary>
        /// 複数のメッセージが一括削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<MessagesBulkDeletedArgs> NotifyMessagesBulkDeleted(this BaseSocketClient client)
        {
            return client.NotifyMessagesBulkDeleted(h => (arg1, arg2) =>
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
