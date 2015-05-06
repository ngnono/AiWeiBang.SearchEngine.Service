using System;
using System.Configuration;

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
    }
}