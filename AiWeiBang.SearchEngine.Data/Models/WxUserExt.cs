using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WxUserExt
    {
        public int UserID { get; set; }
        public string WechatName { get; set; }
        public string WechatBiz { get; set; }
        public Nullable<long> WechatFakeID { get; set; }
        public string WechatID { get; set; }
        public string Alias { get; set; }
        public string PhotoImg { get; set; }
        public string WechatQrcode { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public byte FansRange { get; set; }
        public int Fans { get; set; }
        public string Introduction { get; set; }
        public string Token { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
        public Nullable<int> CommitAccountID { get; set; }
        public int Score { get; set; }
        public int Coin { get; set; }
        public int CoinEarned { get; set; }
        public byte SortIndex { get; set; }
        public byte BroadcastStatus { get; set; }
        public byte DevStatus { get; set; }
        public byte SysStatus { get; set; }
        public string SysRemark { get; set; }
        public Nullable<int> SysAccountID { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
