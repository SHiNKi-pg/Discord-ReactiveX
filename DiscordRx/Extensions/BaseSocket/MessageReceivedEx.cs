using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Extensions.BaseSocket
{
    /// <summary>
    /// MessageReceived 拡張メソッド定義クラス
    /// </summary>
    public static class MessageReceivedEx
    {
        private static IObservable<SocketMessage> MessageReceivedObservable(this BaseSocketClient socketClient, Func<Action<SocketMessage>, Func<SocketMessage, Task>> conversion)
        {
            return Observable.FromEvent<Func<SocketMessage, Task>, SocketMessage>(
                conversion,
                h => socketClient.MessageReceived += h,
                h => socketClient.MessageReceived -= h
            );
        }

        /// <summary>
        /// メッセージを受信すると通知されるオブジェクトを返します。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <returns></returns>
        public static IObservable<SocketMessage> MessageReceivedObservable(this BaseSocketClient socketClient)
        {
            return socketClient.MessageReceivedObservable(h => e =>
            {
                h(e);
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// メッセージを受信すると通知されるオブジェクトを返します。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <param name="filter">通知データの選択関数</param>
        /// <returns></returns>
        public static IObservable<SocketMessage> MessageReceivedObservable(this BaseSocketClient socketClient, Func<SocketMessage, bool> filter)
        {
            return socketClient.MessageReceivedObservable(h => e =>
            {
                if (filter(e))
                    h(e);
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// メッセージを受信すると通知されるオブジェクトを返します。
        /// </summary>
        /// <param name="socketClient"></param>
        /// <param name="filter">通知データの選択関数</param>
        /// <returns></returns>
        public static IObservable<SocketMessage> MessageReceivedObservable(this BaseSocketClient socketClient, Func<SocketMessage, Task<bool>> filter)
        {
            return socketClient.MessageReceivedObservable(h => async e =>
            {
                if (await filter(e))
                    h(e);
            });
        }
    }
}
