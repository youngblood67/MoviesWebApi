using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User Add(User user);
        bool Delete(int id);
        User Update(int id, User user);
        User GetById(int id);
    }
}
