using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using AiWeiBang.SearchEngine.ApiClient;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Data.Models;
using AiWeiBang.SearchEngine.Dtos;
using AiWeiBang.SearchEngine.Extensions;
using LinqKit;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public class ArticleIndex : IArticleIndex
    {
        private readonly int _intervalCount = ConfigManager.GetDefaultArticleSelectSize;
        private readonly IArticleStorageIndex _articleStorageIndex;
        private readonly static ILog Log = LogManager.GetLogger(typeof(ArticleIndex));
        private readonly int _article_Num_DetailTake = ConfigManager.GetDefaultArticleNumDetailsSize;

        public ArticleIndex(IArticleStorageIndex storageIndex)
        {
            //_intervalCount = intervalCount;
            _articleStorageIndex = storageIndex;
        }

        public static void NoLockInvokeDB(Action action)
        {
            var transactionOptions = new System.Transactions.TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
            using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    action();
                }
                finally
                {
                    transactionScope.Complete();
                }
            }
        }


        private static Expression<Func<Article, bool>> Filter(ArticleFilter filter)
        {
            var query = PredicateBuilder.True<Article>();

            if (filter != null)
            {
                if (filter.ArticleID != null)
                {
                    query = query.And(v => v.ArticleID == filter.ArticleID);
                }

                //范围查询
                if (filter.PostDateRange != null)
                {
                    if (filter.PostDateRange.Gte != null)
                    {
                        query = query.And(v => v.PostDate >= filter.PostDateRange.Gte);
                    }
                    else if (filter.PostDateRange.Gt != null)
                    {
                        query = query.And(v => v.PostDate > filter.PostDateRange.Gt);
                    }

                    if (filter.PostDateRange.Lte != null)
                    {
                        query = query.And(v => v.PostDate <= filter.PostDateRange.Lte);
                    }
                    else if (filter.PostDateRange.Lt != null)
                    {
                        query = query.And(v => v.PostDate < filter.PostDateRange.Lt);
                    }
                }

                //范围查询
                if (filter.RecordDateRange != null)
                {
                    if (filter.RecordDateRange.Gte != null)
                    {
                        query = query.And(v => v.RecordTime >= filter.RecordDateRange.Gte);
                    }
                    else if (filter.RecordDateRange.Gt != null)
                    {
                        query = query.And(v => v.RecordTime > filter.RecordDateRange.Gt);
                    }

                    if (filter.RecordDateRange.Lte != null)
                    {
                        query = query.And(v => v.RecordTime <= filter.RecordDateRange.Lte);
                    }
                    else if (filter.RecordDateRange.Lt != null)
                    {
                        query = query.And(v => v.RecordTime < filter.RecordDateRange.Lt);
                    }
                }

                //范围查询
                if (filter.ArticleIdRange != null)
                {
                    if (filter.ArticleIdRange.Gte != null)
                    {
                        query = query.And(v => v.ArticleID >= filter.ArticleIdRange.Gte);
                    }
                    else if (filter.ArticleIdRange.Gt != null)
                    {
                        query = query.And(v => v.ArticleID > filter.ArticleIdRange.Gt);
                    }

                    if (filter.ArticleIdRange.Lte != null)
                    {
                        query = query.And(v => v.ArticleID <= filter.ArticleIdRange.Lte);
                    }
                    else if (filter.ArticleIdRange.Lt != null)
                    {
                        query = query.And(v => v.ArticleID < filter.ArticleIdRange.Lt);
                    }
                }
            }


            return query;
        }

        private static Expression<Func<MsColumnArticle, bool>> MsColumnsFilter(ArticleColumnFilter filter)
        {
            var query = PredicateBuilder.True<MsColumnArticle>();

            if (filter != null)
            {
                //范围查询
                if (filter.RangeArticleId != null)
                {
                    if (filter.RangeArticleId.Gte != null)
                    {
                        query = query.And(v => v.ArticleID >= filter.RangeArticleId.Gte);
                    }
                    else if (filter.RangeArticleId.Gt != null)
                    {
                        query = query.And(v => v.ArticleID > filter.RangeArticleId.Gt);
                    }

                    if (filter.RangeArticleId.Lte != null)
                    {
                        query = query.And(v => v.ArticleID <= filter.RangeArticleId.Lte);
                    }
                    else if (filter.RangeArticleId.Lt != null)
                    {
                        query = query.And(v => v.ArticleID < filter.RangeArticleId.Lt);
                    }
                }
            }


            return query;
        }

        private static Func<IQueryable<Article>, IOrderedQueryable<Article>> OrderBy()
        {
            Func<IQueryable<Article>, IOrderedQueryable<Article>> orderBy = null;

            return orderBy;
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        public PagerInfo<ArticleModel> GetArticles(ArticleFilter filter)
        {
            Expression<Func<Article, bool>> articlesFilter = Filter(filter);
            PagerInfo<ArticleModel> articleResult = null;
            var indexStartDateTime = DateTime.Now;
            Log.Debug(String.Format("getArticles.start.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));


            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;


            #region read db

            NoLockInvokeDB(() =>
{
    using (var db = new WechatMsgContext())
    {
        var timeout = ConfigManager.GetDatabaseCommandTimeout;
        if (timeout != null)
        {
            db.Database.CommandTimeout = timeout;
        }

        var articles = db.Articles;
        var articlesNums = db.Article_Num;

        var q = from article in articles.AsExpandable().Where(articlesFilter)
                join articlesNum in articlesNums on article.ArticleID equals articlesNum.ArticleID into leftTmp1
                from nums in leftTmp1.DefaultIfEmpty()

                select new
                {
                    article,
                    nums
                };

        var totalCount = q.Count();

        //TODO: 写死了排序方式
        var datas = q.OrderBy(v => v.article.ArticleID).Skip(filter.SkipCount).Take(filter.PageSize).ToList();

        articleResult = new PagerInfo<ArticleModel>(filter, totalCount)
        {
            Datas = new List<ArticleModel>(datas.Count)
        };

        foreach (var data in datas)
        {
            var d = AutoMapper.Mapper.Map<Article, ArticleModel>(data.article);
            if (data.nums != null)
            {
                d.NumUpdateTime = data.nums.UpdateTime;
                d.LikNum = data.nums.LikNum;
                d.ReadNum = data.nums.ReadNum;
            }
            d.LastIndexDateTime = indexStartDateTime;

            articleResult.Datas.Add(d);
        }
    }
});

            #endregion

            Log.Debug(String.Format("getArticles.end.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
            return articleResult;
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        public List<ArticleModel> GetListArticles(ArticleFilter filter)
        {
            var articlesFilter = Filter(filter);
            List<ArticleModel> articleResult;
            var indexStartDateTime = DateTime.Now;
            Log.Debug(String.Format("getArticles.start.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));

            #region read db

            using (var db = new WechatMsgContext())
            {
                var timeout = ConfigManager.GetDatabaseCommandTimeout;
                if (timeout != null)
                {
                    db.Database.CommandTimeout = timeout;
                }

                var articles = db.Articles;
                var articlesNums = db.Article_Num;

                var q = from article in articles.AsExpandable().Where(articlesFilter)
                        join articlesNum in articlesNums on article.ArticleID equals articlesNum.ArticleID into leftTmp1
                        from nums in leftTmp1.DefaultIfEmpty()

                        select new
                        {
                            article,
                            nums
                        };

                //var totalCount = q.Count();

                //TODO: 写死了排序方式
                var datas = q.OrderBy(v => v.article.ArticleID).Skip(filter.SkipCount).Take(filter.PageSize).ToList();

                articleResult = new List<ArticleModel>(filter.PageSize);

                foreach (var data in datas)
                {
                    var d = AutoMapper.Mapper.Map<Article, ArticleModel>(data.article);
                    if (data.nums != null)
                    {
                        d.NumUpdateTime = data.nums.UpdateTime;
                        d.LikNum = data.nums.LikNum;
                        d.ReadNum = data.nums.ReadNum;
                    }
                    d.LastIndexDateTime = indexStartDateTime;

                    articleResult.Add(d);
                }
            }

            #endregion

            Log.Debug(String.Format("getArticles.end.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
            return articleResult;
        }

        /// <summary>
        /// 获取 COLUMN
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<ArticleColumnModel> GetColumnList(ArticleColumnFilter filter)
        {
            List<ArticleColumnModel> datas;
            var msColumnsFilter = MsColumnsFilter(filter);
            Log.Debug(String.Format("GetColumnList.start.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));

            #region read db.

            using (var db = new WeiBangAccountContext())
            {
                var timeout = ConfigManager.GetDatabaseCommandTimeout;
                if (timeout != null)
                {
                    db.Database.CommandTimeout = timeout;
                }

                var msColumnArticles = db.MsColumnArticles;
                var msColumns = db.MsColumns;

                var q = from msColumnArticle in msColumnArticles.AsExpandable().Where(msColumnsFilter)
                        join msColumn in msColumns.AsExpandable() on msColumnArticle.ColumnID equals msColumn.ColumnID
                        select new ArticleColumnModel
                        {
                            ArticleId = msColumnArticle.ArticleID,
                            ColumnId = msColumnArticle.ColumnID,
                            UserId = msColumn.UserID
                        };

                datas = q.ToList();
            }

            #endregion

            Log.Debug(String.Format("GetColumnList.end.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));

            return datas;
        }

        /// <summary>
        /// get article content
        /// </summary>
        /// <param name="articleIds"></param>
        /// <param name="minId"></param>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public Dictionary<int, Article_Content> GetArticleContent(List<int> articleIds, int minId, int maxId)
        {
            var conncetStrings = Utils.GetArticleContentDbConnectionStringName(articleIds);

            Log.Debug(String.Format("GetArticleContent.start.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
            var result = new Dictionary<int, Article_Content>(articleIds.Count);
            foreach (var conncetString in conncetStrings)
            {
                using (var db = new WechatMsg_Content01Context(conncetString))
                {
                    var timeout = ConfigManager.GetDatabaseCommandTimeout;
                    if (timeout != null)
                    {
                        db.Database.CommandTimeout = timeout;
                    }

                    var articleContents = db.Article_Content;

                    var q = from content in articleContents.Where(v => v.ArticleID >= minId && v.ArticleID <= maxId)
                            select content;

                    var datas = q.ToDictionary(v => v.ArticleID, v => v);

                    //如何有相同的 KEY，那么记录一个LOG
                    //后面的KEY 覆盖前面的
                    foreach (var key in datas.Keys)
                    {
                        if (result.Keys.Contains(key))
                        {
                            Log.Fatal(String.Format("索引文章content存在相同的 articleId{0}", key));
                            //覆盖旧的
                            var d = datas[key];
                            if (!String.IsNullOrWhiteSpace(d.Content))
                            {
                                //kong 不做处理
                                result[key] = d;
                            }

                        }
                        else
                        {
                            result.Add(key, datas[key]);
                        }

                    }
                }
            }
            Log.Debug(String.Format("GetArticleContent.end.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
            return result;
        }

        /// <summary>
        /// 只跑一次，由上层决定是否循环
        /// </summary>
        /// <param name="filter"></param>
        private PagerInfo<ArticleModel> RunOnce(ArticleFilter filter)
        { //文章
            Log.Debug(String.Format("RunOnce.filter:{0}", filter));
            var articles = GetArticles(filter);
            Log.Info(String.Format("geted articles.count:{0}.totalCount:{1}", articles.Datas.Count, articles.TotalCount.ToString(CultureInfo.InvariantCulture)));
            if (articles.TotalCount == 0)
            {
                return null;
            }

            var articleIds = articles.Datas.Select(v => v.ArticleID).ToList();
            var minId = articleIds.Min(v => v);
            var maxId = articleIds.Max(v => v);

            Log.Info(String.Format("article id in {0}~{1}.", minId.ToString(CultureInfo.InvariantCulture), maxId.ToString(CultureInfo.InvariantCulture)));
            //自定义组
            var coloums = GetColumnList(new ArticleColumnFilter
            {
                RangeArticleId = new SqlRange<int?>
                {
                    Lte = maxId,
                    Gte = minId
                }
            });

            //content
            Log.Info(String.Format("get contents by min:{0}~ max:{1}", minId.ToString(CultureInfo.InvariantCulture), maxId.ToString(CultureInfo.InvariantCulture)));
            var contents = GetArticleContent(articleIds, minId, maxId);

            //save
            Log.Info(String.Format("get contents count:{0}", contents.Count.ToString(CultureInfo.InvariantCulture)));

            foreach (var article in articles.Datas)
            {
                Article_Content articleContent;
                if (contents.TryGetValue(article.ArticleID, out articleContent))
                {
                    article.Content = articleContent.Content;
                }
            }
            Log.Info(String.Format("save articles.count:{0}", articles.Datas.Count.ToString(CultureInfo.InvariantCulture)));

            _articleStorageIndex.Save(articles.Datas);
            Log.Info(String.Format("save articles.coloums.count:{0}", coloums.Count.ToString(CultureInfo.InvariantCulture)));

            _articleStorageIndex.Save(coloums);
            Log.Info("save contents ok.");

            return articles;

        }

        /// <summary>
        /// 全量RUN 直到 PAGE 跑完
        /// </summary>
        /// <param name="filter"></param>
        private ArticleFilter Run(ArticleFilter filter)
        {
            var f = filter;

            var isRun = true;
            while (isRun)
            {
                var articles = RunOnce(f);
                if (articles == null || !articles.HasNextPage)
                {
                    //执行完毕

                    isRun = false;
                }
                else
                {
                    f.PageIndex += 1;
                }
            }

            return f;
        }

        /// <summary>
        /// 只跑一次，由上层决定是否循环
        /// </summary>
        /// <param name="filter"></param>
        private List<ArticleModel> RunTaskOnce(ArticleFilter filter)
        { //文章
            Log.Debug(String.Format("RunOnce.filter:{0}", filter));
            var articles = GetListArticles(filter);
            Log.Info(String.Format("geted articles.count:{0}", articles.Count));

            var articleIds = articles.Select(v => v.ArticleID).ToList();
            var minId = articleIds.Min(v => v);
            var maxId = articleIds.Max(v => v);

            Log.Info(String.Format("article id in {0}~{1}.", minId.ToString(CultureInfo.InvariantCulture), maxId.ToString(CultureInfo.InvariantCulture)));
            //自定义组
            var coloums = GetColumnList(new ArticleColumnFilter
            {
                RangeArticleId = new SqlRange<int?>
                {
                    Lte = maxId,
                    Gte = minId
                }
            });

            //content
            Log.Info(String.Format("get contents by min:{0}~ max:{1}", minId.ToString(CultureInfo.InvariantCulture), maxId.ToString(CultureInfo.InvariantCulture)));
            var contents = GetArticleContent(articleIds, minId, maxId);

            //save
            Log.Info(String.Format("get contents count:{0}", contents.Count.ToString(CultureInfo.InvariantCulture)));

            foreach (var article in articles)
            {
                Article_Content articleContent;
                if (contents.TryGetValue(article.ArticleID, out articleContent))
                {
                    article.Content = articleContent.Content;
                }
            }
            Log.Info(String.Format("save articles.count:{0}.begin", articles.Count.ToString(CultureInfo.InvariantCulture)));

            _articleStorageIndex.Save(articles);
            Log.Info(String.Format("save articles.coloums.count:{0}", coloums.Count.ToString(CultureInfo.InvariantCulture)));

            _articleStorageIndex.Save(coloums);
            Log.Info("save ok.");

            return articles;
        }

        /// <summary>
        /// 全量
        /// </summary>
        public void FullBuild(IDictionary<string, object> args)
        {
            var pagerRequest = new ArticleFilter(0, _intervalCount);

            Run(pagerRequest);

        }

        public void IncrementBuild(IDictionary<string, object> args)
        {
            ArticleFilter filter;
            if (args == null)
            {
                //根据 ARTICID run
                filter = GetFilterByLastArticleId(null);
            }
            else
            {
                var keys = args.Keys;

                if (keys.Contains("article_id"))
                {
                    var val = args["article_id"];

                    if (val == null)
                    {
                        Log.Debug("从索引中拿最后的article_id数据.");
                        filter = GetFilterByLastArticleId(null);
                    }
                    else
                    {
                        int id;
                        if (Int32.TryParse(val.ToString(), out id))
                        {
                            Log.Info(String.Format("IncrementBuild.args.key.article_id.val({0}).", val));
                            filter = GetFilterByLastArticleId(id);
                        }
                        else
                        {
                            Log.Error(String.Format("IncrementBuild.args.key.article_id.val({0}) int parse error.", val));
                            return;
                        }
                    }
                }
                else
                {
                    Log.Info("没有指定的JOB 参数");
                    return;
                }
            }

            RunOnce(filter);
        }

        /// <summary>
        /// 任务 执行到底
        /// </summary>
        /// <param name="args"></param>
        public void TaskIncrementBuild(IDictionary<string, object> args)
        {
            ArticleFilter filter;
            int? min = null, max = null;
            if (args == null)
            {
                //根据 ARTICID run

                filter = GetFilterByLastArticleId(null);
            }
            else
            {
                var keys = args.Keys;

                if (keys.Contains("min_article_id"))
                {
                    min = Int32.Parse(args["min_article_id"].ToString());

                    if (keys.Contains("max_article_id"))
                    {
                        max = Int32.Parse(args["max_article_id"].ToString());
                    }

                    filter = GetFilterByLastArticleId(min, max);
                }
                else
                {
                    Log.Info("没有指定的JOB 参数");
                    return;
                }
            }

            var run = true;
            while (run)
            {
                var rst = RunTaskOnce(filter);
                var count = rst.Count;

                if (count == 0)
                {
                    run = false;
                }
                else
                {
                    var maxId = rst.Max(v => v.ArticleID);

                    if (maxId >= max)
                    {
                        run = false;
                    }
                    else
                    {
                        filter = GetFilterByLastArticleId(maxId, max);
                    }
                }
            }

            Log.Fatal(String.Format("{0}~{1}执行完毕", min, max));
        }

        public void TaskIncrement4UpdateArticles(IDictionary<string, object> args)
        {
            /**
             * 0.开始
             * 1.获取 最大的 DetailID 为空则为0
             * 2.获取数据库记录
             * 3.POST 数据到ES
             * 4.记录日志到LOG
             * 5.build完成后 记录JOB 开始时间点到 JOB记录中
             * 6.完成
             */

            var model = GetLastJobHistoryContextModel("job_article_num_update");

            if (model == null)
            {
                throw new NullReferenceException("model");
            }

            if (model.Context == null)
            {
                throw new NullReferenceException("model.Context");
            }

            var context = model.Context.FromJson<ArticleNumDetailJobHistory>();

            Log.Info(String.Format("select detailsId:{0}", context.DetailId.ToString(CultureInfo.InvariantCulture)));
            var details = GetArticleNumDetails(context);

            if (details == null || details.Count == 0)
            {
                Log.Info(String.Format("上下文{0}没有找到记录", model.Context.ToJson()));
                return;
            }
            Log.Info(String.Format("details.num:{0}", details.Count.ToString(CultureInfo.InvariantCulture)));
            var maxDetailId = details.Max(v => v.DetailID);
            Log.Info(String.Format("details.maxDetailId:{0}", maxDetailId.ToString(CultureInfo.InvariantCulture)));

            SaveArticleNums(details);

            context.DetailId = maxDetailId;
            model.Context = context.ToJson();
            model.UpdateDateTime = DateTime.Now;
            model.Id = "job_article_num_update";

            _articleStorageIndex.SaveJobHistoryContextModel(model);

        }

        #region  methods


        private JobHistoryContextModel GetLastJobHistoryContextModel(string id)
        {
            var model = _articleStorageIndex.GetJobHistoryContextModelItem(id);
            if (model == null)
            {
                Log.Info(String.Format("job_context is null"));
                var c = new ArticleNumDetailJobHistory
                {
                    DetailId = 0
                };

                model = new JobHistoryContextModel
                {
                    Id = id,
                    UpdateDateTime = DateTime.Now,
                    Context = c.ToJson(),
                    Description = "job_history_article_num"
                };
            }
            return model;
        }

        private List<Article_Num_Detail> GetArticleNumDetails(ArticleNumDetailJobHistory context)
        {
            if (context == null)
            {
                throw new NullReferenceException("context is null");
            }

            using (var db = new CrawlStatisticsContext())
            {
                var details = db.Article_Num_Detail.Where(v => v.DetailID > context.DetailId);

                var grs = from detail in details
                          group detail by detail.ArticleID
                              into g
                              select new
                              {
                                  g.Key,
                                  MaxDetailID = g.Max(v => v.DetailID)
                              };

                grs = grs.OrderBy(v => v.MaxDetailID).Take(_article_Num_DetailTake);

                var sql = from detail in details
                          join gr in grs on detail.DetailID equals gr.MaxDetailID
                          select detail;

                return sql.ToList();
            }
        }

        private void SaveArticleNums(List<Article_Num_Detail> details)
        {
            if (details == null)
            {
                throw new ArgumentNullException("details");
            }

            foreach (var item in details)
            {
                var parts = new Dictionary<string, object>
                {
                    {ContantFields.ReadNum, item.ReadNum.ToString(CultureInfo.InvariantCulture)},
                    {ContantFields.LikeNum, item.LikeNum.ToString(CultureInfo.InvariantCulture)}
                };

                _articleStorageIndex.UpdatePartArticle(item.ArticleID, parts);
            }
        }

        /// <summary>
        ///  获取文章范围内的查询串  
        /// </summary>
        /// <returns></returns>
        private ArticleFilter GetFilterByLastArticleId(int? min_articleId, int? max_articleId)
        {
            if (min_articleId == null && max_articleId == null)
            {
                throw new ArgumentNullException("min_articleId && max_articleId is null");
            }

            Log.Info(String.Format("take articleid in ({0},{1})", min_articleId, max_articleId));

            var filter = new ArticleFilter(0, _intervalCount);

            if (filter.ArticleIdRange == null)
            {
                filter.ArticleIdRange = new SqlRange<int?>();
            }

            filter.ArticleIdRange.Gt = min_articleId;
            filter.ArticleIdRange.Lt = max_articleId;

            return filter;
        }

        /// <summary>
        ///  获取最后文章ID的查询串  
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        private ArticleFilter GetFilterByLastArticleId(int? articleId)
        {
            var filter = new ArticleFilter(0, _intervalCount);
            int id;
            if (articleId == null)
            {
                var d = GetLastArticle();
                id = d == null ? 0 : d.ArticleID;
                Log.Info(String.Format("lastArticles{0}", id));
            }
            else
            {
                id = articleId.Value;
            }

            if (filter.ArticleIdRange == null)
            {
                filter.ArticleIdRange = new SqlRange<int?>();
            }

            filter.ArticleIdRange.Gt = id;

            return filter;
        }

        /// <summary>
        /// 获取 最后文章的ID  by remote
        /// </summary>
        /// <returns></returns>
        private ArticleModel GetLastArticle()
        {
            var query = new Query
            {
                From = 0,
                Size = 1,
                Sort = new List<Sort>
                {
                    new Sort
                    {
                        FieldName = ContantFields.ArticleId,
                        Params =  "desc"
                    }
                },
                IncludeFields = new List<string>
                {
                    ContantFields.ArticleId
                }
            };

            var paging = _articleStorageIndex.GetList(query);

            if (paging == null)
            {
                return null;
            }

            if (paging.Datas == null || paging.Datas.Count == 0)
            {
                return null;
            }

            return paging.Datas[0];
        }

        #endregion
    }
}