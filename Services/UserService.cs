using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using crud_aspnetcore_mvc.Data;
using crud_aspnetcore_mvc.Models;

namespace crud_aspnetcore_mvc.Services
{
    public class UserService : IUserService
    {
        UserDbContext _userDbContext;

        public UserService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task Create(User user)
        {
            await _userDbContext.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _userDbContext.Remove(user);
            await _userDbContext.SaveChangesAsync();
        }

        public List<User> GetUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _userDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task Update(int id, User user)
        {
            User userDb = _userDbContext.Users.Where(x => x.Id == id).FirstOrDefault();

            if (userDb == null)
                return;

            userDb.Name = user.Name;
            userDb.Email = user.Email;

            await _userDbContext.SaveChangesAsync();
        }
    }
}