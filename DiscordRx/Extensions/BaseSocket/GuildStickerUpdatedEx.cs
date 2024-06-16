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
    /// <seealso cref="BaseSocketClient.GuildStickerUpdated"/> 拡張メソッド
    /// </summary>
    public static class GuildStickerUpdatedEx
    {
        private static IObservable<GuildStickerUpdatedArgs> NotifyGuildStickerUpdated(this BaseSocketClient client,
            Func<Action<GuildStickerUpdatedArgs>, Func<SocketCustomSticker, SocketCustomSticker, Task>> conversion)
        {
            return Observable.FromEvent(conversion,
                h => client.GuildStickerUpdated += h,
                h => client.GuildStickerUpdated -= h);
        }

        /// <summary>
        /// ギルド内のステッカーが更新されたときに通知されます。。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IObservable<GuildStickerUpdatedArgs> NotifyGuildStickerUpdated(this BaseSocketClient client)
        {
            return client.NotifyGuildStickerUpdated(h => (arg1, arg2) =>
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
