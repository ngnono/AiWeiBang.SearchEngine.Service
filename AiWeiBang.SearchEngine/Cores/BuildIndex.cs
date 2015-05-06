using System.Collections.Generic;
using AiWeiBang.SearchEngine.Cores.Articles;

namespace AiWeiBang.SearchEngine.Cores
{
    /// <summary>
    /// 调度
    /// </summary>
    public class BuildIndex
    {
        private readonly IArticleIndex _articleIndex;

        public BuildIndex(IArticleIndex articleIndex)
        {
            this._articleIndex = articleIndex;
        }

        public void FullBuild()
        {
            //1 整理article
            // 倒序整理 article 记录最后 articleID 每次小于这个ID抽取数据

            _articleIndex.FullBuild();
        }

        public void Increment(IDictionary<string, object> args)
        {
            _articleIndex.IncrementBuild(args);
        }
    }
}