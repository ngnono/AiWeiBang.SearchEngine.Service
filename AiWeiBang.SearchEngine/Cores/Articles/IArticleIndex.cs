using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public interface IArticleIndex
    {
        void FullBuild(IDictionary<string, object> args);

        void IncrementBuild(IDictionary<string, object> args);

        /// <summary>
        /// 任务型，完成任务停止
        /// </summary>
        /// <param name="args"></param>
        void TaskIncrementBuild(IDictionary<string, object> args);
    }
}