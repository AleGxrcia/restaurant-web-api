using AutoMapper;
using RestaurantWebApi.Core.Application.Interfaces.Repositories;
using RestaurantWebApi.Core.Application.Interfaces.Services;

namespace RestaurantWebApi.Core.Application.Services
{
    public class GenericService<SaveDto, Dto, Entity> : IGenericService<SaveDto, Dto, Entity>
        where SaveDto : class
        where Dto : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveDto> Add(SaveDto dto)
        {
            Entity entity = _mapper.Map<Entity>(dto);

            entity = await _repository.AddAsync(entity);

            SaveDto saveDto = _mapper.Map<SaveDto>(entity);

            return saveDto;
        }

        public virtual async Task Update(SaveDto dto, int id)
        {
            Entity entity = _mapper.Map<Entity>(dto);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<SaveDto> GetByIdSaveDto(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SaveDto>(entity);
        }

        public virtual async Task<List<Dto>> GetAllDto()
        {
            var entityList = await _repository.GetAllAsync();
            return _mapper.Map<List<Dto>>(entityList);
        }
    }
}
