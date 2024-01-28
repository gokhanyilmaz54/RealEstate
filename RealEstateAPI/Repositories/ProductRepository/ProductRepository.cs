using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstateAPI.Dtos.ProductDtos;
using RealEstateAPI.Moels.DapperContext;

namespace RealEstateAPI.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "SELECT * FROM Product (NOLOCK)";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategotyDto>> GetAllProductWithCategoryAsync()
        {
            string query = $@"
SELECT
	P.Id
	,P.Title
	,P.Price
	,P.CoverImage
	,P.City
	,P.District
	,P.Address
	,P.Description
	,C.Name AS ProductCategory
	,P.EmployeeId
	,P.Status
FROM Product AS P (NOLOCK)
LEFT JOIN Category AS C (NOLOCK) ON C.Id = P.ProductCategory";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategotyDto>(query);
                return values.ToList();
            }
        }
    }
}
