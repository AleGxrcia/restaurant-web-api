using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Domain.Entities;
using RestaurantWebApi.Infrastructure.Persistence.Contexts;

namespace RestaurantWebApi.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
