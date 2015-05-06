using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WxUserExtMap : EntityTypeConfiguration<WxUserExt>
    {
        public WxUserExtMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WechatName)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.WechatBiz)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.WechatID)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.Alias)
                .HasMaxLength(80);

            this.Property(t => t.PhotoImg)
                .HasMaxLength(128);

            this.Property(t => t.WechatQrcode)
                .HasMaxLength(128);

            this.Property(t => t.Introduction)
                .HasMaxLength(64);

            this.Property(t => t.Token)
                .HasMaxLength(10);

            this.Property(t => t.SysRemark)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("WxUserExt");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.WechatName).HasColumnName("WechatName");
            this.Property(t => t.WechatBiz).HasColumnName("WechatBiz");
            this.Property(t => t.WechatFakeID).HasColumnName("WechatFakeID");
            this.Property(t => t.WechatID).HasColumnName("WechatID");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.PhotoImg).HasColumnName("PhotoImg");
            this.Property(t => t.WechatQrcode).HasColumnName("WechatQrcode");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.FansRange).HasColumnName("FansRange");
            this.Property(t => t.Fans).HasColumnName("Fans");
            this.Property(t => t.Introduction).HasColumnName("Introduction");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.CommitAccountID).HasColumnName("CommitAccountID");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.Coin).HasColumnName("Coin");
            this.Property(t => t.CoinEarned).HasColumnName("CoinEarned");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.BroadcastStatus).HasColumnName("BroadcastStatus");
            this.Property(t => t.DevStatus).HasColumnName("DevStatus");
            this.Property(t => t.SysStatus).HasColumnName("SysStatus");
            this.Property(t => t.SysRemark).HasColumnName("SysRemark");
            this.Property(t => t.SysAccountID).HasColumnName("SysAccountID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}
