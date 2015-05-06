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
    public class CRUDArticlesColumnUnitTest
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());
        private string _item;

        /// <summary>
        /// 常规的初始化/清除SetUp/TearDown 属性
        /// TestFixtureSetUp/TestFixtureTearDown 用来标记为整个test fixture初始化/释放资源方法一次的方法
        /// </summary>
        [SetUp]
        public void InitializeOperands()
        {
            _item = ConfigManager.ArticleColumnApiAddress;
        }

        private ArticleColumnModel GetRandomArticleColumn()
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

            var Article = RestClient.GetItem<Result<ArticleColumnModel>>(_item + "45352_10005");

            return Article.Data;
        }

        /// <summary>
        /// GET ITEM
        /// </summary>
        [Test]
        public void GetItem()
        {
            var articleColumn = GetRandomArticleColumn();

            var itemUrl = String.Format("{0}{1}", _item, articleColumn.Id);
            var actual = RestClient.GetItem<Result<ArticleColumnModel>>(itemUrl);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.Id == articleColumn.Id, "获取ITEM id不相等actual={0},Expect:{1}", actual.Data.Id, articleColumn.Id);
        }

        /// <summary>
        /// 部分更新
        /// </summary>
        [Test]
        public void DeleteItem()
        {
            //var article = GetRandomArticle();
            var articleColumn = GetRandomArticleColumn();
            var itemUrl = String.Format("{0}{1}", _item, articleColumn.Id);
            var itemDeletePartUrl = String.Format("{0}{1}", _item, articleColumn.Id);
            var itemCreatePartUrl = _item;
            var item = RestClient.GetItem<Result<ArticleColumnModel>>(itemUrl);


            var actual = RestClient.Delete(itemDeletePartUrl);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual, "返回状态必须为TRUE");

            //SAVE
            if (actual)
            {
                //save
                var actual2 = RestClient.Post<ArticleColumnModel, Result<dynamic>>(itemCreatePartUrl, item.Data);

                Assert.IsNotNull(actual2, "返回值不能为空");
                Assert.IsTrue(actual2.Status, "返回状态必须为TRUE");
                Assert.IsNotNull(actual2.Data, "返回数据不能为空");
                //_id是 默认返回的文档ID 也就是 ArticleID
                Assert.True(actual2.Data._id == item.Data.Id, "获取ITEM id不相等actual={0},Expect:{1}", actual2.Data._id, item.Data.Id);
            }

        }

    }
}
