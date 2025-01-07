using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApi.Core.Application.Services
{
    public class OrderService : GenericService<OrderSaveDto, OrderDto, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IDishRepository dishRepository, IMapper mapper) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public override async Task<OrderSaveDto> Add(OrderSaveDto dto)
        {
            dto.Dishes ??= new List<DishSaveDto>();

            var dishIds = dto.DishIds.Distinct().ToList();
            var dishes = new List<Dish>();

            foreach (var dishId in dishIds)
            {
                var dish = await _dishRepository.GetByIdAsync(dishId);
                if (dish == null)
                {
                    throw new ValidationException("One or more Dish IDs are invalid.");
                }

                dishes.Add(dish);
            }

            var orderEntity = _mapper.Map<Order>(dto);
            orderEntity.Dishes = dishes;

            var savedOrderEntity = await _orderRepository.AddAsync(orderEntity);
            return _mapper.Map<OrderSaveDto>(savedOrderEntity);
        }

        public async Task<List<OrderDto>> GetAllDtoWithInclude()
        {
            var list = await _orderRepository.GetAllWithIncludeAsync(new List<string> { "Dishes", "Dishes.Ingredients" });

            return _mapper.Map<List<OrderDto>>(list);
        }

    }
}
