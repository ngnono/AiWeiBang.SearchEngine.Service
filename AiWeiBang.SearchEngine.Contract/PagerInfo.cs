using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Contract
{
    public class PagerInfo<T>
    {
        #region fields

        #endregion

        #region .ctor

        public PagerInfo()
        {
        }

        public PagerInfo(PagerRequest request)
            : this(request, 0)
        {
        }

        public PagerInfo(PagerRequest request, int totalCount)
        {
            this.Index = request.PageIndex;
            this.Size = request.PageSize;
            this.TotalCount = totalCount;
        }

        public PagerInfo(PagerRequest request, int totalCount, List<T> datas)
        {
            this.Index = request.PageIndex;
            this.Size = request.PageSize;
            this.TotalCount = totalCount;
            this.Datas = datas;
        }

        #endregion

        #region properties

        /// <summary>
        /// 索引 
        /// index = form/size+1
        /// </summary>
        [JsonIgnore]
        public int Index
        {
            get
            {
                if (Size <= 0 || From == 0)
                {
                    return 1;
                }

                return (From / Size) + 1;
            }
            set { }
        }

        /// <summary>
        /// from = (page-1)*size
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public int From { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        /// <summary>
        /// 总数据量
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        [JsonIgnore]
        public int TotalPaged
        {
            get
            {
                return (int)Math.Ceiling(this.TotalCount / (double)this.Size);
            }
            set { }
        }

        /// <summary>
        /// 是否存在分页
        /// </summary>
        [JsonIgnore]
        public bool IsPaged
        {
            get
            {
                return Size < TotalCount;
            }
            set { }
        }

        /// <summary>
        /// 是否存在下一页
        /// </summary>
        [JsonIgnore]
        public bool HasNextPage
        {
            get
            {
                return TotalPaged > Index;
            }
            set { }
        }

        /// <summary>
        /// 总数据量
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public List<T> Datas { get; set; }

        #endregion

    }
}
