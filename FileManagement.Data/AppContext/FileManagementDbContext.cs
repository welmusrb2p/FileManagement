using FileManagement.Data.Configuration;
using FileManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.Data.AppContext
{
    public class FileManagementDbContext : DbContext
    {
        public FileManagementDbContext()
        { }
        public FileManagementDbContext(DbContextOptions<FileManagementDbContext> options) : base(options)
        { }

        public DbSet<FileDataInfo> FileDataInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FileInfoConfiguration());
        }
    }
}
