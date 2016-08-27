using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
    public class ProductModelRepository
    {
        public static List<ProductModel> Products()
        {
            List<ProductModel> productList = new List<ProductModel>() {
                new ProductModel {Id = 1, Name = "HTC HD7", Price = 100, Description = "HTC HD7"},
                new ProductModel {Id = 2, Name = "HTC Trophy", Price = 80, Description = "HTC Trophy"},
                new ProductModel {Id = 3, Name = "Samsung Galaxy S1", Price = 100, Description = "Samsung Galaxy S1"},
                new ProductModel {Id = 4, Name = "Samsung Galaxy S2", Price = 110, Description = "Samsung Galaxy S2"},
                new ProductModel {Id = 5, Name = "Samsung Galaxy S3", Price = 120, Description = "Samsung Galaxy S3"},
            };
            return productList;
        }

        public static List<ProductModel> FillProduct(string name)
        {
            List<ProductModel> productList = new List<ProductModel>();
            productList = Products().Where(p => p.Name.Contains(name)).ToList();
            return productList;
        }
    }
}