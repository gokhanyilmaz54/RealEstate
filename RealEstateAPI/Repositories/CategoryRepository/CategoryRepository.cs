using RealEstateAPI.Dtos.CategoryDtos;
using RealEstateAPI.Moels.DapperContext;
using Dapper;

namespace RealEstateAPI.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO Category (Name, Status) VALUES(@Name, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", categoryDto.Name);
            parameters.Add("Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Category (NOLOCK)";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = "SELECT * FROM Category (NOLOCK) WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE Category SET Name = @Name, Status = @Status WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", categoryDto.Id);
            parameters.Add("Name", categoryDto.Name);
            parameters.Add("Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
