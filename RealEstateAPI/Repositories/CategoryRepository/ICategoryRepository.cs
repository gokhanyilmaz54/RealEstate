using RealEstateAPI.Dtos.CategoryDtos;

namespace RealEstateAPI.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        void DeleteCategory(int id);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
