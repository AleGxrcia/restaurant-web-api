using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<IngredientSaveDto, IngredientDto, Ingredient> 
    {

    }
}
