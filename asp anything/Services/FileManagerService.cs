using asp_anything.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using SecurityLibrary.Security;

namespace asp_anything.Services
{
    public class FileManagerService : IFileManagerService
    {
        private string Key { get; set; } = "12345678901234567890123456789012"; //капсулация
        public virtual List<User> ReadFromFile()
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
        public virtual List<User> ReadFromFile(string path)
        {
            //We read the Registrations before all actions and convert it to json
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
        public virtual void WriteUsers(List<User> users)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\Registrations\\Registrations.json";
            if (System.IO.File.Exists(path))
            {
                string json = JsonConvert.SerializeObject(users);
                System.IO.File.WriteAllText(path, json);
               // List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }
        public virtual void WriteToCookie(User user, HttpResponse response)
        {
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddHours(100) };
            string userString = JsonConvert.SerializeObject(user);
            string encryptedUserString = EncryptDecrypt.EncryptString(Key, userString);
            response.Cookies.Append("user", encryptedUserString, options);
        }
        public virtual User ReadFromCookie(HttpRequest request)
        {
            if (request.Cookies.ContainsKey("user"))
            {
                string encryptedUserString = request.Cookies["user"];
                string decryptedUserString = EncryptDecrypt.DecryptString(Key, encryptedUserString);
                User user = JsonConvert.DeserializeObject<User>(decryptedUserString);
                return user;
            }

            return null;
        }
    }
}
