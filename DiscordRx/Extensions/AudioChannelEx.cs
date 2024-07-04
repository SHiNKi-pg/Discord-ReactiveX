using Discord.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions
{
    /// <summary>
    /// <seealso cref="IAudioChannel"/>用拡張メソッド
    /// </summary>
    public static class AudioChannelEx
    {
        /// <summary>
        /// このオーディオ チャネルに接続します。
        /// </summary>
        /// <param name="audioChannel"></param>
        /// <param name="selfDeaf">接続時にクライアントが自らをデフレートするかどうかを決定します。</param>
        /// <param name="selfMute">接続時にクライアントがミュートするかどうかを決定します。</param>
        /// <param name="external">オーディオ クライアントが外部クライアントであるかどうかを決定します。</param>
        /// <param name="disconnect">新しい音声状態を送信する前にクライアントが切断呼び出しを送信するかどうかを決定します。</param>
        /// <returns></returns>
        public static IObservable<IAudioClient> Connect(this IAudioChannel audioChannel,
            bool selfDeaf = false, bool selfMute = false, bool external = false, bool disconnect = true)
        {
            return Observable
                .FromAsync(() => audioChannel.ConnectAsync(selfDeaf, selfMute, external, disconnect))
                ;
        }
    }
}
