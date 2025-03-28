using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.Entities;

namespace Project_Final_NF.Models.Daos
{
    public sealed class AuthorizationDAO
    {
        private static AuthorizationDAO _instance = null;
        private AuthorizationDAO() { }
        public static AuthorizationDAO Instance
        {
            get
            {
                if (_instance == null) { _instance = new AuthorizationDAO(); }
                return _instance;
            }
        }
        public bool GetAuthorizationMember(int id_authen, string absoluteUrl)
        {
            try
            {
                var en = new db_orderEntities();
                var res = en.tbl_authorization.Any(d => d.id_authen == id_authen && absoluteUrl.ToLower().Contains(d.url.ToLower()));
                return res;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }
    }
}