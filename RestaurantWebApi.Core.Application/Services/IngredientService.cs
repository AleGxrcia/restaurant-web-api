using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Services
{
    public class IngredientService : GenericService<IngredientSaveDto, IngredientDto, Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper) : base(ingredientRepository, mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

    }
}
