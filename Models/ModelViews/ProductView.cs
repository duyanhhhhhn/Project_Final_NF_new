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
        public static ProductView ToCategoryView(product item)
        {
            return new ProductView
            {
                ProductId = item.product_id,
                Name = item.name,
                StockQuantity = (int)item.stock_quantity,
                Price = item.price,
                ImageUrl=  item.image_url,
                Description = item.description,
                CategoryId = (int)item.category_id
            };
        }
        public static product ToProduct(ProductView item)
        {
            return new product
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