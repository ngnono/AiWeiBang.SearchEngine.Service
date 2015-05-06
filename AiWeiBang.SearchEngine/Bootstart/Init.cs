using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Contract.Models;
using AiWeiBang.SearchEngine.Data.Models;
using AiWeiBang.SearchEngine.Dtos;
using AutoMapper;

namespace AiWeiBang.SearchEngine.Bootstart
{
    public class Init
    {
        public static void Start()
        {
            AutoMapperConfig.Init();
        }
    }

    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.CreateMap<Article, ArticleModel>();
            Mapper.CreateMap<Article_Content, ArticleContentDto>();
        }
    }
}
