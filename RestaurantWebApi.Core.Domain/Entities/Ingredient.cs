using RestaurantWebApi.Core.Domain.Common;

namespace RestaurantWebApi.Core.Domain.Entities
{
    public class Ingredient : AuditableBaseEntity
    {
        public string Name { get; set; }

        // navigation properties
        public ICollection<Dish>? Dishes { get; set; }
    }
}
