using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// <seealso cref="BaseSocketClient.GuildStickerDeleted"/> 拡張メソッド
    /// </summary>
    public static class GuildStickerDeletedEx
    {
        private static IObservable<SocketCustomSticker> NotifyGuildStickerDeleted(this BaseSocketClient client,
            Func<Action<SocketCustomSticker>, Func<SocketCustomSticker, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildStickerDeleted += h,
                h => client.GuildStickerDeleted -= h);
        }

        /// <summary>
        /// ギルド内のステッカーが削除されたときに通知されます。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<SocketCustomSticker> NotifyGuildStickerDeleted(this BaseSocketClient client)
        {
            return client.NotifyGuildStickerDeleted(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }
    }
}
