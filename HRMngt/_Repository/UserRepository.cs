using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HRMngt.Model;

namespace HRMngt._Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        // Contructor
        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByValue()
        {
            throw new NotImplementedException();
        }
    }
}
