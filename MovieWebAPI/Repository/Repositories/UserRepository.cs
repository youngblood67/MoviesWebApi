using Model;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly MovieDbContext _context;

        public UserRepository(MovieDbContext context)
        {
            this._context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool Delete(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
            return true;
        }

        public User Update(int id, User user)
        {
            User toUpdate = GetAllUsers().Find(x => x.UserId == id);
            toUpdate.UserId = id; //??
            _context.Entry(toUpdate).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return toUpdate;
        }

        public User GetById(int id)
        {
            User user = GetAllUsers().Find(x => x.UserId == id);
            return user;
        }
    }
}
