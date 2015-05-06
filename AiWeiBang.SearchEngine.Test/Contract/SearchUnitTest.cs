using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using AiWeiBang.SearchEngine.ApiClient;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Cores;
using NUnit.Framework;

namespace AiWeiBang.SearchEngine.Test.Contract
{
    [TestFixture]
    public class SearchUnitTest
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
            _search = String.Concat(ConfigManager.ArticleApiAddress, "search/");
        }

        /// <summary>
        /// 只返回某一个字段的测试
        /// </summary>
        [Test]
        public void SearchFieldsTest()
        {
            var query = new Query
            {
                IncludeFields = new List<string>
                {
                    ContantFields.ArticleId,
                    ContantFields.RecordTime
                }
                ,
                Size = 5
            };

            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

            foreach (var d in actual.Data.Datas)
            {
                if (d.ArticleID <= 0)
                {
                    Assert.True(false, String.Format("ArticleID is {0}", d.ArticleID));
                }

                Assert.IsNullOrEmpty(d.ArticleTitle, String.Format("ArticleTitle is {0}", d.ArticleTitle));
                Assert.IsNullOrEmpty(d.Content, String.Format("Content is {0}", d.Content));
                Assert.IsNullOrEmpty(d.Summary, String.Format("Summary is {0}", d.Content));
            }

        }

        /// <summary>
        /// 排除某一个字段的测试
        /// </summary>
        [Test]
        public void SearchFieldsExTest()
        {
            _search = String.Concat(ConfigManager.ArticleApiAddress, "search/");
            var query = new Query
            {
                ExcludeFields = new List<string>
                {
                    ContantFields.Content
                }
                ,
                Size = 5
            };

            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

            foreach (var d in actual.Data.Datas)
            {
                if (d.ArticleID <= 0)
                {
                    Assert.True(false, String.Format("ArticleID is {0}", d.ArticleID));
                }
                Assert.IsNotNullOrEmpty(d.Summary, String.Format("Summary is {0}", d.Content));
                Assert.IsNotNullOrEmpty(d.ArticleTitle, String.Format("ArticleTitle is {0}", d.ArticleTitle));
                Assert.IsNullOrEmpty(d.Content, String.Format("Content is {0}", d.Content));

            }

        }

        /// <summary>
        /// 只返回某一个字段的测试
        /// </summary>
        [Test]
        public void SearchByPostUserIdTest([Values(10, 214)]int postUserId)
        {
            var query = new Query
            {
                Must = new Must
                {
                    Terms = new Dictionary<string, object>(),
                    Range = new Dictionary<string, Range<object>>()
                },
                ExcludeFields = new List<string>
                {
                    ContantFields.Content
                }
                ,
                Size = 5
            };

            query.Must.Terms.Add(ContantFields.PostUserId, postUserId.ToString(CultureInfo.InvariantCulture));
            //query.Must.Terms.Add(ContantFields.ArticleId, postUserId.ToString(CultureInfo.InvariantCulture));

            query.Must.Range.Add("post_date", new Range<object>()
            {
                Lt = DateTime.Now.ToString("yyyy-MM-dd"),
                Gte = DateTime.Now.AddYears(-4).ToString("yyyy-MM-dd")
            });


            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

            foreach (var d in actual.Data.Datas)
            {
                if (d.PostUserID != postUserId)
                {
                    Assert.True(false, String.Format("ArticleID is {0}", d.ArticleID));
                }
            }

        }

        /// <summary>
        /// 用户自定义组ID 查询
        /// </summary>
        /// <param name="columnId"></param>
        [Test]
        public void SearchColumnTest([Values(10005)]int columnId)
        {
            var query = new Query
            {
                Must = new Must
                {
                    Terms = new Dictionary<string, object>(),
                    Range = new Dictionary<string, Range<object>>()
                },
                ExcludeFields = new List<string>
                {
                    ContantFields.Content
                }
                ,
                Size = 10
            };

            query.Must.Terms.Add(ContantFields.ColumnId, columnId.ToString(CultureInfo.InvariantCulture));
            //query.Must.Terms.Add(ContantFields.ArticleId, postUserId.ToString(CultureInfo.InvariantCulture));

            query.Must.Range.Add("post_date", new Range<object>()
            {
                Lt = DateTime.Now.ToString("yyyy-MM-dd"),
                Gte = DateTime.Now.AddYears(-4).ToString("yyyy-MM-dd")
            });

            //文章ID 已知
            var ex = new List<int>()
            {
                45352,
                45388,
                45390,
                45395,
                45389,
                45391,
                45396,
                45385,
                45392,
                45397
            };


            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

            foreach (var d in actual.Data.Datas)
            {
                if (!ex.Contains(d.ArticleID))
                {
                    Assert.True(false, String.Format("ArticleID is {0}", d.ArticleID));
                }
            }
        }

        /// <summary>
        /// 用户自定义 排序查询
        /// </summary>
        [Test]
        public void SearchSortTest()
        {
            var query = new Query
            {
                Size = 10,
                Sort = new List<Sort>()
            };

            //会按照 这个的顺序 排序
            // order by recordTime asc posttime desc postdate asc
            //default asc
            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.RecordTime
            });

            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.PostTime,
                Params = SortType.Desc
            });

            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.PostDate,
                Params = SortType.Asc
            });


            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");
        }

        /// <summary>
        /// 用户自定义 排序查询
        /// </summary>
        [Test]
        public void SearchSortDescTest()
        {
            var query = new Query
            {
                Size = 10,
                Sort = new List<Sort>()
            };

            //会按照 这个的顺序 排序
            // order by recordTime asc posttime desc postdate asc
            //default asc
            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.RecordTime,
                Params = SortType.Desc
            });

            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.PostTime,
                Params = SortType.Asc
            });

            query.Sort.Add(new Sort()
            {
                FieldName = ContantFields.PostDate,
                Params = SortType.Asc
            });


            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");
        }

        /// <summary>
        /// 根据日期间隔，SIZE,USERID查询
        /// </summary>
        [Test]
        public void Search4PostDate([Values(30, 60, 90, 120, 1, 2, 3, 4, 5, 6, 7)]int day, [Values(100)]int size, [Range(1, 20, 1)]int page, [Values(null, 20)]int? postUserId)
        {
            //起始位置
            var from = (page - 1) * size;
            var query = new Query
            {
                From = from,
                Size = size,
                Sort = new List<Sort>()
            };

            /*
             * -----------------------------------------------------------------------
             *会按照 这个的顺序 排序
             *类似于SQL order by  postdate desc,posttime desc
             *default asc
            */
            query.Sort.Add(new Sort
            {
                FieldName = ContantFields.PostDate,
                Params = SortType.Desc
            });

            query.Sort.Add(new Sort
            {
                FieldName = ContantFields.PostTime,
                Params = SortType.Desc
            });

            /*------------------QUERY--------------------------------
             * 相当于 条件查询 必须的
             * 类似于 SQL    where postUserId = postuserId.value
             * ----------------------------------------------------
             */
            query.Must = new Must();

            query.Must.Terms = new Dictionary<string, object>();

            //类似于 SQL    where postUserId = postuserId.value
            if (postUserId != null)
            {
                query.Must.Terms.Add(ContantFields.PostUserId, postUserId.Value.ToString(CultureInfo.InvariantCulture));
            }

            /** ×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
             * 日期范围查询
             * 日期范围查询 注意 格式化问题  
             * 日期 yyyy-MM-dd
             * 日期时间 yyyy-MM-ddTHH:mm:ssZ
             * ××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
             */

            //改成2014年了
            var endate = DateTime.Now.AddYears(-1);
            var startDate = endate.AddDays(0 - day);

            query.Must.Range = new Dictionary<string, Range<object>>();
            query.Must.Range.Add(ContantFields.PostDate, new Range<object>()
                {
                    //大于等于  GT 是大于   ，
                    Gte = startDate.ToString("yyyy-MM-dd"),
                    //小于
                    Lt = endate.ToString("yyyy-MM-ddTHH:mm")
                });



            //不返回 content字段
            //×××××××××××××××××××××××××××××××××××××××××××××××××
            //记得加入这个排除 会增加性能
            //需要content 时 再加入
            //××××××××××××××××××××××××××××××××××××××××××××××××××
            query.ExcludeFields = new List<string>
                {
                    ContantFields.Content
                };



            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

        }


        /// <summary>
        /// 根据日期间隔，SIZE,USERID查询
        /// </summary>
        [Test]
        public void Search4Keyword([Values("英雄", "土豪", null)]string keyWord, [Values(null, 10)]int? coloumId, [Values(100)]int size, [Range(1, 20, 1)]int page, [Values(null, 20)]int? postUserId)
        {
            //起始位置
            var from = (page - 1) * size;
            var query = new Query
            {
                From = from,
                Size = size,
                Sort = new List<Sort>()
            };

            /*
             * -----------------------------------------------------------------------
             *会按照 这个的顺序 排序
             *类似于SQL order by  postdate desc,posttime desc
             *default asc
            */
            query.Sort.Add(new Sort
            {
                FieldName = ContantFields.PostDate,
                Params = SortType.Desc
            });

            query.Sort.Add(new Sort
            {
                FieldName = ContantFields.PostTime,
                Params = SortType.Desc
            });

            /*------------------QUERY--------------------------------
             * 相当于 条件查询 必须的
             * 类似于 SQL    where postUserId = postuserId.value
             * ----------------------------------------------------
             */

            /*************************
             *关键字查询
             ************************
             */
            if (!String.IsNullOrWhiteSpace(keyWord))
            {
                query.KeyWord = keyWord;
            }

            query.Must = new Must();

            query.Must.Terms = new Dictionary<string, object>();

            /********************
             *  POST USER ID
             * 类似于 SQL    where postUserId = postuserId.value
             */

            if (postUserId != null)
            {
                query.Must.Terms.Add(ContantFields.PostUserId, postUserId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (coloumId != null)
            {
                query.Must.Terms.Add(ContantFields.ColumnId, coloumId.Value.ToString(CultureInfo.InvariantCulture));
            }

            /***************************
             * 
             * 排除字段
             * 
             **************************** 
             */

            //不返回 content字段
            //×××××××××××××××××××××××××××××××××××××××××××××××××
            //记得加入这个排除 会增加性能
            //需要content 时 再加入
            //××××××××××××××××××××××××××××××××××××××××××××××××××
            query.ExcludeFields = new List<string>
                {
                    ContantFields.Content
                };

            var actual = RestClient.Post<Query, Result<PagerInfo<ArticleModel>>>(_search, query);

            Assert.IsNotNull(actual, "返回值不能为空");
            Assert.IsTrue(actual.Status, "返回状态必须为TRUE");
            Assert.IsNotNull(actual.Data, "返回数据不能为空");
            Assert.True(actual.Data.TotalCount >= 0, "返回数据大于零");
            Assert.IsNotNull(actual.Data.Datas, "返回数据.datas不能为空");

        }
    }
}
