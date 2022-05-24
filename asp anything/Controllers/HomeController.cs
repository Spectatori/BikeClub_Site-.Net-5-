using asp_anything.Models;
using Google.Api.Ads.AdWords.v201809;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static asp_anything.Models.User;
using asp_anything.Services;

namespace asp_anything.Controllers
{
    public class HomeController : Controller
    {
        IFileManagerService _fileManagerService;
        List<User> UserList = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFileManagerService service)
        {
            //UserList becomes the file we just read
            _fileManagerService = service;//Doesn't delete service and stays here
            UserList = _fileManagerService.ReadFromFile();
            _logger = logger;
        }
        public IActionResult Profile()
        {
            return View("Profile");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crew()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult ForgottenPassword()
        {
            return View();
        }

        public IActionResult Register(List<User> userList)
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Sponsors()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult UserI()
        {
            return View();
        }
        public IActionResult UserCrew()
        {
            return View();
        }
        public IActionResult UserEvents()
        {
            return View();
        }
        public IActionResult UserGallery()
        {
            return View();
        }
        public IActionResult UserNews()
        {
            return View();
        }
        public IActionResult UserSponsors()
        {
            return View();
        }
        public IActionResult RegisterButton(User user)
        {
            UserList.Add(user);
            _fileManagerService.WriteUsers(UserList);
            return View("Login");
        }
        public IActionResult LoginButton(User user)
        {
            var item = UserList.FirstOrDefault(x => x.Nickname == user.Nickname && x.Password == user.Password);
            if(item == null)
            {
                return View("Login");
            }
            else
            {
                user.currentNickname = item.Nickname;
                return View("Profile2");
            }
            /*{
                if (item.Nickname == user.Nickname && item.Password == user.Password)
                {
                    *//*String ToPublicUrl()
                    {
                        return String.Format("http://www.KKMontana.com/public/{0}.cshtml",
                            Regex.Replace(user.Nickname, "[^a-zA-Z]", ""));
                    }*//*
                    user.currentNickname = item.Nickname;
                    user.currentPassword = item.Password;
                    
                    return View("Profile");
                }
            }*/
        }
        public IActionResult Logout()
        {
            return View("Index");
        }
        public IActionResult Change(User user)
        {
            var currentUser = UserList.FirstOrDefault(x => x.Nickname == user.Nickname && x.Password == user.Password);
            if(currentUser != null)
            {
                currentUser.Nickname = user.Nickname;
                currentUser.Password = user.Password;
            }
            return View("Login");
        }
    }
}
