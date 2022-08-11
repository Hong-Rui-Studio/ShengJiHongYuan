using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISystemMenusService
    {
        Task<int> AddMenusAsync(string title, string link, string icon, int parentId);

        Task<int> EditMenusAsync(int id, string title, string link, string icon, int parentId);

        Task<int> DeleteMenusAsync(int id);


        Task<List<SystemMenusDto>> GetAllAsync();

        Task<List<SystemMenusDto>> GetDataByTitleAsync(string title);

        Task<List<SystemMenusDto>> GetDataByParentsIdAsync(int parentId);

        Task<SystemMenusDto> GetDataByIdAsync(int id);


    }
}
