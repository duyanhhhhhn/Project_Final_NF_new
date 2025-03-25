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
    public sealed class ProductRepository : IRepository<ProductView>
    {
        private static ProductRepository _instance = null;
        public static ProductRepository Instance
        {
            get
            {
                _instance = _instance ?? new ProductRepository();
                return _instance;
            }
        }
        public HashSet<ProductView> All()
        {
            try
            {
                using (var en = new db_orderEntities())
                    return en.products.ToList().Select(ProductView.ToCategoryView).ToHashSet();
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex);
            }
            return new HashSet<ProductView>();
        }

        public void Create(ProductView entity)
        {
            try
            {
                using (var db = new db_orderEntities())
                {
                    var item = new product
                    {
                        product_id = entity.ProductId,
                        name = entity.Name,
                        stock_quantity = entity.StockQuantity,
                        image_url = entity.ImageUrl,
                        description = entity.Description,
                        category_id = entity.CategoryId
                    };

                    db.products.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        public int Delete(ProductView entity)
        {
            throw new NotImplementedException();
        }

        public HashSet<ProductView> findAll()
        {
            throw new NotImplementedException();
        }

        public UserView findById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<ProductView> FindByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductView entity)
        {
            throw new NotImplementedException();
        }
    }
}