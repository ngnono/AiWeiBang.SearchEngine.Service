using System.Collections.Generic;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Dtos;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public interface IArticleStorageIndex
    {
        void Save(List<ArticleModel> articleDtos);

        void Save(List<ArticleColumnModel> articleColumnDtos);

        PagerInfo<ArticleModel> GetList(Query query);

        JobHistoryContextModel GetJobHistoryContextModelItem(string id);

        JobHistoryContextModel SaveJobHistoryContextModel(JobHistoryContextModel model);

        bool UpdatePartArticle(int id, Dictionary<string, object> fieldValues);
    }
}