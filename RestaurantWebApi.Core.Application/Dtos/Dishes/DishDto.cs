using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Enums;

namespace RestaurantWebApi.Core.Application.Dtos.Dishes
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ForHowManyPeople { get; set; }
        public DishCategory Category { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
    }
}
