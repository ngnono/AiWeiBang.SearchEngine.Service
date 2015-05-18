using System;
using System.Collections.Generic;
using System.Globalization;
using AiWeiBang.SearchEngine.ApiClient;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Dtos;
using AiWeiBang.SearchEngine.Extensions;
using log4net;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public class ArticleStorageIndex : IArticleStorageIndex
    {
        private readonly string _articleIndex = ConfigManager.ArticleApiAddress;
        //private readonly string _articleColumnIndex = ConfigManager.ArticleColumnApiAddress;
        private readonly string _articleColumnIndexBulk = String.Format("{0}bulk", ConfigManager.ArticleColumnApiAddress);
        private readonly string _articleJobContextIndex = ConfigManager.GetArticleJobHistoryContextApiAddress;

        private readonly string _search;

        private readonly static ILog Log = LogManager.GetLogger(typeof(ArticleStorageIndex));

        public ArticleStorageIndex()
        {
            _search = String.Concat(ConfigManager.ArticleApiAddress, "search/");
        }

        public void Save(List<ArticleModel> articleDtos)
        {
            if (articleDtos == null || articleDtos.Count == 0)
            {
                Log.Debug("Save.articleDtos no data.....");
                return;
            }

            Log.Debug(String.Format("save(articleDtos:{0})", articleDtos.ToJson()));
            var rst = RestClient.Post<List<ArticleModel>, Result<CreatedListResult>>(_articleIndex, articleDtos);
            Log.Debug(String.Format("save(articleDtos.rst:{0})", rst.ToJson()));
        }

        public void Save(List<ArticleColumnModel> articleColumnDtos)
        {
            if (articleColumnDtos == null || articleColumnDtos.Count == 0)
            {
                Log.Debug("Save.articleColumnDtos no data.....");
                return;
            }

            Log.Debug(String.Format("save(articleColumnDtos:{0})", articleColumnDtos.ToJson()));
            var rst = RestClient.Post<List<ArticleColumnModel>, object>(_articleColumnIndexBulk, articleColumnDtos);
            Log.Debug(String.Format("save(articleColumnDtos.rst:{0})", rst.ToJson()));
        }

        public PagerInfo<ArticleModel> GetList(Query query)
        {
            if (query == null)
            {
                Log.Debug("GetList.query no data.....");
                return null;
            }

            Log.Debug(String.Format("GetList(query:{0})", query.ToJson()));
            var rst = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Log.Debug(String.Format("GetList(query.rst:{0})", (rst == null ? "null" : rst.ToJson())));
            if (rst != null && rst.Status)
            {
                return rst.Data;
            }

            return null;
        }

        public JobHistoryContextModel GetJobHistoryContextModelItem(string id)
        {
            var itemUrl = String.Format("{0}{1}", _articleJobContextIndex, id);
            var actual = RestClient.GetItem<Result<JobHistoryContextModel>>(itemUrl);

            if (actual != null && actual.Status)
            {
                return actual.Data;
            }
            else
            {
                return null;
            }
        }

        public JobHistoryContextModel SaveJobHistoryContextModel(JobHistoryContextModel model)
        {
            //var itemUrl = String.Format("{0}{1}", _articleJobContextIndex);

            var actual = RestClient.Post<JobHistoryContextModel, Result<JobHistoryContextModel>>(_articleJobContextIndex, model);

            //create
            if (actual != null && actual.Status && actual.StatusCode == 201)
            {
                return actual.Data;
            }
            else
            {
                Log.Error(actual);
                return null;
            }
        }


        public bool UpdatePartArticle(int id, Dictionary<string, object> fieldValues)
        {
            var itemUpdatePartUrl = String.Format("{0}{1}/partial", _articleIndex, id);

            var body = new
            {
                parts = fieldValues
            };

            Log.Debug(String.Format("articleId:{0},parts:{1}", id.ToString(CultureInfo.InvariantCulture), fieldValues.ToJson()));
            var actual = RestClient.Post<dynamic, Result<dynamic>>(itemUpdatePartUrl, body);

            if (actual == null)
            {
                return false;
            }

            Log.Debug(actual.ToJson());

            return actual.Status;
        }
    }
}