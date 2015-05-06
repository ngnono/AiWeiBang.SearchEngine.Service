using System;

namespace AiWeiBang.SearchEngine.Contract
{
    /// <summary>
    /// 分页请求
    /// </summary>
    public class PagerRequest
    {
        private const int DefaultMaxPageSize = 1000;
        private readonly int _maxPageSize;

        public PagerRequest()
            : this(DefaultMaxPageSize)
        {
        }

        public PagerRequest(int maxPageSize)
        {
            _maxPageSize = maxPageSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerRequest"/> class.
        /// </summary>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagerRequest(int pageNumber, int pageSize)
            : this(pageNumber, pageSize, DefaultMaxPageSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerRequest"/> class.
        /// </summary>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="maxPageSize"> </param>
        public PagerRequest(int pageNumber, int pageSize, int maxPageSize)
            : this(maxPageSize)
        {
            PageSize = pageSize;
            PageIndex = pageNumber;
        }

        /// <summary>
        /// local pageNumber
        /// </summary>
        private int _pageIndex;

        /// <summary>
        /// local pageSize
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            private set
            {
                _pageSize = (value < 1 ? 1 : (value > _maxPageSize ? _maxPageSize : value));
            }
        }

        public int SkipCount
        {
            get { return (PageIndex - 1) * PageSize; }
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }

            set
            {
                _pageIndex = value < 1 ? 1 : value;
            }
        }

        public static bool TryParse(string query, out PagerRequest result)
        {
            result = null;

            if (String.IsNullOrEmpty(query))
            {
                return false;
            }

            var parts = query.Split(',');
            if (parts.Length != 2)
            {
                return false;
            }

            int page, pageSize;

            if ((Int32.TryParse(parts[0], out page)) && (Int32.TryParse(parts[1], out pageSize)))
            {
                result = new PagerRequest(page, pageSize);

                return true;
            }

            return false;
        }
    }
}