﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Data.Models;
using AiWeiBang.SearchEngine.Dtos;
using LinqKit;
using log4net;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public class ArticleIndex : IArticleIndex
    {
        private readonly int _intervalCount = ConfigManager.GetDefaultArticleSelectSize;
        private readonly IArticleStorageIndex _articleStorageIndex;
        private readonly static ILog Log = LogManager.GetLogger(typeof(ArticleIndex));

        public ArticleIndex(IArticleStorageIndex storageIndex)
        {
            //_intervalCount = intervalCount;
            _articleStorageIndex = storageIndex;
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
                    if (filter.PostDateRange.Rte != null)
                    {
                        query = query.And(v => v.PostDate >= filter.PostDateRange.Rte);
                    }
                    else if (filter.PostDateRange.Rt != null)
                    {
                        query = query.And(v => v.PostDate > filter.PostDateRange.Rt);
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
                    if (filter.RecordDateRange.Rte != null)
                    {
                        query = query.And(v => v.RecordTime >= filter.RecordDateRange.Rte);
                    }
                    else if (filter.RecordDateRange.Rt != null)
                    {
                        query = query.And(v => v.RecordTime > filter.RecordDateRange.Rt);
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
                    if (filter.ArticleIdRange.Rte != null)
                    {
                        query = query.And(v => v.ArticleID >= filter.ArticleIdRange.Rte);
                    }
                    else if (filter.ArticleIdRange.Rt != null)
                    {
                        query = query.And(v => v.ArticleID > filter.ArticleIdRange.Rt);
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
                    if (filter.RangeArticleId.Rte != null)
                    {
                        query = query.And(v => v.ArticleID >= filter.RangeArticleId.Rte);
                    }
                    else if (filter.RangeArticleId.Rt != null)
                    {
                        query = query.And(v => v.ArticleID > filter.RangeArticleId.Rt);
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
            PagerInfo<ArticleModel> articleResult;
            var indexStartDateTime = DateTime.Now;
            Log.Debug(String.Format("getArticles.start.dt{0}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));

            #region read db

            using (var db = new WechatMsgContext())
            {
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
                    var articleContents = db.Article_Content;

                    var q = from content in articleContents.Where(v => v.ArticleID >= minId && v.ArticleID <= maxId)
                            select content;

                    var datas = q.ToDictionary(v => v.ArticleID, v => v);

                    foreach (var key in datas.Keys)
                    {
                        result.Add(key, datas[key]);
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
                    Rte = minId
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

                if (articles.HasNextPage)
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
        /// 全量
        /// </summary>
        public void FullBuild()
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
            }
            else
            {
                id = articleId.Value;
            }

            if (filter.ArticleIdRange == null)
            {
                filter.ArticleIdRange = new SqlRange<int?>();
            }

            filter.ArticleIdRange.Rt = id;

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
    }
}