namespace AiWeiBang.SearchEngine.Cores
{
    /// <summary>
    /// 范围查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlRange<T> where T : new()
    {
        /// <summary>
        /// 小于等于
        /// </summary>
        public T Lte { get; set; }

        /// <summary>
        /// 小于
        /// </summary>
        public T Lt { get; set; }

        /// <summary>
        /// 大于等于
        /// </summary>
        public T Rte { get; set; }

        /// <summary>
        /// 大于
        /// </summary>
        public T Rt { get; set; }
    }
}