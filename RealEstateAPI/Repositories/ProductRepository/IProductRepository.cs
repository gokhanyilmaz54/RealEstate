using RealEstateAPI.Dtos.ProductDtos;

namespace RealEstateAPI.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategotyDto>> GetAllProductWithCategoryAsync();
    }
}
