using System;
using System.Configuration;
using System.Linq;

namespace AiWeiBang.SearchEngine.Cores
{
    public class ConfigManager
    {
        public static string ApiDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["searchEngine.domain"];
            }
        }

        public static string ArticleApiAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["searchEngine.domain.articles"];
            }
        }

        public static string ArticleColumnApiAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["searchEngine.domain.articleColumns"];
            }
        }

        public static int GetDefaultArticleSelectSize
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["db.article.select.size"]);
            }
        }

        public static string GetArticleJobHistoryContextApiAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["searchEngine.domain.articleJobHistories"];
            }
        }

        public static int GetDefaultArticleNumDetailsSize
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["db.articleNumDetails.select.size"]);
            }
        }

        public static int? GetDatabaseCommandTimeout
        {
            get
            {
                if (ConfigurationManager.AppSettings.AllKeys.Contains("db.command.timeout"))
                {
                    return Int32.Parse(ConfigurationManager.AppSettings["db.command.timeout"]);
                }

                return null;
            }
        }
    }
}