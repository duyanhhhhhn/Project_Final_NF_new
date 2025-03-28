using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Final_NF.Models.ModelViews
{
    public class MemberView
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public int IdAuthentication { get; set; } = -1;
        public int Active { get; set; } = 0;
    }
}