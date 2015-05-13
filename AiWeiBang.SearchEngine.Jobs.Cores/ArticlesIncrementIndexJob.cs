using AiWeiBang.SearchEngine.Cores.Articles;
using Common.Logging;
using Quartz;
using System;

namespace AiWeiBang.SearchEngine.Jobs.Cores
{
    /// <summary>
    /// 文章 增量 索引 根据LASTID
    /// </summary>
    [DisallowConcurrentExecution]
    public class ArticlesIncrementIndexJob : BaseIndexJob, IJob
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(ArticlesIncrementIndexJob));
        private readonly IArticleIndex _articleIndex;

        public ArticlesIncrementIndexJob()
            : this(new ArticleIndex(new ArticleStorageIndex()))
        {
        }

        public ArticlesIncrementIndexJob(IArticleIndex articleIndex)
        {
            Log.Info(".ctor");
            _articleIndex = articleIndex;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.Info(String.Format("Execute.context:{0}", context));
            _articleIndex.IncrementBuild(context.MergedJobDataMap);
        }
    }

    /// <summary>
    /// 指定任务型 JOB
    /// </summary>
    [DisallowConcurrentExecution]
    public class TaskArticlesIncrementIndexJob : BaseIndexJob, IJob
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(TaskArticlesIncrementIndexJob));
        private readonly IArticleIndex _articleIndex;

        public TaskArticlesIncrementIndexJob()
            : this(new ArticleIndex(new ArticleStorageIndex()))
        {
        }

        public TaskArticlesIncrementIndexJob(IArticleIndex articleIndex)
        {
            Log.Info(".ctor");
            _articleIndex = articleIndex;
        }

        public void Execute(IJobExecutionContext context)
        {
            Log.Info(String.Format("Execute.context:{0}", context));
            _articleIndex.TaskIncrementBuild(context.MergedJobDataMap);
        }
    }
}