using System;
using AiWeiBang.SearchEngine.Cores.Articles;
using System.Collections.Generic;
using System.Configuration;

namespace AiWeiBang.SearchEngine.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //log4net configs
            log4net.Config.XmlConfigurator.Configure();
            AiWeiBang.SearchEngine.Jobs.Cores.Bootstart.Boot.Init();

            var t = new ArticleIndex(new ArticleStorageIndex());

            var p = new Dictionary<string, object>
                {
                    {"min_article_id", ConfigurationManager.AppSettings["min_article_id"]},
                    {"max_article_id", ConfigurationManager.AppSettings["max_article_id"]}
                };

            System.Console.WriteLine("run....");
            try
            {
                t.TaskIncrementBuild(p);
                System.Console.WriteLine("run ok....");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            System.Console.ReadLine();
        }
    }
}
