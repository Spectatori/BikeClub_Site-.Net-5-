using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace asp_anything.Models
{
    public class User : Viewer
    {
        public string currentNickname { get; set; }
    }
}
