using System.Text.Json.Serialization;
using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Enums;

namespace RestaurantWebApi.Core.Application.Dtos.Orders
{
    public class OrderSaveDto
    {
        public int? Id { get; set; }
        public int TableId { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; }
        public List<int> DishIds { get; set; }

        [JsonIgnore]
        public ICollection<DishSaveDto>? Dishes { get; set; }
    }
}
