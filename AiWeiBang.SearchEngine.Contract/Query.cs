﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    public class Query
    {
        public Query()
        {
            Version = 1;
            ClientType = "dotnet";
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "client_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientType { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [JsonProperty(PropertyName = "q", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyWord { get; set; }

        /// <summary>
        /// 查询结构 版本
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// 完全匹配
        /// </summary>
        [JsonProperty(PropertyName = "must", NullValueHandling = NullValueHandling.Ignore)]
        public Must Must { get; set; }

        /// <summary>
        /// 完全匹配 排除项
        /// </summary>
        [JsonProperty(PropertyName = "must_not", NullValueHandling = NullValueHandling.Ignore)]
        public Must MustNot { get; set; }

        ///// <summary>
        ///// VERSION：1 版本暂时不支持
        ///// </summary>
        //[JsonProperty(PropertyName = "should", NullValueHandling = NullValueHandling.Ignore)]
        //public Should Should { get; set; }

        /// <summary>
        /// from
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public int From { get; set; }

        /// <summary>
        /// size
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        /// <summary>
        /// id desc, 按顺序
        /// </summary>
        [JsonProperty(PropertyName = "sort", NullValueHandling = NullValueHandling.Ignore)]
        public List<Sort> Sort { get; set; }

        /// <summary>
        /// 包含字段
        /// </summary>
        [JsonProperty(PropertyName = "include_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludeFields { get; set; }

        /// <summary>
        /// 排除字段
        /// </summary>
        [JsonProperty(PropertyName = "exclude_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludeFields { get; set; }
    }
}