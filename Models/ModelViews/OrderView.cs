using System;
using System.Collections.Generic;
using System.Linq;
using Project_Final_NF.Models.Entities;

namespace Project_Final_NF.Models.ModelViews
{
    public class OrderDetailView
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int OrderDetailId { get; set; }
        public string status { get; set; }


        public static OrderDetailView ToOrderDetailView(tbl_order_detail detail)
        {
            return new OrderDetailView
            {
                OrderDetailId = detail.order_detail_id,
                ProductId = (int)detail.product_id,
                Quantity = (int)detail.quantity,
                ProductName = detail.tbl_product?.name ?? "Unknown",
                Price = (int)detail.price,
                status = detail.status
            };
        }
    }

    public class OrderView
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int ConfirmedBy { get; set; }

        // Danh sách chi tiết đơn hàng
        public List<OrderDetailView> OrderDetails { get; set; } = new List<OrderDetailView>();

        public static OrderView ToOrderView(tbl_order item)
        {
            return new OrderView
            {
                OrderId = item.order_id,
                UserId = (int)item.user_id,
                TotalAmount = (int)item.total_amount,
                Status = item.status,
                UserName = item.tbl_member.acc_username,
                ConfirmedBy = item.confirmed_by ?? 1,
                OrderDetails = item.tbl_order_detail?.Select(OrderDetailView.ToOrderDetailView).ToList() ?? new List<OrderDetailView>()
            };
        }
    }
}
