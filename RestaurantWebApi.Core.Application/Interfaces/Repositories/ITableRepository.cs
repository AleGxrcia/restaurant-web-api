using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<Table?> GetByIdWithIncludeAsync(int id, List<string> properties);
    }
}
