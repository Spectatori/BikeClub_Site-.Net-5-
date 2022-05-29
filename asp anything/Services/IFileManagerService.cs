using asp_anything.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace asp_anything.Services
{
    public interface IFileManagerService
    {
        public List<User> ReadFromFile();
        public void WriteUsers(List<User> users);
        public void WriteToCookie(User user, HttpResponse response);
        public User ReadFromCookie(HttpRequest request);
    }
}
//interface