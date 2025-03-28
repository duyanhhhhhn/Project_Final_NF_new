using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Final_NF.Models.Entities;

namespace Project_Final_NF.Models.ModelViews
{
    public class ProductView
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = "";

        public int StockQuantity { get; set; } = 0;

        public decimal Price { get; set; } = 0;

        public string ImageUrl { get; set; } = "";

        public string Description { get; set; } = "";

        public int CategoryId { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public static ProductView ToCategoryView(tbl_product item)
        {
            return new ProductView
            {
                ProductId = item.product_id,
                Name = item.name,
                StockQuantity = item.stock_quantity ?? 0,
                Price = item.price ,
                ImageUrl = item.image_url,
                Description = item.description,
                CategoryId = item.category_id ?? 1 
            };
        }

        public static tbl_product ToProduct(ProductView item)
        {
            return new tbl_product
            {
             product_id = item.ProductId,
             name = item.Name,
             stock_quantity = item.StockQuantity,
            price = item.Price,
            image_url = item.ImageUrl,
            description = item.Description,
            category_id = item.CategoryId
            };
        }
    }
}