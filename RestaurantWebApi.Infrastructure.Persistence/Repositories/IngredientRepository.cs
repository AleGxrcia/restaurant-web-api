using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Domain.Entities;
using RestaurantWebApi.Infrastructure.Persistence.Contexts;

namespace RestaurantWebApi.Infrastructure.Persistence.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
