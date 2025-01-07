using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<DishSaveDto, DishDto, Dish>
    {
        Task<List<DishDto>> GetAllDtoWithInclude();
    }
}
