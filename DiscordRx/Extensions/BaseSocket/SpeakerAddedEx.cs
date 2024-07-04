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
    /// <seealso cref="BaseSocketClient.SpeakerAdded"/>拡張メソッド
    /// </summary>
    public static class SpeakerAddedEx
    {
        private static IObservable<SpeakerAddedArgs> NotifySpeakerAdded(this BaseSocketClient client,
            Func<Action<SpeakerAddedArgs>, Func<SocketStageChannel, SocketGuildUser, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.SpeakerAdded += h,
                h => client.SpeakerAdded -= h);
        }

        /// <summary>
        /// ステージ チャネルにスピーカーが追加されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SpeakerAddedArgs> NotifySpeakerAdded(this BaseSocketClient client)
        {
            return client.NotifySpeakerAdded(h => (stage, user) =>
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
