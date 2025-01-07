using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApi.Core.Application.Services
{
    public class DishService : GenericService<DishSaveDto, DishDto, Dish>, IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public DishService(IDishRepository dishRepository, IIngredientRepository ingredientRepository, IMapper mapper) : base(dishRepository, mapper)
        {
            _dishRepository = dishRepository;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public override async Task<DishSaveDto> Add(DishSaveDto dto)
        {
            dto.Ingredients ??= new List<IngredientSaveDto>();

            var ingredientIds = dto.IngredientIds.Distinct().ToList();
            var ingredients = new List<Ingredient>();

            foreach (var ingredientId in ingredientIds)
            {
                var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
                if (ingredient == null)
                {
                    throw new ValidationException("One or more ingredient IDs are invalid.");
                }

                ingredients.Add(ingredient);
            }

            var dishEntity = _mapper.Map<Dish>(dto);
            dishEntity.Ingredients = ingredients;

            var savedDishEntity = await _dishRepository.AddAsync(dishEntity);
            return _mapper.Map<DishSaveDto>(savedDishEntity);
        }

        public async Task<List<DishDto>> GetAllDtoWithInclude()
        {
            var list = await _dishRepository.GetAllWithIncludeAsync(new List<string> { "Ingredients" });

            return _mapper.Map<List<DishDto>>(list);
        }
    }
}
