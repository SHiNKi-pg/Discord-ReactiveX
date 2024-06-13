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
    /// <see cref="BaseSocketClient.UserIsTyping"/>拡張メソッド
    /// </summary>
    public static class UserIsTypingEx
    {
        private static IObservable<UserIsTypingArgs> NotifyUserIsTyping(this BaseSocketClient client,
            Func<Action<UserIsTypingArgs>, Func<Cacheable<IUser, ulong>, Cacheable<IMessageChannel, ulong>, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.UserIsTyping += h,
                h => client.UserIsTyping -= h);
        }

        /// <summary>
        /// ユーザーが入力を開始したときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<UserIsTypingArgs> NotifyUserIsTyping(this BaseSocketClient client)
        {
            return client.NotifyUserIsTyping(h => (user, channel) =>
            {
                h(new()
                {
                    User = user,
                    Channel = channel
                });
                return Task.CompletedTask;
            });
        }
    }
}
