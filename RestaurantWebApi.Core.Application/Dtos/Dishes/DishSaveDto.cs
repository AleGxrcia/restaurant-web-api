using System.Text.Json.Serialization;
using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Enums;

namespace RestaurantWebApi.Core.Application.Dtos.Dishes
{
    public class DishSaveDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ForHowManyPeople { get; set; }
        public DishCategory Category { get; set; }
        public List<int> IngredientIds { get; set; }

        [JsonIgnore]
        public ICollection<IngredientSaveDto>? Ingredients { get; set; }
    }
}
