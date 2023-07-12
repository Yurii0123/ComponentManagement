using Microsoft.EntityFrameworkCore;
using TCM.Core.Entities;
using TCM.Core.Interfaces.Repositories;
using TCM.Infrastructure.Contexts;

namespace TCM.Infrastructure.Repositories
{
    public class TrainComponentRepository : GenericRepository<TrainComponent>, ITrainComponentRepository
    {
        public TrainComponentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<TrainComponent> GetComponentsWithHierarchy(int? rootComponentId)
        {

            return rootComponentId.HasValue ?
                _dbContext.TrainComponents.Where(x => x.Id == rootComponentId.Value)
                .Include(u => u.Children) :
                _dbContext.TrainComponents
                .Include(u => u.Children);
            //.ToList();
        }

        public async Task<bool> CheckDependencyExists(int parentId, int childId)
        {

            var result = await _dbContext.Database.SqlQueryRaw<int>("SELECT COUNT(ParentsId) \r\n " +
                "FROM TrainComponentTrainComponent \r\n " +
                "WHERE ParentsId = {0} AND  ChildrenId = {1};", parentId, childId).ToListAsync();

            return result.First() > 0;
        }

        public async Task<bool> CheckCircularDependency(int parentId, int childId)
        {

            var result = await _dbContext.Database.SqlQueryRaw<int>("WITH PathUp AS \r\n" +
               "(SELECT r.ParentsId, r.ChildrenId FROM TrainComponentTrainComponent r WHERE r.ParentsId = {0} or r.ParentsId = {1} \r\n" +
               "UNION ALL \r\n" +
               "SELECT c.ParentsId, c.ChildrenId FROM TrainComponentTrainComponent c  JOIN PathUp p ON p.ChildrenId = c.ParentsId) \r\n" +
               "SELECT COUNT(ParentsId) FROM PathUp WHERE ParentsId = {1};", parentId, childId).ToListAsync();

            return result.First() > 0;
        }
    }
}
