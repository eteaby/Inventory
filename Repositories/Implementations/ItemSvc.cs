using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _unitOfWork.Items.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto?> GetByIdAsync(Guid id)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto> CreateAsync(ItemCreateDto dto)
        {
            var item = _mapper.Map<Item>(dto);
            await _unitOfWork.Items.AddAsync(item);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto?> UpdateAsync(Guid id, ItemDto dto)
        {
            var existing = await _unitOfWork.Items.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.Items.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ItemDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Items.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Items.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
