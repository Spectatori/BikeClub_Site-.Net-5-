using asp_anything.Models;
using Google.Api.Ads.AdWords.v201809;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static asp_anything.Models.User;
using asp_anything.Services;
using Microsoft.AspNetCore.Http;
using asp_anything.Security;

namespace asp_anything.Controllers
{
    public class HomeController : Controller
    {
        IFileManagerService _fileManagerService;
        List<User> UserList = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFileManagerService service)
        {
            _fileManagerService = service;//Doesn't delete service and stays here
            UserList = _fileManagerService.ReadFromFile(); //UserList becomes the file we just read
            _logger = logger;
        }
        public IActionResult Profile()
        {
            User user = _fileManagerService.ReadFromCookie(Request); //Reads from cookies and if something's in there it returns Profile
            if (user != null)
            {
                _fileManagerService.WriteToCookie(user, Response);
                return View("Profile", user);
            }
            else
            {
                return View("Login");
            }

        }

        public IActionResult Index()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            { 
                return View("Profile", user);
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Crew()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("Crew");
            }
        }

        public IActionResult Login()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult Events()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("Events");
            }
        }

        public IActionResult News()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("News");
            }
        }

        public IActionResult Sponsors()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("Sponsors");
            }
        }

        public IActionResult Gallery()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile", user);
            }
            else
            {
                return View("Gallery");
            }
        }
        public IActionResult UserTeam()
        {

            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserTeam");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult UserCrew()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserCrew");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult UserEvents()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserEvents");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult UserGallery()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserGallery");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult UserNews()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserNews");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult UserSponsors()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("UserSponsors");
            }
            else
            {
                return View("Login");
            }
        }
        public IActionResult Register()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("Profile");
            }
            else
            {
                return View("Register");
            }
        }
        public IActionResult ChangePassword()
        {
            User user = _fileManagerService.ReadFromCookie(Request);
            if (user != null)
            {
                return View("ChangePassword");
            }
            else
            {
                return View("Register");
            }
        }
        public IActionResult RegisterButton(User user)
        {
            if (UserList.Any(u => u.Email == user.Email))
            {
                return View("Register");
            }
            UserList.Add(user); // adds the user in the list
            _fileManagerService.WriteUsers(UserList); //writes the list in the document
            return View("Login");
        }
        public IActionResult LoginButton(User user)
        {
            var item = UserList.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password); 
            if(item == null)
            {
                return View("Login");
            }
            else
            {
                _fileManagerService.WriteToCookie(item, Response);
                return View("Profile", item);
            }
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user");
            return View("Index");
        }
        public IActionResult ChangePicture(User user)
        {
            string pictureURL = user.userPhoto; //takes the entered picture in Profile
            user = _fileManagerService.ReadFromCookie(Request); //
            if(user == null)
            {
                return View("Login");
            }
            var item = UserList.FirstOrDefault(x => x.Email == user.Email);
            if (item == null)
            {
                return View("Login");
            }
            else
            {
                item.userPhoto = pictureURL;
                _fileManagerService.WriteUsers(UserList);

                _fileManagerService.WriteToCookie(item, Response);
                user.userPhoto = item.userPhoto;
                return View("Profile", user);
            }
        }
        public IActionResult PasswordChange(User user)
        {
            string change = user.changePassword;
            var item = UserList.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (item == null)
            {
                return View("Login");
            }
            else
            {
                item.Password = change;
                _fileManagerService.WriteUsers(UserList);
                Response.Cookies.Delete("user");
                return View("Login");
            }
        }
    }
}
