using RestaurantWebApi.Core.Domain.Common;

namespace RestaurantWebApi.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ForHowManyPeople { get; set; }
        public int CategoryId { get; set; }

        // navigation properties
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
