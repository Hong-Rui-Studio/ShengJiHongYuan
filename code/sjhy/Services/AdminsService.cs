using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminsService : IAdminsService
    {
        private IAdminsDal _dal;
        public AdminsService(IAdminsDal dal)
        {
            _dal = dal;
        }

        public async Task<int> AddAdminsAsync(string name, DateTime bornDate, int gender, string email, string tel, string photo, string pwd, int rolesId)
        {
            return await _dal.AddAsync(new Admins
            {
                Name = name,
                BornDate = bornDate,
                Gender = gender,
                Email = email,
                Tel = tel,
                Photo = photo,
                RolesId = rolesId,
                Pwd = pwd
            });
        }

        public async Task<int> ChangePwdAsync(int id, string pwd)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Pwd = pwd;
            return await _dal.EditAsync(data);

        }

        public async Task<int> ChangePwdAsync(string accout, string newPwd)
        {
            var data = await _dal.QueryAsync(a => a.Email.Equals(accout));
            if (data.Any())
            {
                var model = data.First(); //当data存在数据的时候我们来找到其中第一个
                model.Pwd = newPwd;
                return await _dal.EditAsync(model);
            }
            return -1;
        }

        public async Task<int> DeleteAdminsAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> DeleteAdminsListAsync(int[] idList)
        {
            foreach (var item in idList)
            {
                var model = await _dal.QueryAsync(item);
                if (model != null)
                    await _dal.DeleteAsync(model, false);
            }

            return await _dal.SaveData(); //当上面的所有数据存入到缓冲区的时候，一次执行保存操作
        }

        public async Task<int> EditAdminsAsync(int id, string name, DateTime bornDate, int gender, string email, string tel, string photo, int rolesId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Name = name;
            data.BornDate = bornDate;
            data.Gender = gender;
            data.Email = email;
            data.Tel = tel;
            if (!string.IsNullOrEmpty(photo))
                data.Photo = photo;
            data.RolesId = rolesId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<List<AdminsDto>> GetAllAsync()
        {
            var data = await _dal.QueryAsync();
            return data.Any() ?
                data.Select(a => new AdminsDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    BornDate = a.BornDate,
                    Gender = a.Gender,
                    Email = a.Email,
                    Tel = a.Tel,
                    Photo = a.Photo,
                    RolesId = a.RolesId,
                    UpdateTime = a.UpdateTime.ToString("yyyy-MM-dd")
                }).ToList()
                : new List<AdminsDto>();

        }

        public async Task<AdminsDto> GetDataByIdAsync(int id)
        {
            var data = await _dal.QueryAsync(id);
            return data == null ? new AdminsDto() : new AdminsDto
            {
                Id = data.Id,
                Name = data.Name,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Tel = data.Tel,
                Photo = data.Photo,
                RolesId = data.RolesId,
                UpdateTime = data.UpdateTime.ToString("yyyy-MM-dd")

            };
        }

        public async Task<List<AdminsDto>> GetDataByNameAsync(string name)
        {
            var data = await _dal.QueryAsync(a => a.Name.Contains(name));
            return data.Any() ?
                data.Select(a => new AdminsDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    BornDate = a.BornDate,
                    Gender = a.Gender,
                    Email = a.Email,
                    Tel = a.Tel,
                    Photo = a.Photo,
                    RolesId = a.RolesId,
                    UpdateTime = a.UpdateTime.ToString("yyyy-MM-dd")
                }).ToList()
                : new List<AdminsDto>();
        }

        public async Task<int[]> GetDataByRolesIdAsync(int rolesId)
        {
            var data = await _dal.QueryAsync(a => a.RolesId == rolesId);
            if (data == null || !data.Any())
                return new int[0];

            var idList = new int[data.Count];
            for(int i = 0; i < data.Count;i++)
            {
                idList[i] = data[i].Id;
            }
            return idList;
        }

        public async Task<bool> IsExistsAsync(string email)
        {
            var data = await _dal.QueryAsync(a => a.Email.Equals(email));

            return data != null || data.Any() ? false : true;
        }

        public async Task<AdminsDto> LoginAsync(string account, string pwd)
        {
            var data = await _dal.QueryAsync(a => a.Email.Equals(account) && a.Pwd.Equals(pwd));
            if (data == null || !data.Any()) 
            {
                return null;
            }
            return data.Select(a => new AdminsDto 
            {
                Id = a.Id,
                Name = a.Name,
                BornDate = a.BornDate,
                Gender = a.Gender,
                Email = a.Email,
                Tel = a.Tel,
                Photo = a.Photo,
                RolesId = a.RolesId,
                UpdateTime = a.UpdateTime.ToString("yyyy-MM-dd")

            }).First();
        }
    }
}
