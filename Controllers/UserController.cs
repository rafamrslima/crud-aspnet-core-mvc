
using System.Collections.Generic;
using System.Threading.Tasks;
using crud_aspnetcore_mvc.Models;
using crud_aspnetcore_mvc.Services;
using crud_aspnetcore_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace crud_aspnetcore_mvc.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ViewResult Index(string styleMessage, string textMessage, bool showMessage = false)
        {
            List<User> users = _userService.GetUsers();
            UserViewModel userViewModel = new UserViewModel()
            {
                Users = users,
                ShowMessage = showMessage,
                StyleMessage = styleMessage,
                TextMessage = textMessage
            };

            return View(userViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Save(User user)
        {
            string textMessage;

            // edit
            if (user.Id > 0)
            {
                await _userService.Update(user.Id, user);
                textMessage = "updated";
            }

            // new user
            else
            {
                await _userService.Create(user);
                textMessage = "created";
            }

            return RedirectToAction("Index", "User",
                new  { styleMessage = "success", textMessage = $"User {textMessage} successfully.",  showMessage = true });
        }

        public ViewResult Edit(int id)
        {
            User user = _userService.GetUserById(id);
            return View("Create", user);
        }

        public async Task<ActionResult> Delete(int id)
        {
            User userDb = _userService.GetUserById(id);
            await _userService.Delete(userDb);

            return RedirectToAction("Index", "User",
                new { styleMessage = "warning", textMessage = $"User removed successfully.", showMessage = true });
        }
    }
}