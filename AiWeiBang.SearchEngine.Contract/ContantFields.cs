namespace AiWeiBang.SearchEngine.Contract
{
    public class ContantFields
    {
        /// <summary>
        /// 文档ID
        /// </summary>
        public const string ArticleId = "article_id";

        /// <summary>
        /// 文档 内容
        /// </summary>
        public const string Content = "content";

        /// <summary>
        /// 
        /// </summary>
        public const string PostUserId = "post_user_id";

        /// <summary>
        /// 
        /// </summary>
        public const string PostTime = "post_time";


        public const string PostDate = "post_date";

        public const string Enabled = "enabled";

        public const string ReadNum = "read_num";

        public const string LikeNum = "like_num";


        /// <summary>
        /// 用户 自定义 组ID
        /// </summary>
        public const string ColumnId = "column_id";

        /// <summary>
        /// 记录时间record_time
        /// </summary>
        public const string RecordTime = "record_time";

        public const string SortOrder = "order";

        public const string SortOrderAsc = "asc";

        public const string SortOrderDesc = "desc";
    }

    public struct SortType
    {
        public const string Desc = "desc";

        public const string Asc = "asc";
    }
}