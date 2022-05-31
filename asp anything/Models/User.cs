using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace asp_anything.Models
{
    public class User : Viewer
    {
        public string userPhoto { get; set; }
        public string changePassword { get; set; }
        /*public string ID { get; }
        public override List<string> GetInfo()
        {
            List<string> info = new();
            info.Add ("ID");
            return info;
        }*/
    }
}
