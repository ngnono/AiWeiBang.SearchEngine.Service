using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AiWeiBang.SearchEngine.Data.Models.Mapping;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WeiBangAccountContext : DbContext
    {
        static WeiBangAccountContext()
        {
            Database.SetInitializer<WeiBangAccountContext>(null);
        }

        public WeiBangAccountContext()
            : base("Name=WeiBangAccountContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountFansStatu> AccountFansStatus { get; set; }
        public DbSet<AccountFeed> AccountFeeds { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }
        public DbSet<AccountScene> AccountScenes { get; set; }
        public DbSet<AccountUserSetting> AccountUserSettings { get; set; }
        public DbSet<AccountValidateCode> AccountValidateCodes { get; set; }
        public DbSet<CredentialMail> CredentialMails { get; set; }
        public DbSet<CredentialWeibo> CredentialWeiboes { get; set; }
        public DbSet<DevKeyword> DevKeywords { get; set; }
        public DbSet<DevMenu> DevMenus { get; set; }
        public DbSet<DevReceiveLog> DevReceiveLogs { get; set; }
        public DbSet<DevSetting> DevSettings { get; set; }
        public DbSet<DevToken> DevTokens { get; set; }
        public DbSet<FavArticle> FavArticles { get; set; }
        public DbSet<Log_AccountOperate> Log_AccountOperate { get; set; }
        public DbSet<Log_Upload> Log_Upload { get; set; }
        public DbSet<MsChannel> MsChannels { get; set; }
        public DbSet<MsColumn> MsColumns { get; set; }
        public DbSet<MsColumnArticle> MsColumnArticles { get; set; }
        public DbSet<MsSetting> MsSettings { get; set; }
        public DbSet<RecommendList> RecommendLists { get; set; }
        public DbSet<RecommendList_Index> RecommendList_Index { get; set; }
        public DbSet<RecommendListClass> RecommendListClasses { get; set; }
        public DbSet<RecommendListDetail> RecommendListDetails { get; set; }
        public DbSet<RecommendListSery> RecommendListSeries { get; set; }
        public DbSet<SubscribeUser> SubscribeUsers { get; set; }
        public DbSet<todelete_AccountCommit> todelete_AccountCommit { get; set; }
        public DbSet<Union> Unions { get; set; }
        public DbSet<WebApp_Elements> WebApp_Elements { get; set; }
        public DbSet<WebApp_Slides> WebApp_Slides { get; set; }
        public DbSet<WebApp_Tags> WebApp_Tags { get; set; }
        public DbSet<WebAppSetting> WebAppSettings { get; set; }
        public DbSet<WxUserBind> WxUserBinds { get; set; }
        public DbSet<WxUserExt> WxUserExts { get; set; }
        public DbSet<WxUserManage> WxUserManages { get; set; }
        public DbSet<WxUserRecommend> WxUserRecommends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new AccountFansStatuMap());
            modelBuilder.Configurations.Add(new AccountFeedMap());
            modelBuilder.Configurations.Add(new AccountManagerMap());
            modelBuilder.Configurations.Add(new AccountSceneMap());
            modelBuilder.Configurations.Add(new AccountUserSettingMap());
            modelBuilder.Configurations.Add(new AccountValidateCodeMap());
            modelBuilder.Configurations.Add(new CredentialMailMap());
            modelBuilder.Configurations.Add(new CredentialWeiboMap());
            modelBuilder.Configurations.Add(new DevKeywordMap());
            modelBuilder.Configurations.Add(new DevMenuMap());
            modelBuilder.Configurations.Add(new DevReceiveLogMap());
            modelBuilder.Configurations.Add(new DevSettingMap());
            modelBuilder.Configurations.Add(new DevTokenMap());
            modelBuilder.Configurations.Add(new FavArticleMap());
            modelBuilder.Configurations.Add(new Log_AccountOperateMap());
            modelBuilder.Configurations.Add(new Log_UploadMap());
            modelBuilder.Configurations.Add(new MsChannelMap());
            modelBuilder.Configurations.Add(new MsColumnMap());
            modelBuilder.Configurations.Add(new MsColumnArticleMap());
            modelBuilder.Configurations.Add(new MsSettingMap());
            modelBuilder.Configurations.Add(new RecommendListMap());
            modelBuilder.Configurations.Add(new RecommendList_IndexMap());
            modelBuilder.Configurations.Add(new RecommendListClassMap());
            modelBuilder.Configurations.Add(new RecommendListDetailMap());
            modelBuilder.Configurations.Add(new RecommendListSeryMap());
            modelBuilder.Configurations.Add(new SubscribeUserMap());
            modelBuilder.Configurations.Add(new todelete_AccountCommitMap());
            modelBuilder.Configurations.Add(new UnionMap());
            modelBuilder.Configurations.Add(new WebApp_ElementsMap());
            modelBuilder.Configurations.Add(new WebApp_SlidesMap());
            modelBuilder.Configurations.Add(new WebApp_TagsMap());
            modelBuilder.Configurations.Add(new WebAppSettingMap());
            modelBuilder.Configurations.Add(new WxUserBindMap());
            modelBuilder.Configurations.Add(new WxUserExtMap());
            modelBuilder.Configurations.Add(new WxUserManageMap());
            modelBuilder.Configurations.Add(new WxUserRecommendMap());
        }
    }
}
