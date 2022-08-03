global using Entity.Dtos;
namespace IServices
{
    public interface IRolesService
    {
        Task<int> AddRolesAsync(string title);

        Task<int> EditRolesAsync(int id, string title);

        Task<int> DeleteRolesAsync(int id);

        Task<List<RolesDto>> GetAllAsync();

        Task<List<RolesDto>> GetRolesByTitleAsync(string title);

        Task<RolesDto> GetRolesByIdAsync(int id);
    }
}