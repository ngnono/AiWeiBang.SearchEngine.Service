using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Log_UploadMap : EntityTypeConfiguration<Log_Upload>
    {
        public Log_UploadMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.Action)
                .HasMaxLength(20);

            this.Property(t => t.Image)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Log_Upload");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
