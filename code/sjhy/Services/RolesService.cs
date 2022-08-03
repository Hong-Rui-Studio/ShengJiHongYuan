global using IRepository;
global using IServices;
global using Entity.Dtos;
global using Entity.Models;
namespace Services
{
    public class RolesService : IRolesService
    {
        private IRolesDal _dal;
        public RolesService(IRolesDal dal)
        {
            _dal = dal;
        }

        public async Task<int> AddRolesAsync(string title)
        {
            return await _dal.AddAsync(new Roles
            {
                Title = title
            });
        }

        public async Task<int> DeleteRolesAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditRolesAsync(int id, string title)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Title = title;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<List<RolesDto>> GetAllAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Select(r => new RolesDto 
            {
                Id = r.Id,
                Title = r.Title,
                UpdateTime = r.UpdateTime.ToString("yyyy-MM-dd")
            }).ToList();
        }

        public async Task<RolesDto> GetRolesByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new RolesDto() : new RolesDto 
            {
                Id = data.Id,
                Title = data.Title,
                UpdateTime = data.UpdateTime.ToString("yyyy-MM-dd")
            };
        }

        public async Task<List<RolesDto>> GetRolesByTitleAsync(string title)
        {
            var data = await _dal.QueryAsync(r => r.Title.Contains(title));
            return data.Select(r => new RolesDto
            {
                Id = r.Id,
                Title = r.Title,
                UpdateTime = r.UpdateTime.ToString("yyyy-MM-dd")
            }).ToList();
        }
    }
}