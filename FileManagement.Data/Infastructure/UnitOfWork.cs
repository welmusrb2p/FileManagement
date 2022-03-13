using FileManagement.Core.Interfaces.Infastructure;
using FileManagement.Data.AppContext;
using System.Threading.Tasks;

namespace FileManagement.Data.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FileManagementDbContext _dbContext;

        public UnitOfWork(FileManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
