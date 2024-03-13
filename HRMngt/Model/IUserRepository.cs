using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Model
{
    public interface IUserRepository
    {
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Delete(int id);
        IEnumerable<UserModel> GetAll();
        IEnumerable<UserModel> GetByValue(); // Search
    }
}
