using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.Entities;

namespace Project_Final_NF.Models.ModelViews
{
    public class UserView
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdAuth { get; set; }
        public int Active { get; set; }
        public static UserView ToUserView(tbl_member item)
        {
            return new UserView
            {
                UserId = item.id,
                UserName = item.acc_username,
                Password = item.acc_userpass,
                IdAuth = item.id_auth,
                Active = item.active,
            };
        }
    }
}