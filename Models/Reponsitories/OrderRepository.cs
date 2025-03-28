using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.Entities;
using Project_Final_NF.Models.ModelViews;

namespace Project_Final_NF.Models.Reponsitories
{
    public class OrderRepository : IRepository<OrderView>
    {
        private static OrderRepository _instance = null;
        public static OrderRepository Instance
        {
            get
            {
                _instance = _instance ?? new OrderRepository();
                return _instance;
            }
        }

        public HashSet<OrderView> All()
        {
            try
            {
                using (var en = new db_orderEntities())
                      return en.tbl_order.ToList().Select(OrderView.ToOrderView).ToHashSet();
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex);
            }
            return new HashSet<OrderView>();
        }

        public void Create(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public HashSet<OrderView> findAll()
        {
            throw new NotImplementedException();
        }

        public UserView findById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<OrderView> FindByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Update(OrderView entity)
        {
            throw new NotImplementedException();
        }
    }
}