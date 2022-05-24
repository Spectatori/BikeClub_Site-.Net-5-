using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace asp_anything.Models
{
    public class Viewer
    {
        public  string Nickname { get; set; }
        public  string Password { get; set; }
        public  string Email { get; set; }

        /*public virtual List<string> GetInfo()
        {
            List<string> info = new();
            info.Add(Nickname);
            info.Add(Password);
            info.Add(Email);
            return info;
        }*/
    }
}