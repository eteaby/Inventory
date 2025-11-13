using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class ContainerService : IContainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContainerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContainerDto>> GetAllAsync()
        {
            var containers = await _unitOfWork.Containers.GetAllAsync();
            return _mapper.Map<IEnumerable<ContainerDto>>(containers);
        }

        public async Task<ContainerDto?> GetByIdAsync(Guid id)
        {
            var container = await _unitOfWork.Containers.GetByIdAsync(id);
            return container == null ? null : _mapper.Map<ContainerDto>(container);
        }

        public async Task<ContainerDto> CreateAsync(ContainerCreateDto dto)
        {
            var container = _mapper.Map<Container>(dto);
            await _unitOfWork.Containers.AddAsync(container);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContainerDto>(container);
        }

        public async Task<ContainerDto?> UpdateAsync(Guid id, ContainerDto dto)
        {
            var existing = await _unitOfWork.Containers.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.Containers.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContainerDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Containers.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Containers.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<ContainerDto>> GetByItemIdAsync(string itemId)
        {
            var containers = await _unitOfWork.Containers.FindAsync(c => c.ItemId == itemId);
            return _mapper.Map<IEnumerable<ContainerDto>>(containers);
        }
    }
}

