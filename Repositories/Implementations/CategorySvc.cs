using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto?> UpdateAsync(Guid id, CategoryDto dto)
        {
            var existing = await _unitOfWork.Categories.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.Categories.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CategoryDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Categories.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Categories.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
