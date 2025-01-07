using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Enums;

namespace RestaurantWebApi.Core.Application.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<DishDto> Dishes { get; set; }
    }
}
