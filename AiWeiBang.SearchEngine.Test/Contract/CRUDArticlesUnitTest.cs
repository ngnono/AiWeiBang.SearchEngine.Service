using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiWeiBang.SearchEngine.ApiClient;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Cores;
using NUnit.Framework;

namespace AiWeiBang.SearchEngine.Test.Contract
{
    [TestFixture]
    public class CRUDArticlesUnitTest
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());
        private string _search;
        private string _item;

        /// <summary>
        /// 常规的初始化/清除SetUp/TearDown 属性
        /// TestFixtureSetUp/TestFixtureTearDown 用来标记为整个test fixture初始化/释放资源方法一次的方法
        /// </summary>
        [SetUp]
        public void InitializeOperands()
        {
            _search = String.Concat(ConfigManager.ArticleApiAddress, "search/");
            _item = ConfigManager.ArticleApiAddress;
        }

        private ArticleModel GetRandomArticle()
        {
            var query = new Query
            {
                ExcludeFields = new List<string>
                {
                    ContantFields.Content
                }
                ,
                Size = 5
            };

            var Article = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            return Article.Data.Datas[0];
        }

        /// <summary>
        /// GET ITEM
        /// </summary>
        [Test]
        public void GetItem()
        {
            var article = GetRandomArticle();

            var itemUrl = String.Format("{0}{1}", _item, article.ArticleID);
            var actual = RestClient.GetItem<Result<ArticleModel>>(itemUrl);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.ArticleID == article.ArticleID, "获取ITEM id不相等actual={0},Expect:{1}", actual.Data.ArticleID, article.ArticleID);
        }

        /// <summary>
        /// 全部更新
        /// </summary>
        [Test]
        public void UpdateItem()
        {
            //var article = GetRandomArticle();

            var itemUrl = String.Format("{0}{1}", _item, 585);
            var item = RestClient.GetItem<Result<ArticleModel>>(itemUrl);

            var e = 100;
            item.Data.LikNum = e;

            var actual = RestClient.Put<ArticleModel, Result<ArticleModel>>(itemUrl, item.Data);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.ArticleID == item.Data.ArticleID, "获取ITEM id不相等actual={0},Expect:{1}", actual.Data.ArticleID, item.Data.ArticleID);

            Assert.True(actual.Data.LikNum == e, "获取ITEM.likNum不相等actual={0},Expect:{1}", actual.Data.LikNum, item.Data.LikNum);



        }

        /// <summary>
        /// 部分更新
        /// </summary>
        [Test]
        public void UpdatePartItem()
        {
            //var article = GetRandomArticle();

            var itemUrl = String.Format("{0}{1}", _item, 585);
            var itemUpdatePartUrl = String.Format("{0}{1}/partial", _item, 585);
            var item = RestClient.GetItem<Result<ArticleModel>>(itemUrl);

            var e = 200;

            var parts = new Dictionary<string, object>();
            //目前只 支持 单字段更新，后续会加上多字段更新
            //更新 read_num字段
            parts.Add(ContantFields.ReadNum, e);
            var body = new
            {
                parts = parts
            };


            var actual = RestClient.Post<dynamic, Result<dynamic>>(itemUpdatePartUrl, body);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");

            Assert.True(actual.Data._id == item.Data.ArticleID, "获取ITEM id不相等actual={0},Expect:{1}", actual.Data._id, item.Data.ArticleID);


        }

        /// <summary>
        /// 部分更新
        /// </summary>
        [Test]
        public void DeleteItem()
        {
            //var article = GetRandomArticle();

            var itemUrl = String.Format("{0}{1}", _item, 585);
            var itemDeletePartUrl = String.Format("{0}{1}", _item, 585);
            var itemCreatePartUrl = _item;
            var item = RestClient.GetItem<Result<ArticleModel>>(itemUrl);


            var actual = RestClient.Delete(itemDeletePartUrl);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual, "返回状态必须为TRUE");

            //SAVE
            if (actual)
            {
                //save
                var actual2 = RestClient.Post<ArticleModel, Result<dynamic>>(itemCreatePartUrl, item.Data);

                Assert.IsNotNull(actual2, "返回值不能为空");
                Assert.IsTrue(actual2.Status, "返回状态必须为TRUE");
                Assert.IsNotNull(actual2.Data, "返回数据不能为空");
                //_id是 默认返回的文档ID 也就是 ArticleID
                Assert.True(actual2.Data._id == item.Data.ArticleID, "获取ITEM id不相等actual={0},Expect:{1}", actual2.Data._id, item.Data.ArticleID);

               
            }

        }

    }
}
