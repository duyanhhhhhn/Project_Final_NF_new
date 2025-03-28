using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.Daos;
using Project_Final_NF.Models.Entities;
using Project_Final_NF.Models.ModelViews;

namespace Project_Final_NF.Models.Reponsitories
{
    public class UserRepository
    {
        private static UserRepository _instance = null;
        private UserRepository() { }
        public static UserRepository Instance
        {
            get
            {
               if( _instance == null) { _instance = new UserRepository(); }
               return _instance;
            }
        }
        public MemberView CheckLogin(string username,string password)
        {
            return AccountDAO.Instance.ReturnMember(username, password);
        }
        public bool GetAuthorizationMember(int id_authen, string absoluteUrl)
        {
            return AuthorizationDAO.Instance.GetAuthorizationMember(id_authen, absoluteUrl);
        }
        public HashSet<UserView> All()
        {
            try
            {
                using (var en = new db_orderEntities())
                    return en.tbl_member.ToList().Select(UserView.ToUserView).ToHashSet();
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex);
            }
            return new HashSet<UserView>();
        }

    }
}