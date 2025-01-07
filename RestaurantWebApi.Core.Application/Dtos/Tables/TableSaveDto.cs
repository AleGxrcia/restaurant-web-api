using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Application.Enums;
using System.Text.Json.Serialization;

namespace RestaurantWebApi.Core.Application.Dtos.Tables
{
    public class TableSaveDto
    {
        public int? Id { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }

        [JsonIgnore]
        public ICollection<OrderDto> Orders { get; set; }
    }
}
