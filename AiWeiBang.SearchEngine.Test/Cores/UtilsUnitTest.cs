using NUnit.Framework;
using System;

namespace AiWeiBang.SearchEngine.Test.Cores
{
    [TestFixture]
    public class UtilsUnitTest
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());

        [Test]
        public void TestMethod1([Range(99, 100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbTable(id, 100);
            const string expected = "[WechatMsg_Content01].[dbo].[Article_Content]";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod2([Range(1, 100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbTable(id, 100);
            const string expected = "[WechatMsg_Content01].[dbo].[Article_Content]";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod3([Range(201, 300, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbTable(id, 100);
            const string expected = "[WechatMsg_Content03].[dbo].[Article_Content]";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod4([Range(1201, 1300, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbTable(id, 100);
            const string expected = "[WechatMsg_Content13].[dbo].[Article_Content]";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod5([Range(2010, 2020, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbTable(id, 100);
            const string expected = "[WechatMsg_Content21].[dbo].[Article_Content]";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }
    }
}
