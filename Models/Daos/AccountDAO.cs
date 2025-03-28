using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.ModelViews;

namespace Project_Final_NF.Models.Daos
{
    public class AccountDAO
    {
        private static AccountDAO _instance = null;
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                if( _instance == null) { _instance =new AccountDAO(); }
                return _instance;
            }
        }
        public MemberView ReturnMember(string usr, string pwd)
        {
            try
            {
                Entities.db_orderEntities en = new Entities.db_orderEntities();
                var q = en.tbl_member
                    .Where(d => d.acc_username == usr && d.acc_userpass == pwd)
                    .Select(c => new MemberView
                    {
                        Id = c.id,
                        UserName = c.acc_username,
                        Password = c.acc_userpass,
                        Active = c.active,
                        IdAuthentication = c.id_auth
                    }).FirstOrDefault();

                if (q != null)
                {
                    return q; // Trả về đối tượng đúng
                }
                else
                {
                    Debug.WriteLine("No matching member found.");
                    return new MemberView(); // Trả về đối tượng mặc định nếu không có kết quả
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new MemberView(); // Trả về đối tượng mặc định trong trường hợp có lỗi

        }
    }
}