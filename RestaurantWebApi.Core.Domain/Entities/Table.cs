using RestaurantWebApi.Core.Domain.Common;

namespace RestaurantWebApi.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }

        // navigation properties
        public ICollection<Order>? Orders { get; set; }
    }
}
