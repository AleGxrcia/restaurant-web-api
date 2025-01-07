using RestaurantWebApi.Core.Domain.Common;

namespace RestaurantWebApi.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int TableId { get; set; }
        public decimal Subtotal { get; set; }
        public int StatusId { get; set; }

        // navigation properties
        public Table? Table { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
