

namespace Services
{
    public class SystemMenusService : ISystemMenusService
    {

        private ISystemMenusDal _dal;
        public SystemMenusService(ISystemMenusDal dal)
        {
            _dal = dal;
        }

        public async Task<int> AddMenusAsync(string title, string link, string icon, int parentId)
        {
            return await _dal.AddAsync(new SystemMenus
            {
                Title = title,
                Link = link,
                Icon = icon,
                ParentId =parentId
            });
        }

        public async Task<int> DeleteMenusAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditMenusAsync(int id, string title, string link, string icon, int parentId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Title = title;
            data.Link = link;
            data.ParentId = parentId;
            data.Icon = icon;
            return await _dal.EditAsync(data);
        }

        public async Task<List<SystemMenusDto>> GetAllAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Select(m => new SystemMenusDto 
            {
                Id = m.Id,
                Title = m.Title,
                Link = m.Link,
                Icon =m.Icon,
                ParentId = m.ParentId
            }).ToList();
        }

        public async Task<SystemMenusDto> GetDataByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new SystemMenusDto() : new SystemMenusDto
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                Icon = data.Icon,
                ParentId = data.ParentId
            };
        }

        public async Task<List<SystemMenusDto>> GetDataByParentsIdAsync(int parentId)
        {
            var data = await _dal.QueryAsync(m => m.ParentId == parentId);
            return data.Any() 
                ? data.Select(m => new SystemMenusDto 
                {
                    Id = m.Id,
                    Title = m.Title,
                    Link = m.Link,
                    Icon = m.Icon,
                    ParentId = m.ParentId
                }) .ToList()
                : new List<SystemMenusDto>();
        }

        public async Task<List<SystemMenusDto>> GetDataByTitleAsync(string title)
        {
            var data = await _dal.QueryAsync(m => m.Title.Contains(title));
            return data.Any()
                ? data.Select(m => new SystemMenusDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Link = m.Link,
                    Icon = m.Icon,
                    ParentId = m.ParentId
                }).ToList()
                : new List<SystemMenusDto>();
        }
    }
}
