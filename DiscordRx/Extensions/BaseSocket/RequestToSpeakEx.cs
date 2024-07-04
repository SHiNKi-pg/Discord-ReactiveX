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
    /// <seealso cref="BaseSocketClient.RequestToSpeak"/>拡張メソッド
    /// </summary>
    public static class RequestToSpeakEx
    {
        private static IObservable<RequestToSpeakArgs> NotifyRequestToSpeak(this BaseSocketClient client,
            Func<Action<RequestToSpeakArgs>, Func<SocketStageChannel, SocketGuildUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.RequestToSpeak += h,
                h => client.RequestToSpeak -= h);
        }

        /// <summary>
        /// ユーザーがステージ チャネル内で発言を要求したときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<RequestToSpeakArgs> NotifyRequestToSpeak(this BaseSocketClient client)
        {
            return client.NotifyRequestToSpeak(h => (stage, user) =>
            {
                h(new()
                {
                    Arg1 = stage,
                    Arg2 = user
                });
                return Task.CompletedTask;
            });
        }
    }
}
