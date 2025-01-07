using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Domain.Entities;
using RestaurantWebApi.Infrastructure.Persistence.Contexts;
using RestaurantWebApi.Infrastructure.Persistence.Repositories;

namespace RestaurantApiV2.Infrastructure.Persistence.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DishRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
