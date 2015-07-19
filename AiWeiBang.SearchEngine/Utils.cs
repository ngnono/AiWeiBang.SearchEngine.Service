using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AiWeiBang.SearchEngine
{
    public static class Utils
    {
        ///// <summary>
        ///// articleId 每100W了一个库 100W时会在UP库中
        ///// articlesId 小于2000W 时 CONTTENT
        ///// 
        ///// </summary>
        ///// <param name="articleId"></param>
        ///// <param name="interval"></param>
        ///// <returns></returns>
        //public static string GetArticleContentDbTable(int articleId, double interval = 1000000.0)
        //{
        //    if (articleId < 1)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        //处理 当正好=interval
        //        articleId = articleId - 1;
        //    }

        //    var d = Convert.ToInt32(Math.Floor((articleId / interval) + 1.0));
        //    if (d < 10)
        //    {
        //        return String.Format("[WechatMsg_Content0{0}].[dbo].[Article_Content]",
        //            d.ToString(CultureInfo.InvariantCulture));
        //    }

        //    return String.Format("[WechatMsg_Content{0}].[dbo].[Article_Content]",
        //        d.ToString(CultureInfo.InvariantCulture));
        //}

        /// <summary>
        ///  返回数据库连接串NAME articleId 每100W了一个库 100W时会在UP库中
        ///  3000W
        ///  2000W 问题
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="interval"></param>
        /// <returns>WechatMsg_Content01Context</returns>
        private static string GetArticleContentDbConnectionStringName(int articleId, double interval = 1000000.0)
        {
            if (articleId < 1)
            {
                return "";
            }
            else
            {
                //处理 当正好=interval
                articleId = articleId - 1;
            }

            var d = Convert.ToInt32(Math.Floor((articleId / interval) + 1.0));

            if (d < 10)
            {
                return GetContentString(d);
            }
            if (d > 21 && d <= 30)
            {
                d = 21;

                return GetContentString(d);
            }

            //大于3000W时要使用22库
            if (d >= 30&& d<=40)
            {
                d = 22;

                return GetContentString(d);
            }

            if (d >= 40)
            {
                d = 23;

                return GetContentString(d);
            }

            return GetContentString(d); 
        }

        /// <summary>
        /// 获取 EF 连接串
        /// </summary>
        /// <param name="contentNum"></param>
        /// <returns></returns>
        private static string GetContentString(int contentNum)
        {
            if (contentNum < 10)
            {
                return String.Format("WechatMsg_Content0{0}Context", contentNum.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                return String.Format("WechatMsg_Content{0}Context", contentNum.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        ///  返回数据库连接串NAME articleId 每100W了一个库 100W时会在UP库中
        /// </summary>
        /// <param name="articleIds"></param>
        /// <param name="interval"></param>
        /// <returns>WechatMsg_Content01Context</returns>
        public static IEnumerable<string> GetArticleContentDbConnectionStringName(List<int> articleIds,
            double interval = 1000000.0)
        {
            if (articleIds == null || articleIds.Count == 0)
            {
                return new List<string>(0);
            }

            var result = new HashSet<string>();

            foreach (var articleId in articleIds)
            {
                var t = GetArticleContentDbConnectionStringName(articleId, interval);
                result.Add(t);
            }

            return result.ToList();
        }
    }
}
