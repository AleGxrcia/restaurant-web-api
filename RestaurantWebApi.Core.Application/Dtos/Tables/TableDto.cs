using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Application.Enums;

namespace RestaurantWebApi.Core.Application.Dtos.Tables
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public ICollection<OrderDto>? Orders { get; set; }
    }
}
