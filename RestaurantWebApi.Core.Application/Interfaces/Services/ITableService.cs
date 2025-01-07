using RestaurantWebApi.Core.Application.Dtos.Tables;
using RestaurantWebApi.Core.Application.Enums;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<TableSaveDto, TableDto, Table>
    {
        Task ChangeStatus(int id, Status status);
        Task<TableDto> GetTableOrden(int id);
    }
}
