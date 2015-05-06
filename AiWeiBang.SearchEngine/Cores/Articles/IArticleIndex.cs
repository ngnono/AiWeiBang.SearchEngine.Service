using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public interface IArticleIndex
    {
        void FullBuild();

        void IncrementBuild(IDictionary<string, object> args);
    }
}