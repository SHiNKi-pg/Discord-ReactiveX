using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildStickerCreated"/> 拡張メソッド
    /// </summary>
    public static class GuildStickerCreatedEx
    {
        private static IObservable<SocketCustomSticker> NotifyGuildStickerCreated(this BaseSocketClient client,
            Func<Action<SocketCustomSticker>, Func<SocketCustomSticker, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildStickerCreated += h,
                h => client.GuildStickerCreated -= h);
        }

        /// <summary>
        /// ギルド内のステッカーが作成された時に通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketCustomSticker> NotifyGuildStickerCreated(this BaseSocketClient client)
        {
            return client.NotifyGuildStickerCreated(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
