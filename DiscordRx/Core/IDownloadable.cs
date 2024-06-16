using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRx.Core
{
    /// <summary>
    /// ダウンロード可能インターフェース
    /// </summary>
    public interface IDownloadable
    {
        /// <summary>
        /// 非同期でデータのダウンロードを実行します。
        /// </summary>
        /// <returns></returns>
        Task DownloadAsync();
    }
}
