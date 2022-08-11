using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAdminsService
    {
        Task<int> AddAdminsAsync(string name, DateTime bornDate, int gender, string email, string tel, string photo, string pwd, int rolesId);

        Task<int> EditAdminsAsync(int id, string name, DateTime bornDate, int gender, string email, string tel, string photo, int rolesId);

        Task<int> ChangePwdAsync(int id, string pwd);

        Task<int> ChangePwdAsync(string accout, string newPwd);

        Task<int> DeleteAdminsAsync(int id);

        Task<int> DeleteAdminsListAsync(int[] idList);

        Task<List<AdminsDto>> GetAllAsync();

        Task<List<AdminsDto>> GetDataByNameAsync(string name);

        Task<int[]> GetDataByRolesIdAsync(int rolesId);

        Task<AdminsDto> GetDataByIdAsync(int id);

        Task<AdminsDto> LoginAsync(string account, string pwd);

        Task<bool> IsExistsAsync(string email);





    }
}
