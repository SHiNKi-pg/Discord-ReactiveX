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
    /// <seealso cref="BaseSocketClient.SpeakerRemoved"/>拡張メソッド
    /// </summary>
    public static class SpeakerRemovedEx
    {
        private static IObservable<SpeakerRemovedArgs> NotifySpeakerRemoved(this BaseSocketClient client,
            Func<Action<SpeakerRemovedArgs>, Func<SocketStageChannel, SocketGuildUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.SpeakerRemoved += h,
                h => client.SpeakerRemoved -= h);
        }

        /// <summary>
        /// スピーカーがステージ チャネルから削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SpeakerRemovedArgs> NotifySpeakerRemoved(this BaseSocketClient client)
        {
            return client.NotifySpeakerRemoved(h => (stage, user) =>
            {
                h(new()
                {
                    Arg1 = stage,
                    Arg2 = user,
                });
                return Task.CompletedTask;
            });
        }
    }
}
