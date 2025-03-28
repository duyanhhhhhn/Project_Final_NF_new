using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Final_NF.Models.ModelViews
{
    public class AuthorizationView
    {
        public int ID { get; set; }
        public string Title {  get; set; }
        public string Url { get; set; }
        public int IdAuthen { get; set; }
        public int Active {  get; set; }
    }
}