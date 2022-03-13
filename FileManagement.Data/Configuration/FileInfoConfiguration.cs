using FileManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.Data.Configuration
{
    public class FileInfoConfiguration : IEntityTypeConfiguration<FileDataInfo>
    {
        public void Configure(EntityTypeBuilder<FileDataInfo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FileName).IsRequired(true).HasMaxLength(250);

            builder.Property(a => a.ContentType).IsRequired(true).HasMaxLength(250);

            builder.Property(a => a.Path).IsRequired(true).HasMaxLength(250);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");




        }
    }
}
