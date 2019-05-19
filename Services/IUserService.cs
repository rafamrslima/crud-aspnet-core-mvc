using crud_aspnetcore_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace crud_aspnetcore_mvc.Services
{
    public interface IUserService
    {
        Task Create(User user);

        List<User> GetUsers();

        Task Update(int id, User user);

        Task Delete(User user);

        User GetUserById(int id);
    }
}