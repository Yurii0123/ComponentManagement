using Microsoft.EntityFrameworkCore;
using TCM.Core.Entities;

namespace TCM.Core.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<TrainComponent> TrainComponents { get; set; }
        Task<int> SaveChangesAsync();
    }
}
