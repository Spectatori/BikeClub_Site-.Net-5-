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

namespace asp_anything.Controllers
{

    public class HomeController : Controller
    {
        public List<User> ReadFromFile()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\Registrations\\Registrations.json";
            if (System.IO.File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            else
            {
                return new List<User>();
            }
        }
        List<User> UserList = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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
            return View("Login", user);
        }


        public IActionResult LoginButton(User user)
        {
            foreach(var item in UserList)
            {
                if (item.Nickname == user.Nickname && item.Password == user.Password && item.Email == user.Email)
                {
                    return View("Register");
                }
            }
            return View("Login");
        }
        
    }
}
