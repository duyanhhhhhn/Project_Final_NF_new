using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Final_NF.Models.ModelViews
{
    public class UserView
    {
        public int UserId { get; set; } = 0;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}