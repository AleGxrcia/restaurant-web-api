namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveDto, Dto, Entity>
        where SaveDto : class
        where Dto : class
        where Entity : class
    {
        Task<SaveDto> Add(SaveDto dto);
        Task Delete(int id);
        Task<List<Dto>> GetAllDto();
        Task<SaveDto> GetByIdSaveDto(int id);
        Task Update(SaveDto dto, int id);
    }
}
