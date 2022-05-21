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
using System.Text.RegularExpressions;

namespace asp_anything.Controllers
{

    public class HomeController : Controller
    {
        public List<User> ReadFromFile()
        {
            //We read the Registrations before all actions and convert it to json
            string path = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\Registrations\\Registrations.json";
            if (System.IO.File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            //If the file is empty then we create a new list
            else
            {
                return new List<User>();
            }
        }
        List<User> UserList = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //UserList becomes the file we just read
            UserList = ReadFromFile();
            _logger = logger;
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
            string path = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\Registrations\\Registrations.json";
            if (System.IO.File.Exists(path))
            {
                    string json = JsonConvert.SerializeObject(UserList);
                    System.IO.File.WriteAllText(path, json);
                    List<User> users = JsonConvert.DeserializeObject <List<User>>(json);
            }
            return View("Login");
        }
        public IActionResult LoginButton(User user)
        {
            user.currentNickname = null;
            foreach(var item in UserList)
            {
                if (item.Nickname == user.Nickname && item.Password == user.Password)
                {
                    /*String ToPublicUrl()
                    {
                        return String.Format("http://www.KKMontana.com/public/{0}.cshtml",
                            Regex.Replace(user.Nickname, "[^a-zA-Z]", ""));
                    }*/
                    user.currentNickname = item.Nickname; 
                    
                    return View("UserI");
                }
            }
            return View("Login");
        }
        public IActionResult Logout()
        {
            return View("Index");
        }
    }
}
