using Microsoft.EntityFrameworkCore;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Domain.Entities;
using RestaurantWebApi.Infrastructure.Persistence.Contexts;

namespace RestaurantWebApi.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<Table?> GetByIdWithIncludeAsync(int id, List<string> properties)
        {
            var query = _dbContext.Set<Table>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}
