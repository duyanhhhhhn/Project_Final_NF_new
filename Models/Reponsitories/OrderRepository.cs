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

        public int Create(OrderView entity, List<OrderDetailView> orderItems)
        {
            try
            {
                using (var en = new db_orderEntities())
                {
                    var order = new tbl_order
                    {
                        user_id = entity.UserId,
                        total_amount = orderItems.Sum(item => item.Price * item.Quantity),
                        status = "Pending", 
                        created_at = DateTime.Now,
                        confirmed_by = null
                    };

                    en.tbl_order.Add(order);
                    en.SaveChanges();

                    foreach (var item in orderItems)
                    {
                        var orderItem = new tbl_order_detail
                        {
                            order_id = order.order_id,
                            product_id = item.ProductId,
                            quantity = 1,
                            price = 0,
                            status = "Pending"
                        };

                        en.tbl_order_detail.Add(orderItem);
                    }

                    en.SaveChanges();

                    return order.order_id; 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }


        public int Delete(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public HashSet<OrderView> findAll()
        {
            throw new NotImplementedException();
        }

        public HashSet<OrderView> FindByUserId(int userId)
        {
            try
            {
                using (var en = new db_orderEntities())
                {
                    return en.tbl_order
                             .Where(o => o.user_id == userId)
                             .ToList()
                             .Select(OrderView.ToOrderView)
                             .ToHashSet();
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex);
            }
            return new HashSet<OrderView>();
        }

        public HashSet<OrderView> FindByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Update(int orderDetailId, decimal newPrice)
        {
            try
            {
                using (var en = new db_orderEntities())
                {
                    var orderDetail = en.tbl_order_detail.FirstOrDefault(od => od.order_detail_id == orderDetailId);
                    if (orderDetail == null) return 0;

                    orderDetail.price = newPrice;

                    return en.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex);
            }
            return 0;
        }
        public int UpdateStatus(int orderDetailId, string newStatus)
        {
            try
            {
                using (var en = new db_orderEntities())
                {
                    var orderDetail = en.tbl_order_detail.FirstOrDefault(o => o.order_detail_id == orderDetailId);
                    if (orderDetail != null)
                    {
                        orderDetail.status = newStatus;
                        return en.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return 0;
        }



        public UserView findById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public void Create(OrderView entity)
        {
            throw new NotImplementedException();
        }
    }
}