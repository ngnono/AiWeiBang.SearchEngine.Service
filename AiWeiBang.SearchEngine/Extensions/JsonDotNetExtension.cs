namespace AiWeiBang.SearchEngine.Extensions
{
    public static class JsonDotNetExtension
    {
        /// <summary>
        ///  using json.net
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string s)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s);

            if (obj == null)
            {
                return default(T);
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// using json.net
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
    }
}