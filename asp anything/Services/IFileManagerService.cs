using asp_anything.Models;
using System.Collections.Generic;

namespace asp_anything.Services
{
    public interface IFileManagerService
    {
        public List<User> ReadFromFile();
        public void WriteUsers(List<User> users);
    }
}
//interface