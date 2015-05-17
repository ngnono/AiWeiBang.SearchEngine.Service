using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiWeiBang.SearchEngine.Cores;
using AiWeiBang.SearchEngine.Cores.Articles;
using NUnit.Framework;

namespace AiWeiBang.SearchEngine.Test.Contract
{
    public class ArticleNumTest
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());
        private string _search;

        /// <summary>
        /// 常规的初始化/清除SetUp/TearDown 属性
        /// TestFixtureSetUp/TestFixtureTearDown 用来标记为整个test fixture初始化/释放资源方法一次的方法
        /// </summary>
        [SetUp]
        public void InitializeOperands()
        {
            _search = ConfigManager.GetArticleJobHistoryContextApiAddress;
        }

        [Test]
        public void GetTest()
        {
            IArticleStorageIndex asi = new ArticleStorageIndex();


            var dtm = asi.GetJobHistoryContextModelItem("job_article_num_update");

            Console.WriteLine(dtm);
            Assert.NotNull(dtm);
        }

    }
}
