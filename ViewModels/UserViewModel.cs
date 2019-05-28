using crud_aspnetcore_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_aspnetcore_mvc.ViewModels
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public bool ShowMessage { get; set; }
        public string TextMessage { get; set; }
        public string StyleMessage { get; set; }
    }
}