using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiWeiBang.SearchEngine.Data.Models
{

    public partial class WechatMsg_Content01Context
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName">WechatMsg_Content01Context</param>
        public WechatMsg_Content01Context(string connectionStringName)
            : base("Name=" + connectionStringName)
        {
        }
    }
}
