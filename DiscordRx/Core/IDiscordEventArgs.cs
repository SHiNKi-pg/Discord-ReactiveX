using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Core
{
    /// <summary>
    /// 引数が1個の Discord用イベント引数インターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDiscordEventArgs<out T>
    {
        /// <summary>
        /// 引数1
        /// </summary>
        T Arg1 { get; }
    }

    /// <summary>
    /// 引数が2個の Discord用イベント引数インターフェース
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface IDiscordEventArgs<out T1, out T2> : IDiscordEventArgs<T1>
    {
        /// <summary>
        /// 引数2
        /// </summary>
        T2 Arg2 { get; }
    }

    /// <summary>
    /// 引数が3個の Discord用イベント引数インターフェース
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public interface IDiscordEventArgs<out T1, out T2, out T3> : IDiscordEventArgs<T1, T2>
    {
        /// <summary>
        /// 引数3
        /// </summary>
        T3 Arg3 { get; }
    }

    /// <summary>
    /// 引数が4個の Discord用イベント引数インターフェース
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public interface IDiscordEventArgs<out T1, out T2, out T3, out T4> : IDiscordEventArgs<T1, T2, T3>
    {
        /// <summary>
        /// 引数4
        /// </summary>
        T4 Arg4 { get; }
    }

    /// <summary>
    /// 引数が5個の Discord用イベント引数インターフェース
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public interface IDiscordEventArgs<out T1, out T2, out T3, out T4, out T5> : IDiscordEventArgs<T1, T2, T3, T4>
    {
        /// <summary>
        /// 引数5
        /// </summary>
        T5 Arg5 { get; }
    }
}
