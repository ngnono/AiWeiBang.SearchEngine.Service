using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class DevReceiveLogMap : EntityTypeConfiguration<DevReceiveLog>
    {
        public DevReceiveLogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.FromUserName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.MsgType)
                .HasMaxLength(20);

            this.Property(t => t.Content)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("DevReceiveLog");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FromUserName).HasColumnName("FromUserName");
            this.Property(t => t.MsgType).HasColumnName("MsgType");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.MsgID).HasColumnName("MsgID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
