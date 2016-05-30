using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
    public class LinqValueCalculator : IValueCalculator
    {
        private static int counter = 0;
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discparam)
        {
            this.discounter = discparam;
            System.Diagnostics.Debug.WriteLine(
 string.Format("Instance {0} created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return this.discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
    public class ShoppingCart
    {
        private IValueCalculator calc;
        public IEnumerable<Product> Products { get; set; }

        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }

    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize;
        
        public DefaultDiscountHelper(decimal discountParam)
        {
            DiscountSize = discountParam;
        }
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize / 100m * totalParam));
        }
    }
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}