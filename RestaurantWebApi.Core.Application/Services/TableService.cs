using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Dishes;
using RestaurantWebApi.Core.Application.Dtos.Ingredients;
using RestaurantWebApi.Core.Application.Dtos.Orders;
using RestaurantWebApi.Core.Application.Dtos.Tables;
using RestaurantWebApi.Core.Application.Enums;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Services
{
    public class TableService : GenericService<TableSaveDto, TableDto, Table>, ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public override async Task<List<TableDto>> GetAllDto()
        {
            var list = await _tableRepository.GetAllWithIncludeAsync(new List<string> { "Orders", "Orders.Dishes", "Orders.Dishes.Ingredients" });

            var tableDtos = list.Select(table => new TableDto()
            {
                Id = table.Id,
                Capacity = table.Capacity,
                Description = table.Description,
                Status = (Status)table.StatusId,
                Orders = table.Orders?.Select(order => new OrderDto()
                {
                    Id = order.Id,
                    TableId = order.TableId,
                    Subtotal = order.Subtotal,
                    Status = (OrderStatus)order.StatusId,
                    Dishes = order.Dishes?.Select(dish => new DishDto()
                    {
                        Id = dish.Id,
                        Name = dish.Name,
                        Price = dish.Price,
                        ForHowManyPeople = dish.ForHowManyPeople,
                        Category = (DishCategory)dish.CategoryId,
                        Ingredients = dish.Ingredients?.Select(ingredient => new IngredientDto()
                        {
                            Id = ingredient.Id,
                            Name = ingredient.Name,
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToList();

            return tableDtos;
        }

        public async Task<TableDto> GetTableOrden(int id)
        {
            var table = await _tableRepository.GetByIdWithIncludeAsync(id, new List<string> { "Orders", "Orders.Dishes", "Orders.Dishes.Ingredients" });

            var tableDto = _mapper.Map<TableDto>(table);

            return tableDto;
        }

        public async Task ChangeStatus(int id, Status status)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            table.Id = id;
            table.StatusId = (int)status;
            await _tableRepository.UpdateAsync(table, id);
        }
    }
}
