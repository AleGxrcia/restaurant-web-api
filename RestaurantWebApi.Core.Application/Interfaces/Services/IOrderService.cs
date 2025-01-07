using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<OrderSaveDto, OrderDto, Order>
    {
        Task<List<OrderDto>> GetAllDtoWithInclude();
    }
}
