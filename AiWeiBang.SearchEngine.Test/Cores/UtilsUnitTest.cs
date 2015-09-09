using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace AiWeiBang.SearchEngine.Test.Cores
{
    [TestFixture]
    public class UtilsUnitTest
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());
        //


        [Test]
        public void TestMethod1([Range(99, 100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content01Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod2([Range(1, 100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content01Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod3([Range(201, 300, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content03Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod4([Range(1201, 1300, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content13Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod5([Range(2010, 2020, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content21Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod3001([Range(3001, 3100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content22Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod3000([Values(3000)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content21Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }


        [Test]
        public void TestMethod4001([Range(4001, 4100, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content23Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod4950([Range(4950, 5000, 1)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content23Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod4000([Values(4000)]int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content22Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void Tt()
        {
            var articleIds = new List<int>()
            {
                1039747
            };
            var actual = Utils.GetArticleContentDbConnectionStringName(articleIds).FirstOrDefault();

            var expected = "WechatMsg_Content02Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }
    }


    /// <summary>
    ///  1000 W 一个库
    /// </summary>
    [TestFixture]
    public class UtilsUnitTestV2
    {
        //readonly ArticleIndex _articleIndex = new ArticleIndex(new ArticleStorageIndex());
        //

        [Test]
        public void TestMethod1([Range(1, 100, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content01Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }


        [Test]
        public void TestMethod2([Range(101, 200, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content02Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }


        [Test]
        public void TestMethod3([Range(201, 300, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content03Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }


        [Test]
        public void TestMethod4([Range(301, 400, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content04Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod5([Range(401, 500, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content05Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod6([Range(501, 600, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content06Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod10([Range(901, 1000, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content10Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }

        [Test]
        public void TestMethod11([Range(1001, 1100, 1)] int id)
        {
            var actual = Utils.GetArticleContentDbConnectionStringName(new List<int>() { id }, 100).FirstOrDefault();
            const string expected = "WechatMsg_Content11Context";
            Assert.AreEqual(actual, expected, String.Format("actual:{0},equal expected:{1}", actual, expected));
        }
    }
}
